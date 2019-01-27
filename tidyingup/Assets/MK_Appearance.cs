using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MK_Appearance : MonoBehaviour
{

    string[] speech = new string[]
        {
        "Make sure you follow the Konmari method!",
        "Did that item spark joy?",
        "I still must introduce myself to the house!",
        "Do you want this to be a part of your future?",
        "This is the most clutter I’ve ever seen!",
        "Make sure to hold on to the things that matter!",
        "This is so fun!",
        "I love messes!",
        "You must get to know your home through tidying!",
        "say thank you before you throw your clutter away!",
        "Be gentle!! GENTLE!!!",
        };
    public int[] usedNumbers;

    TextMeshPro text;

    public Vector3 onScreen;
    public Vector3 offScreen;

    bool on = false;

    public float speed;
    public int t = 50;

    public float timer = 10f;
    public float startTime = 10f;

    public float bigCountdown = 10;
    private float currentBigTime = 0;
    private float littleCountdown = 3;

    // Use this for initialization
    void Start()
    {
        transform.localPosition = offScreen;
        enter();

        text.GetComponent<Renderer>().sortingLayerID =
        this.transform.parent.GetComponent<Renderer>().sortingLayerID;

    }

    // Update is called once per frame
    void Update()
    {

        text = GameObject.Find("quote").GetComponent<TextMeshPro>();

        if (on)
        {

            transform.localPosition = new Vector3(onScreen.x, Mathf.Lerp(transform.localPosition.y, onScreen.y, speed), onScreen.z);
            speed += 0.5f * Time.deltaTime;

            if (transform.localPosition == onScreen)
            {
                currentBigTime += Time.deltaTime;

                if (currentBigTime >= littleCountdown)
                {
                    exit();
                }
            }
        }

        if (!on)
        {
            transform.localPosition = new Vector3(onScreen.x, Mathf.Lerp(transform.localPosition.y, offScreen.y, speed), onScreen.z);
            speed += 0.5f * Time.deltaTime;

            if (transform.localPosition == offScreen)
            {
                currentBigTime += Time.deltaTime;

                if (currentBigTime >= bigCountdown)
                {
                    enter();
                }
            }
        }
    }

    void enter()
    {
        int j = 0;
        j = Random.Range(0, 10);

        text.SetText(speech[j]);

        Debug.Log("enter");
        speed = 0f;
        on = true;
        currentBigTime = 0;

    }

    void exit()
    {
        Debug.Log("exit");
        speed = 0f;
        on = false;
        currentBigTime = 0;

    }
}
