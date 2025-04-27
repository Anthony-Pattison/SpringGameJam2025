using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPrefabScript : MonoBehaviour
{
    public float speed;
    public float xpos;
    Vector2 TrashPos;
    public float stopPos;
    public bool move = true;
    // Start is called before the first frame update
    void Start()
    {
        TrashPos.y = 4.335f;
        transform.position = TrashPos;
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
            StartCoroutine(movement());
        }
    }

    IEnumerator movement()
    {
        while (move)
        {
            TrashPos.y -= speed * Time.deltaTime;
            TrashPos.x = xpos;
            transform.position = TrashPos;
            yield return null;
        }
    }
}
