using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    public GameObject TrashPrefab;
    public GameObject colspawner1;
    public GameObject colspawner2;
    public GameObject colspawner3;
    public GameObject colspawner4;
    //public List<GameObject> col1;
    //public List<GameObject> col2;
    //public List<GameObject> col3;
    //public List<GameObject> col4;
    public List<List<GameObject>> ListofColumns = new List<List<GameObject>>();
    public float speed;
    bool move = true;
    // Start is called before the first frame update
    void Start()
    {


      

        //ListofColumns.Add(col1); ListofColumns.Add(col2); ListofColumns.Add(col3); ListofColumns.Add(col4);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            //ListofColumns[1][2] = TrashPrefab;
          
        }

    }
    
}
