using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    private int score;

    private GameObject manager;
    private GameManager gameManager;

    // Use this for initialization
    void Start () {

        manager = GameObject.Find("GameManager");
        gameManager = manager.GetComponent<GameManager>();

        GetComponent<Text>().text = gameManager.itemsThrownOut.ToString();
	}
}
