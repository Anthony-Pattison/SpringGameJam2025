using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    public GameObject TrashPrefab;
    public List<TrashSpawner> TrashSpawnerList = new List<TrashSpawner>();
    public float speed=0.005f;
    public float GlobalScale = 0.0001f;
    public float spawnRate =2;
    public int score=0;
    public int numberOfItems;
    public TextMeshProUGUI scoreTextBox;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreTextBox.text = score.ToString();
        GlobalScale += 0.0001f *Time.deltaTime;
        speed += GlobalScale*Time.deltaTime;
        spawnRate -= GlobalScale *Time.deltaTime;
    }

    public int checkNumberOfItems()
    {
        numberOfItems = 0;
        foreach (TrashSpawner s in TrashSpawnerList)
        {
            foreach (GameObject g in s.TrashinColumn)
            {
                numberOfItems++;
            }
        }

        return numberOfItems;
    }
    
}
