using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    //Array of Objects
    public GameObject[] items;
  
    //Spawning
    public float spawnInterval = 5;
    private float currentSpawnTime = 0;

    //Timer
    public float bigCountdown = 10; // 120 seconds is 2 minutes
    private float currentBigTime = 0;

    //Spawn Ranges
    private readonly float xMin = -540.0f;
    private readonly float xMax = 540.0f;

    private readonly float zMin = -540.0f;
    private readonly float zMax = 540.0f;

    //Spawn locations
    private readonly float itemY = 5;
    private float itemX;
    private float itemZ;

    //Item index
    private int index;

    //itemCount
    public int itemCount = 0;

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