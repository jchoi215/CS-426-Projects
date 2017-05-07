using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHeadCollision : MonoBehaviour
{
    public GameObject player;
    private int points = 100;
    private int health = 100;

    private void OnCollisionEnter(Collision collidingObject)
    {
        if (collidingObject.gameObject.tag == "Player")
            Destroy(this.gameObject);

        if (collidingObject.gameObject.tag == "bullet_1")
        {
            health -= 50;
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        //if (collidingObject.gameObject.tag == "bullet_2)
        //{
        //    health -= 40;
        //    if (health <= 0)
        //    {
        //        Destroy(this.gameObject);
        //    }
        //}
    }

}