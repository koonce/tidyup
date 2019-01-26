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

    void Start()
    {
        spawnInterval = 5;
        currentSpawnTime = 0;

        bigCountdown = 10; // 120 seconds is 2 minutes
        currentBigTime = 0;
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
            spawnInterval -= 1;
            currentBigTime = 0;
        }
    }

    void Spawn()
    {
        Vector3 enemyPos = new Vector3(0,0,0);
        Instantiate(items[0], enemyPos, Quaternion.identity);
    }
}