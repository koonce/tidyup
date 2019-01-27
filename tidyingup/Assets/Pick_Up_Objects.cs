using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up_Objects : MonoBehaviour {

    //public float distance;
    //public float smooth;

    public float maxDistance;
    public float dist;

    GameObject itemHeld;

    public bool canHold = true;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        Debug.DrawRay(transform.position, transform.forward, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            if  (canHold)
            {
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    Debug.Log("clicked hit");
                    dist = Vector3.Distance(this.transform.position, hit.transform.position);
                    Debug.DrawRay(transform.position, transform.forward, Color.green);
                    if (hit.transform.tag == "throwable") //&& dist < maxDistance)
                        {
                            Debug.Log("okayokay");
                            hit.transform.gameObject.GetComponent<Interactable>().carry();
                            itemHeld = hit.transform.gameObject;

                            canHold = false;
                        }
                }
            }
            else if (!canHold)
            {
                Debug.Log("throw");
                itemHeld.GetComponent<Interactable>().toss();
                itemHeld = null;
                canHold = true;
            }
        }
       
    }

}
