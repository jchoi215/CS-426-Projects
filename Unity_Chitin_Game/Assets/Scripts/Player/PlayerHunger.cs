using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class PlayerHunger : MonoBehaviour
{

    public int initialHunger = 1000;
    public float currentHunger;
    public Slider hungerSlider;

    PlayerHealth playerHealth;
    PlayerStamina playerStamina;
    bool starving = false;
    bool idle = false;

    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerStamina = GetComponent<PlayerStamina>();
    }

    void Start()
    {
        currentHunger = initialHunger;
        InvokeRepeating("depleteHunger_Standard", 1, 1);
        currentHunger -= 500;
    }

    void Update()
    {
        hungerSlider.value = currentHunger;

        if (currentHunger <= 0 && starving == false)
        {
            CancelInvoke("depleteHunger_Standard");
            playerHealth.damageHealth("Starvation");
            currentHunger = 0;
            starving = true;
        }
        if (currentHunger > 0 && starving == true)
        {
            playerHealth.damageHealth("Cancel");
            InvokeRepeating("depleteHunger_Standard", 10, 1); // 10 second wait before depletion resumes
            starving = false;
        }

        if (Input.GetKey(KeyCode.LeftShift) && playerStamina.getCurrentStamina() > 0)
        {
            depleteHunger_Sprint();
        }

        if (Input.GetKeyDown(KeyCode.Space) && playerStamina.getCurrentStamina() > 0) 
        {
            depleteHunger_Jump();
        }

        if (!idle &&
            !Input.GetKey(KeyCode.W) &&
            !Input.GetKey(KeyCode.A) &&
            !Input.GetKey(KeyCode.S) &&
            !Input.GetKey(KeyCode.D) &&
            !Input.GetKey(KeyCode.LeftShift) &&
            !Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke("depleteHunger_Standard");
            InvokeRepeating("depleteHunger_Idle", 1, 1);
            idle = true;
        }
        else if(
            idle && 
            ( Input.GetKey(KeyCode.W) ||
              Input.GetKey(KeyCode.A) ||
              Input.GetKey(KeyCode.S) ||
              Input.GetKey(KeyCode.D) ||
              Input.GetKey(KeyCode.LeftShift) ||
              Input.GetKeyDown(KeyCode.Space))  )
        {
            CancelInvoke("depleteHunger_Idle");
            InvokeRepeating("depleteHunger_Standard", 1, 1);
            idle = false;
        }

        if (Input.GetKeyDown(KeyCode.F)) // TESTING PURPOSES
        {
            restoreHunger(100);
        }
        if (Input.GetKeyDown(KeyCode.G)) // TESTING PURPOSES
        {
            depleteHunger(100);
        }
    }


    public void restoreHunger(int value)
    {
        currentHunger += value;
        if (currentHunger >= 1000) { currentHunger = 1000; }
    }

    public void depleteHunger(int value)
    {
        currentHunger -= value;
        if (currentHunger <= 0) { currentHunger = 0; }
    }
    public void endHunger()
    {
        CancelInvoke();
    }


                     /* Player States */
    /* the depletion values are just default placeholders */

    // Player: Idle
    public void depleteHunger_Idle()
    {
        currentHunger -= 1.0f;
        if (currentHunger <= 0) { currentHunger = 0; }
    }

    // Player: Standard
    public void depleteHunger_Standard()
    {
        currentHunger -= 5.0f;
        if (currentHunger <= 0) { currentHunger = 0; }
    }

    // Player: Sprinting
    public void depleteHunger_Sprint()
    {
        currentHunger -= 0.1f;
        if (currentHunger <= 0) { currentHunger = 0; }
    }

    // Player: Attacking
    public void depleteHunger_Attack()
    {
        currentHunger -= 20;
        if (currentHunger <= 0) { currentHunger = 0; }
    }

    // Player: Jumping
    public void depleteHunger_Jump()
    {
        if (!GameObject.Find("PlayerController(Clone)").GetComponent<RigidbodyFirstPersonController>().m_Jumping)
            currentHunger -= 5;
        if (currentHunger <= 0) { currentHunger = 0; }
    }

    /* this, specifically, will need to vary between classes and their abilites */
    public void depleteHunger_Special()
    {
        currentHunger -= 50;
        if (currentHunger <= 0) { currentHunger = 0; }
    }

}