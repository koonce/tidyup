using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float rotSpeed;
    public float moveSpeed;
    public float mouseSensitivity;

    public float rotationY;
    public float rotationX;

    //public bool holdingItem = false;

    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        if (rb)
        {
            rb.freezeRotation = true;
        }

        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {

        //rotate player with A & D
        /*
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, rotSpeed, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -rotSpeed, 0) * Time.deltaTime);
        }
        */

        //move player
        rb = GetComponent<Rigidbody>();

        if (Input.GetKey(KeyCode.W))
        {
            //rb.AddRelativeForce(Vector3.forward * moveSpeed * Time.deltaTime);
            transform.Translate(new Vector3(0f, 0f, Time.deltaTime * moveSpeed));
        }
        if (Input.GetKey(KeyCode.S))
        {
            //rb.AddRelativeForce(Vector3.forward * -moveSpeed * Time.deltaTime);
            transform.Translate(new Vector3(0f, 0f, Time.deltaTime * -moveSpeed));
        }
        if (Input.GetKey(KeyCode.A))
        {
            //rb.AddRelativeForce(Vector3.forward * -moveSpeed * Time.deltaTime);
            transform.Translate(new Vector3(Time.deltaTime * -moveSpeed, 0f, 0f));
        }
        if (Input.GetKey(KeyCode.D))
        {
            //rb.AddRelativeForce(Vector3.forward * -moveSpeed * Time.deltaTime);
            transform.Translate(new Vector3(Time.deltaTime * moveSpeed, 0f, 0f));
        }

        //mouse look for player

        float mouseInputX = Input.GetAxis("Mouse X");
        float mouseInputY = Input.GetAxis("Mouse Y");

        float Ymin = -55f;
        float Ymax = 55f;

        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;

            rotationY += mouseInputY * mouseSensitivity;
            rotationY = Mathf.Clamp(rotationY, Ymin, Ymax);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity;
            rotationY = Mathf.Clamp(rotationY, Ymin, Ymax);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }

    }
}
