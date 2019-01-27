using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MK_Appearance : MonoBehaviour {

    public string[] speech = { "", "", "", "", "", "", "", "", "", "" };
    public int[] usedNumbers;

    TextMesh text;

    public Vector3 onScreen;
    public Vector3 offScreen;

    bool on = false;

    public float speed;
    public int t = 50;

    public float timer = 10f;
    public float startTime = 10f;

	// Use this for initialization
	void Start () {
        transform.localPosition = offScreen;
        enter();
    }
	
	// Update is called once per frame
	void Update () {

        text = GameObject.Find("quote").GetComponent<TextMesh>();

        if (on)
        {
            
            transform.localPosition = new Vector3(onScreen.x, Mathf.Lerp(transform.localPosition.y, onScreen.y, speed), onScreen.z);
            speed += 0.5f * Time.deltaTime;

            if (transform.localPosition == onScreen)
            {
                exit();
            }
        }

        if (!on)
        {
            transform.localPosition = new Vector3(onScreen.x, Mathf.Lerp(transform.localPosition.y, offScreen.y, speed), onScreen.z);
            speed += 0.5f * Time.deltaTime;

            if (transform.localPosition == offScreen)
            {
                enter();
            }
        }
    }

    void enter()
    {
        int j = Random.Range(0, 10);

        /*
        int num;
        bool used = false;
        for (int i = 0; i < 10; i++)
        {
            if (usedNumbers[i] == j)
            {
                used = true;
            }
        } 

    */

        text.text = speech[j];
        
        Debug.Log("enter");
        speed = 0f;
        on = true;

    }

    void exit()
    {
        Debug.Log("exit");
        speed = 0f;
        on = false;
        
    }
}
