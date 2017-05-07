using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float moveSpeed = 10f;
    public float turnSpeed = 50f;

    public void Start()
    {
        Cursor.visible = false;
    } 

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(-Vector3.up * moveSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) TurnRight();
            if (Input.GetKey(KeyCode.LeftArrow)  || Input.GetKey(KeyCode.A)) TurnLeft();
        }


        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.LeftArrow)  || Input.GetKey(KeyCode.D)) TurnLeft();
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A)) TurnRight();
        }
    }


    public void TurnLeft()
    {
        transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
    }

    public void TurnRight()
    {
        transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
    }

}

