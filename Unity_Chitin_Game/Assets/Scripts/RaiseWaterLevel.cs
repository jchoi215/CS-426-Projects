using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseWaterLevel : MonoBehaviour {

    public GameObject Water;
    public GameObject WaterBed;

    void Start () {
        InvokeRepeating("Flooding",1, (float).10);
    }


    void Flooding()
    {
        Vector3 waterHeight = Water.transform.position;
        waterHeight += new Vector3(0, (float)0.005, 0);
        Water.transform.position = waterHeight;
        isWaterBedToLow();
    }

    void isWaterBedToLow()
    {
        float waterYPos = Water.transform.position.y;
        float waterBedYPos = WaterBed.transform.position.y;
        float difference = waterYPos - waterBedYPos;
        if (difference > .30)
        {
            WaterBed.transform.position += new Vector3(0, (float)0.5, 0);
        }
    }

  
    void Update () {
		
	}
}
