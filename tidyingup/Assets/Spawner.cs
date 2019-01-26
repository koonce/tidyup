using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    //Array of Objects
    public GameObject[] items;
  
    // Use this for initialization
    public float spawnInterval;
    public float currentSpawnTime;

    public float bigCountdown; // 120 seconds is 2 minutes
    public float currentBigTime;

    private float itemX;
    private float itemY;
    private float itemZ;

    private int index;

    public int itemCount;

    void Start()
    {
        spawnInterval = 5;
        currentSpawnTime = 0;

        bigCountdown = 10; // 120 seconds is 2 minutes
        currentBigTime = 0;

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
        itemX = Random.Range(-22.0f, 22.0f);
        itemZ = Random.Range(-22.0f, 22.0f);
        Vector3 itemPos = new Vector3(itemX, itemY, itemZ);

        index = Random.Range(0, items.Length);

        Instantiate(items[index], itemPos, Quaternion.identity);

        itemCount++;

        //Debug.Log(itemCount);
    }
}