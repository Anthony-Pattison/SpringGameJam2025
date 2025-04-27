using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
   public List<GameObject> TrashinColumn = new List<GameObject>();
    bool move = true;
    public float speed;
    public float xpos;
    public GameObject TrashPrefab;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(spawnTrash());

        }
    }
   private IEnumerator spawnTrash()
    {
        GameObject Trash = Instantiate(TrashPrefab);
        Vector2 TrashPos = Trash.transform.position;

        TrashPos = new Vector3(xpos, 4.335f, 0);



        Trash.transform.position = TrashPos;


        while (move)
        {
            TrashPos.y -= speed * Time.deltaTime;
            Trash.transform.position = TrashPos;
            if (Trash.GetComponent<SpriteRenderer>().bounds.Contains(player.transform.position))
            {
                Destroy(Trash);
                move = false;
            }

            yield return null;
        }
        yield return null;

       
    }
}
