using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin : MonoBehaviour
{
    public TrashManager trashManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator findTrash()
    {
        int colIndex = 0;
        int rowIndex = 0;
        int destroyedCount = 0;
        while(destroyedCount < 4)
        {
            if(trashManager.ListofColumns[colIndex][rowIndex] != null)
            {
                Debug.Log("OBJECT NOT FOUND");
            }
        }

        yield return null;
    }
}
