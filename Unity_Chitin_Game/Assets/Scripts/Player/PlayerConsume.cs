using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConsume : MonoBehaviour
{
    PlayerStamina ps;
    PlayerHealth ph;
    PlayerHunger phu;
    // Use this for initialization
    void Start()
    {
        ph = GetComponent<PlayerHealth>();
        ps = GetComponent<PlayerStamina>();
        phu = GetComponent<PlayerHunger>();
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("playerResource"))
        {

            if (ps.currentStamina <= 50)
                ps.currentStamina += 50;
            else
                ps.currentStamina = 100;

            if (ph.currentHealth <= 70)
                ph.currentHealth += 30;
            else
                ph.currentHealth = 100;

            if (phu.currentHunger <= 700)
                phu.currentHunger += 300;
            else
                phu.currentHunger = 1000;

            GameObject.Find("PlayerController(Clone)").GetComponent<PlayerHealth>().updateHealth();
            GameObject.Find("PlayerController(Clone)").GetComponent<PlayerScore>().updateScore();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
