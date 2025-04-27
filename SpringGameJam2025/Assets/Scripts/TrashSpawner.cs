using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public List<GameObject> TrashinColumn = new List<GameObject>();
    
   
    public float xpos;
    public GameObject TrashPrefab;
    public GameObject player;
  
    public float EndPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
 
       
       
        if (Input.GetKeyDown(KeyCode.Space) && TrashinColumn.Count < 7)
        {
            spawnTrash(); // runs the spawn function
        }

        for (int i = 0; i < TrashinColumn.Count; i++) // runs for every object in the list
        {
            if (TrashinColumn[i].GetComponent<SpriteRenderer>().bounds.Contains(player.transform.position) && TrashinColumn[i].GetComponent<TrashPrefabScript>().move)
            {
                Destroy(TrashinColumn[i]); // destroys prefab
                TrashinColumn.Remove(TrashinColumn[i]); // remove it from the list
                
            }

            else if (TrashinColumn[i].GetComponent<SpriteRenderer>().bounds.Contains(player.transform.position) && !TrashinColumn[i].GetComponent<TrashPrefabScript>().move)
            {
                player.transform.position = player.GetComponent<PlayerBoatScript>().perplayerpos; // moves the player back to their pervious position
            }
        }
    }
    private void spawnTrash()
    {
        GameObject Trash = Instantiate(TrashPrefab); // make the prefab
        Vector2 TrashPos = Trash.transform.position; 
        EndPos =  -4.24f + (1.225f * TrashinColumn.Count); // gives the prefab a place to stop based on the amount of items in the list
        TrashinColumn.Add(Trash); 
        Trash.transform.position = TrashPos;
        Trash.GetComponent<TrashPrefabScript>().xpos = xpos; // gives the prefab the column to start in from the inspecter
        Trash.GetComponent<TrashPrefabScript>().stopPos = EndPos; // gives the prefab the end position


    }
}
