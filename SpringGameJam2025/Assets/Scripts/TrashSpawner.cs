using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
   public List<GameObject> TrashinColumn = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(spawnTrash());
    }

   private IEnumerator spawnTrash()
    {
        Debug.Log("working");
        yield return null;
    }
}
