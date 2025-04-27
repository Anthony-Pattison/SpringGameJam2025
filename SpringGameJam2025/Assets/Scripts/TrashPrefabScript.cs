using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPrefabScript : MonoBehaviour
{
    public List<Sprite> spriteList = new List<Sprite>();
    public float speed;
    public float xpos;
    public bool isItem;
    Vector2 TrashPos;
    public float stopPos;
    public bool move = true;
    public SpriteRenderer sr;
    public Coroutine movingCR;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = spriteList[(int)Random.Range(0, spriteList.Count)];
        TrashPos.y = 4.335f; // starts at the top of the screen
        transform.position = TrashPos; // gives movement
        gameObject.transform.Rotate(0.0f, 0.0f, Random.Range(-90, 90), Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 temppos = transform.position;

        if (temppos.y <= stopPos)
        {
            move = false;

        }
        else
        {
            if (movingCR == null){
                movingCR = StartCoroutine(movement()); // runs movement
            }
        }

        
    }

    IEnumerator movement()
    {
        while (move)
        {
            TrashPos.y -= speed * Time.deltaTime; // moves the trash down
            TrashPos.x = xpos; // puts the trash in a column based on the spawner
            transform.position = TrashPos; // gives movement
            yield return null;
        }
    }


}
