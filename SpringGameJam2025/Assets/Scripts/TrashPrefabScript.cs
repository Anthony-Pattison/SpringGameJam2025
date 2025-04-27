using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPrefabScript : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> spriteList = new List<Sprite>();
    public TrashManager trashManager;
    public TrashSpawner spawner;
    public Coroutine movingCR;
    Vector2 TrashPos;
    public float EndPos;
    public int itemID;
    public bool isStopped = false;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = spriteList[itemID];
        TrashPos.y = transform.position.y;
        TrashPos.x = transform.position.x; // puts the trash in a column based on the spawner
        gameObject.transform.Rotate(0.0f, 0.0f, Random.Range(-90, 90), Space.Self);
        movingCR = StartCoroutine(movement());
        print(TrashPos);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator movement()
    {
        while (true)
        {
            foreach(GameObject s in spawner.TrashinColumn)
            {
                 
                //if(!(transform.position.y == s.transform.position.y) && transform.position.y - s.transform.position.y < 1.225f)
                if(s.transform.position.y > transform.position.y - 1.225f && s.GetComponent<TrashPrefabScript>().isStopped || transform.position.y < -4.225f)
                {
                    print("Cancelling movement CR");
                    stopCoroutineFunction();
                }

            }

            Debug.Log(trashManager.speed + spawner.transform.position.x);
            TrashPos.y -= trashManager.speed;
            transform.position = TrashPos;
            yield return null;
        }
        stopCoroutineFunction();

    }

    public void stopCoroutineFunction()
    {

        StopCoroutine(movingCR);
        movingCR = null;
        isStopped = true;
    }

    public void activateAbility()
    {
        if (itemID == 4) //ice freezing column
        {
            print("Ice power activated");
            spawner.startIceCR();
        }

        if (itemID == 5) //Net deleting everything
        {
            foreach (GameObject s in spawner.TrashinColumn)
            {
                Destroy(s);
                spawner.TrashinColumn.Remove(spawner.TrashinColumn[0]);
                print("List getting deleted: " + spawner.TrashinColumn.Count);
            }
        }


    }
}
