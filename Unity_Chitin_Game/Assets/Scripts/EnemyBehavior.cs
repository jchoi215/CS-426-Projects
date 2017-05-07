using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior: MonoBehaviour
{
    float lookDistance = 50;
    float warningDistance = 30;
    float attackDistance = 20;
    float moveSpeed = 5;
    float damping = 10;

    // Use this for initialization
    void Start()
    {
        //player = GameObject.FindWithTag("playerObject").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Transform player = GameObject.FindWithTag("playerObject").transform;
        //float distance = Vector3.Distance(player.position, transform.position);
       
        ////Transform player = GameObject.Find("PlayerController(Clone)").transform;
        ////var player = GameObject.Instantiate(Spider_pref, Vector3.zero, Quaternion.identity) as GameObject;

        //if (distance < lookDistance)
        //{
        //    this.GetComponent<Renderer>().material.color = Color.green;
        //}

        //if (distance < warningDistance)
        //{
        //    this.GetComponent<Renderer>().material.color = Color.yellow;
        //}

        //if (distance < attackDistance)
        //{
        //    this.GetComponent<Renderer>().material.color = Color.red;
        //}
    }
}
