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
            spawnTrash();
        }

        for (int i = 0; i < TrashinColumn.Count; i++)
        {
            if (TrashinColumn[i].GetComponent<SpriteRenderer>().bounds.Contains(player.transform.position) && TrashinColumn[i].GetComponent<TrashPrefabScript>().move)
            {
                Destroy(TrashinColumn[i]);
                TrashinColumn.Remove(TrashinColumn[i]);
                
            }

            else if (TrashinColumn[i].GetComponent<SpriteRenderer>().bounds.Contains(player.transform.position) && !TrashinColumn[i].GetComponent<TrashPrefabScript>().move)
            {
                player.transform.position = player.GetComponent<PlayerBoatScript>().perplayerpos;
            }
        }
    }
    private void spawnTrash()
    {
        GameObject Trash = Instantiate(TrashPrefab);
        Vector2 TrashPos = Trash.transform.position;
        EndPos =  -4.24f + (1.225f * TrashinColumn.Count);
        TrashinColumn.Add(Trash);
        Trash.transform.position = TrashPos;
        Trash.GetComponent<TrashPrefabScript>().xpos = xpos;
        Trash.GetComponent<TrashPrefabScript>().stopPos = EndPos;


    }
}
