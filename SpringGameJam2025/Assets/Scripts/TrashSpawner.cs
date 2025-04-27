using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public List<GameObject> TrashinColumn = new List<GameObject>();


    public float xpos;
    public List<GameObject> prefabList = new List<GameObject>();
    public GameObject player;
    public TrashManager TrashManager;
    public float EndPos;
    private float t;
    public int chance;

    // Start is called before the first frame update
    void Start()
    {
        t = Random.Range(-1, 1); //random range so that all the spawners don't spawn at the same time and are instead staggered.
    }

    //Update is called once per frame
    void Update()
    {
        t += Time.deltaTime * 0.5f;

        if (t > TrashManager.spawnRate)
        {
            t = Random.Range(-1, 1);

            chance = (int)Random.Range(0, 100);
            if (chance < 70) //70% chance
            {
                spawnPrefab(0); //trash

            }
            else if (chance < 85) //15% chance
            {
                spawnPrefab(1); //ice - freeze column from spawning for 3s
            }
            else if (chance < 95) //10% chance
            {
                spawnPrefab(2); //net - clear column
            }
            else if (TrashManager.checkNumberOfItems() > 3) //5% chance and only if more than 3 items, if less than 3 items then spawns trash
            {
                spawnPrefab(4); //dolphin - clear top 3 trash
            }
            else
            {
                spawnPrefab(0); //spawn trash
            }



        }

        /*for loop below checks if trash/item
         *  ------- gets collected by player
         *  ------- player tries to move into piled up trash
         *  ------- item hits floor
         */
        for (int i = 0; i < TrashinColumn.Count; i++) // runs for every object in the list
        {
            TrashPrefabScript trashScript = TrashinColumn[i].GetComponent<TrashPrefabScript>();

            if (checkingSpriteBounds(i, player) && trashScript.movingCR != null)
            {
                Destroy(TrashinColumn[i]);
                TrashinColumn.Remove(TrashinColumn[i]);
                //----------------------------------------------------------------------ADD SCORE FUNCTION AND ACTIVATION-----------------------------------
                TrashManager.score += 1;
                break;
            }

            else if (checkingSpriteBounds(i, player) && trashScript.movingCR == null)
            {
                player.transform.position = player.GetComponent<PlayerBoatScript>().perplayerpos; // moves the player back to their pervious position
            }

            else if (trashScript.itemID > 0 && trashScript.movingCR == null) //destroy item if reach bottom
            {
                Destroy(TrashinColumn[i]);
                TrashinColumn.Remove(TrashinColumn[i]);
            }
        }
    }
    private void spawnPrefab(int i)
    {
        GameObject Trash = Instantiate(prefabList[0], transform.position, transform.rotation); //spawn trash
        Vector2 TrashPos = Trash.transform.position;
        EndPos = -4.24f + (1.225f * TrashinColumn.Count); // gives the prefab a place to stop based on the amount of items in the list
        TrashinColumn.Add(Trash);
        TrashPrefabScript TrashScript = Trash.GetComponent<TrashPrefabScript>();
        TrashScript.itemID = i;
        TrashScript.trashManager = TrashManager;
        TrashScript.EndPos = EndPos;
        TrashScript.spawner = gameObject.GetComponent<TrashSpawner>();
    }



    bool checkingSpriteBounds(int i, GameObject GO)
    {
        if (TrashinColumn[i].GetComponent<SpriteRenderer>().bounds.Contains(GO.transform.position))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public float checkLowestPoint()
    {
        float EndPos = -4.24f + (1.225f * (TrashinColumn.Count-1));
        return EndPos;
    }
}
