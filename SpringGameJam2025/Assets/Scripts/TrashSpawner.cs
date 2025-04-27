using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public List<GameObject> TrashinColumn = new List<GameObject>();
    public Coroutine icedLaneCoroutine;
    public Coroutine timerCR;
    public float xpos;
    public GameObject trashitemPrefab;
    public GameObject icePrefab;
    public GameObject player;
    public TrashManager TrashManager;
    public GameObject Endscreen;
    public GameObject ResetCondition;
    public float EndPos;
    private float t;
    public int chance;

    // Start is called before the first frame update
    void Start()
    {

        t = Random.Range(-1, 1); //random range so that all the spawners don't spawn at the same time and are instead staggered.
        timerCR = StartCoroutine(timer());
    }

    //Update is called once per frame
    void Update()
    {

        if (t > TrashManager.spawnRate)
        {
            t = Random.Range(-1, 1);
            spawnPrefab((int)Random.Range(0, 3)); //trash




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
                if (trashScript.itemID > 3)
                {
                    trashScript.activateAbility();
                }
                TrashManager.score += 1;
                break;
            }

            else if (checkingSpriteBounds(i, player) && trashScript.movingCR == null)
            {
                player.transform.position = player.GetComponent<PlayerBoatScript>().perplayerpos; // moves the player back to their pervious position
            }

            else if (trashScript.itemID > 3 && trashScript.movingCR == null) //destroy item if reach bottom
            {
                print("Item got destroyed");
                Destroy(TrashinColumn[i]);
                TrashinColumn.Remove(TrashinColumn[i]);
            }
        }

        if (TrashinColumn.Count > 7)
        {
            player.GetComponent<PlayerBoatScript>().isAlive = false;
            Endscreen.SetActive(true);
            ResetCondition.SetActive(true);
        }
    }


    private void spawnPrefab(int k)
    {
        GameObject Trash = Instantiate(trashitemPrefab, transform.position, transform.rotation); //spawn trash
        Vector2 TrashPos = Trash.transform.position;
        EndPos = -4.24f + (1.225f * TrashinColumn.Count); // gives the prefab a place to stop based on the amount of items in the list
        TrashinColumn.Add(Trash);
        TrashPrefabScript TrashScript = Trash.GetComponent<TrashPrefabScript>();
        TrashScript.itemID = k;
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
        float EndPos = -4.24f + (1.225f * (TrashinColumn.Count - 1));
        return EndPos;
    }

    public void startIceCR()
    {
        if (icedLaneCoroutine == null)
        {
            icedLaneCoroutine = StartCoroutine(icingTheLane());
        }
    }

    public void stopIceCR()
    {
        if (icedLaneCoroutine != null)
        {
            StopCoroutine(icedLaneCoroutine);
            icedLaneCoroutine = null;

        }
    }

    public void startTimer()
    {
        if (timerCR == null)
        {
            timerCR = StartCoroutine(timer());
        }
    }

    public IEnumerator icingTheLane()
    {
        print("ICING THE LANE IN COLUMN: " + transform.position.x);
        GameObject iceOverlay = Instantiate(icePrefab);
        t = 0;
        StopCoroutine(timerCR);
        timerCR = null;
        while (true)
        {
            yield return new WaitForSeconds(3);

            startTimer();
            Destroy(iceOverlay);
            stopIceCR();
        }

    }

    public IEnumerator timer()
    {
        while (true)
        {
            //print(t);
            t += Time.deltaTime * 0.5f;
            yield return null;
        }
    }
}
