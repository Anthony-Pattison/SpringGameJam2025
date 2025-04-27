using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoatScript : MonoBehaviour
{
    Vector2 playerpos;
    public Vector2 perplayerpos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         playerpos = transform.position;

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))  // right movement
        {
            perplayerpos = transform.position;
            playerpos.x += 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) // left movement 
        {
            perplayerpos = transform.position;
            playerpos.x -= 2;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) // up movement
        {
            perplayerpos = transform.position;
            playerpos.y += 1.225f;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) // Down movement 
        {
            perplayerpos = transform.position;
            playerpos.y -= 1.225f;
        }

        OutofBounds(); // keeps the player on the screen
        transform.position = playerpos;
    }

    void OutofBounds()
    {
        if (playerpos.y >= 5)
        {
            playerpos.y = 4.335f;
        }else if (playerpos.y < -4.25)
        {
            playerpos.y = -4.24f;
        }

        if (playerpos.x > 4.01)
        {
            playerpos.x = 4.01f;
        }
        else if (playerpos.x < -4)
        {
            playerpos.x = -3.99f;
        }
    }
}
