using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutlerySpawn : MonoBehaviour
{
    public GameObject cutleryPREFAB;
    public float spawnInterval = 1.5f;
    public float minX = 0;
    public float maxX = 91f;
    public float minY = 0f;
    public float maxY = 0.5f;

    public float timer = 0; 

    void Start()
    {
        
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnPrefab();
        }
    }
    void SpawnPrefab()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector2 spawnPosition = new Vector2(randomX, randomY);
        Instantiate(cutleryPREFAB, spawnPosition, Quaternion.identity);
    }

    private void OnBecameInvisible()
    {
        Destroy(cutleryPREFAB);
    }
}
