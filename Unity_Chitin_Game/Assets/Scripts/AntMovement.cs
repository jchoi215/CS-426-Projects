using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMovement : MonoBehaviour {

    //public float speed = 5.0f;
    //public float moveTo = 5.0f;
    //public float time = 3f;
    //private Vector3 direction;
    //public NavMeshAgent nav;

    //void Start()
    //{
    //    direction = transform.position;
    //}

    //void Update()
    //{
    //    transform.Rotate(Vector3.right * Time.deltaTime);
        
    //    time += Time.deltaTime;
    //    if (time > moveTo)
    //    {
    //        move();
    //        time = 0;
    //    }
    //}

    //void move()
    //{
    //    float xPos = gameObject.transform.position.x;
    //    float zPos = gameObject.transform.position.z;
    //    float xNewPos = xPos + Random.Range(xPos - 100, xPos + 100);
    //    float zNewPos = zPos + Random.Range(zPos - 100, zPos + 100);
    //    Vector3 moveLocation = new Vector3(0, gameObject.transform.position.y, 0);
    //    transform.Rotate(moveLocation);


    //    Vector3 euler = transform.eulerAngles;
    //    euler.z = Random.Range(0f, 360f);
    //    transform.eulerAngles = euler;
    //}

    ////void FixedUpdate()
    ////{
    ////    faceRandDirection();
    ////}

    ////void faceRandDirection()
    ////{
    ////    Vector3 euler = transform.eulerAngles;
    ////    euler.y = Random.Range(0f, 360f);
    ////    transform.eulerAngles = euler;
    ////}
}
