using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPrefabScript : MonoBehaviour
{
    public float speed;
    public float xpos;
    public bool isItem = false;
    public bool killitem;
    Vector2 TrashPos;
    public float stopPos;
    public bool move = true;
    // Start is called before the first frame update
    void Start()
    {
        TrashPos.y = 4.335f; // starts at the top of the screen
        transform.position = TrashPos; // gives movement
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 temppos = transform.position;

        if (temppos.y <= stopPos)
        {
            move = false;

        }else if (temppos.y <= stopPos && isItem)
        {
            killitem = true;
        }
        else
        {
            StartCoroutine(movement()); // runs movement
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
