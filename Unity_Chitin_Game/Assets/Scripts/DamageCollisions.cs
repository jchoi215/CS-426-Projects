using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollisions : MonoBehaviour {

    PlayerHealth playerHealth;
    Rigidbody playerBody;

	void Start () {
        playerHealth = GetComponent<PlayerHealth>();
        playerBody = GameObject.Find("PlayerController(Clone)").GetComponent<Rigidbody>();
    }
	
	void Update () {
		
	}


    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        if (collision.relativeVelocity.magnitude > 2)
            audio.Play();

    }

    //void OnTriggerEnter(Collider hit)
    //{
    //    if (hit.transform.CompareTag("ScorpionHazard"))
    //    {
    //        GameObject.Find("PlayerController(Clone)").GetComponent<PlayerHealth>().damageHealth(50);
    //        //playerBody.AddRelativeForce(Vector3.forward * 500);
    //    }

    //    if (hit.transform.CompareTag("playerObject"))
    //    {
    //        GameObject.Find("PlayerController(Clone)").GetComponent<PlayerHealth>().damageHealth(25);
    //        //playerBody.AddRelativeForce(Vector3.forward * 500);
    //    }
    //}
}
