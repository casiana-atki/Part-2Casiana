using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawningPlane : MonoBehaviour
{
    public GameObject airplane;
    // Cannot figure out how to make it spawn at a random time between 1 & 5 seconds :( Everything else works fine though 
    public float spawnTime = Random.Range(1, 5);
    float xValue = Random.Range(-5, 5);
    float yValue = Random.Range(-5, 5);
    Vector3 spawnPos; 

     
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += 1 * Time.deltaTime;
        if (spawnTime > 5)
        {
            Vector3 spawnPos3 = new Vector3(xValue, yValue, 0);
            spawnTime = 0;
            Instantiate(airplane, spawnPos3, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        }  
    }
}

