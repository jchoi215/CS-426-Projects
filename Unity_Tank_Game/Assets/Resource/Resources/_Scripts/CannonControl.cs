using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CannonControl : MonoBehaviour
{
    public GameObject L_Barrel;
    public GameObject R_Barrel;
    public GameObject turretBody;
    public Score trackPoints;
    //public Text Score;

    private int count = 0;
    private int Counter = 0;
    

    private string Ammo = "Prefab/Rubber Bullet";

    private void Start()
    {
        //  Score.text = "Score: " + count.ToString();
        trackPoints = new Score();
    }

    void Update()
    {
        float rotX = Input.GetAxis("Mouse X") * 20 * Mathf.Deg2Rad;
        transform.Rotate(Vector3.forward, rotX);


        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            if (Counter % 2 == 0)
                Shoot(L_Barrel, Ammo);
            else
                Shoot(R_Barrel, Ammo);

            Counter++;
        }

        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown("q"))
        {
            if (Ammo == "Prefab/Rubber Bullet") Ammo = "Prefab/Bullet";
            else Ammo = "Prefab/Rubber Bullet";
        }

    }
   

    private void Shoot(GameObject Barrel, string bulletType)
    {
      
        GameObject clone = Instantiate(Resources.Load(bulletType), Barrel.transform.position, this.transform.rotation) as GameObject;

        clone.transform.Rotate(Vector3.left * -90);
        Rigidbody bulletBody = clone.GetComponent<Rigidbody>();
        Vector3 incrAngle = new Vector3(0, .15f, 0);
        Vector3 spread = new Vector3(randValue(), randValue(), randValue());
        bulletBody.AddForce((-transform.up + incrAngle + spread) * 7000);
        Destroy(clone, 3.5f);
    }

    private float randValue()
    {
        return Random.Range(-0.04f, .04f);
    }

}




