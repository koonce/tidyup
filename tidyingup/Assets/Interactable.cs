using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public GameObject player;
    public GameObject guide;

    public float throwForce = 50;

    public float distance;
    public float throwHeight = 1f;

    public bool held = false;

    Rigidbody rb;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("player");
        guide = GameObject.Find("guide");
        rb = this.GetComponent<Rigidbody>();
    }

    public void carry()
    {
        //pick up in a specific spot?
        Physics.IgnoreCollision(player.GetComponent<CapsuleCollider>(), this.GetComponent<Collider>());

        transform.position = guide.transform.position;

        this.transform.parent = player.transform;

        rb.constraints = RigidbodyConstraints.FreezePosition; 
        rb.freezeRotation = true;

        held = true;

        Debug.Log("working!");
    }

    public void toss()
    {
        if (held)
        {
            this.transform.parent = null;
            rb.freezeRotation = false;
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(new Vector3(player.transform.forward.x, throwHeight, player.transform.forward.z) * throwForce);
        }

        held = false;
    }

}
