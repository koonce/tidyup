using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    //Array of Objects
    public GameObject[] items;
  
    //Spawning
    public float spawnInterval;
    private float currentSpawnTime;

    //Timer
    public float bigCountdown; // 120 seconds is 2 minutes
    private float currentBigTime;

    //Spawn Ranges
    private float xMin;
    private float xMax;

    private float zMin;
    private float zMax;

    //Spawn locations
    private float itemX;
    private float itemY;
    private float itemZ;

    //Item index
    private int index;

    //itemCount
    public int itemCount;

    void Start()
    {
        spawnInterval = 5;
        currentSpawnTime = 0;

        bigCountdown = 10; // 120 seconds is 2 minutes
        currentBigTime = 0;

        xMin = -22.0f;
        xMax = 22.0f;

        zMin = -22.0f;
        zMax = 22.0f;

        itemY = 5;

        itemCount = 0;
}

    void Update()
    {
        currentSpawnTime += Time.deltaTime;
        currentBigTime += Time.deltaTime;

        if (currentSpawnTime >= spawnInterval)
        {
            Spawn();
            currentSpawnTime = 0;
        }

        if (currentBigTime >= bigCountdown)
        {
            if (spawnInterval != 1) {
                spawnInterval -= 1;
            }
            currentBigTime = 0;
        }
    }

    void Spawn()
    {
        itemX = Random.Range(xMin, xMax);
        itemZ = Random.Range(zMin, zMax);

        Vector3 itemPos = new Vector3(itemX, itemY, itemZ);

        index = Random.Range(0, items.Length);

        Instantiate(items[index], itemPos, Quaternion.identity);

        itemCount++;

        //Debug.Log(itemCount);
    }
}