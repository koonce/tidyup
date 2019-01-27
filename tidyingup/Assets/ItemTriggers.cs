using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemTriggers : MonoBehaviour
{

    private GameObject spawner;
    private Spawner spawnerScript;

    private GameObject manager;
    private GameManager gameManager;

    public int itemMax = 3;
    public int itemsThrown = 0;

    // Use this for initialization
    void Start()
    {
        spawner = GameObject.Find("Spawner");
        spawnerScript = spawner.GetComponent<Spawner>();

        manager = GameObject.Find("GameManager");
        gameManager = manager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnerScript.itemCount > itemMax)
        {
            gameManager.itemsThrownOut = itemsThrown;
            SceneManager.LoadScene("End");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        spawnerScript.itemCount--;
        itemsThrown++;
    }
}