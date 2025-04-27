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
    public float itemID;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = spriteList[(int)Random.Range(0, 3)];
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
        while (transform.position.y > EndPos)
        {
            TrashPos.y -= trashManager.speed * Time.deltaTime; // moves the trash down
            transform.position = TrashPos; // gives movement
            EndPos = spawner.checkLowestPoint();
            yield return null;
        }
        stopCoroutineFunction();

    }

    public void stopCoroutineFunction()
    {
        StopCoroutine(movingCR);
        movingCR = null;
    }
}
