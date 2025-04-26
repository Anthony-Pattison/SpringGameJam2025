using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    public GameObject gamejj;
    public List<GameObject> col1;
    public List<GameObject> col2;
    public List<GameObject> col3;
    public List<GameObject> col4;
    public List<List<GameObject>> ListofColumns = new List<List<GameObject>>();

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 8; i++)
        {
            col4[i] = null;
        }

        col1 = col2 = col3 = col4;
        ListofColumns.Add(col1); ListofColumns.Add(col2); ListofColumns.Add(col3); ListofColumns.Add(col4);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            col4[4] = gamejj;
        }
    }
}
