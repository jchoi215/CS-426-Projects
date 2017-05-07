using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBedScript : MonoBehaviour
{

    public GameObject WaterBed;

    void Start()
    {
        InvokeRepeating("Flooding", 1, 1);
    }


    void Flooding()
    {
        Vector3 waterHeight = WaterBed.transform.position;
        waterHeight += new Vector3(0, (float)0.015, 0);
        WaterBed.transform.position = waterHeight;
    }

    //void isPlayerBelowWater()
    //{
    //    float playerYPos = Player.transform.position.y;
    //    float waterYPos = Water.transform.position.y;
    //    float yDif = playerYPos - waterYPos;

    //    if (yDif < .5)
    //    {
    //        PlayerHealth health = (PlayerHealth)Player.GetComponent(typeof(PlayerHealth));
    //        healthScript.damageHealth(1);
    //    }

    //}
}
