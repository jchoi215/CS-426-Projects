using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

// source tutorial: https://www.youtube.com/watch?v=a916_lhps04

public class PlayerHealth : MonoBehaviour {

    public int initialHealth = 100; // needs to vary by class
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip damageClip;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    //Animator anim;
    AudioSource playerAudio;
    //PlayerMovement playerMovement;
    //PlayerShooting playerShooting;
    bool isDead = false;
    bool damaged;

    RigidbodyFirstPersonController rigidbodyFirestPersonController;
    PlayerStamina playerStamina;
    PlayerHunger playerHunger;
    public GameObject DeathMessage;

    void Awake()
    {
        rigidbodyFirestPersonController = GetComponent<RigidbodyFirstPersonController>();
        playerStamina = GetComponent<PlayerStamina>();
        playerHunger = GetComponent<PlayerHunger>();
        //playerAudio.clip = damageClip;
    }

    void Start()
    {
        // reassign max health based on class values
        currentHealth = initialHealth;
        updateHealth();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.name == "Water")
        {
            damageImage.color = flashColor;
            damageHealth(1);
        }
    }

    void Update()
    {
        if(damaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;

        if (Input.GetKeyDown(KeyCode.B)) // TESTING PURPOSES
        {
            damageHealth(10);
        }
    }

    public void restoreHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > 100) { currentHealth = 100; }
    }

    public void damageHealth(int amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        DeathMessage.SetActive(true);
        rigidbodyFirestPersonController.enabled = false;
        playerStamina.enabled = false;
        playerHunger.endHunger();
        playerHunger.enabled = false;

        //playerAudio.Play();
        //anim.SetTrigger("Die");
        //playerMovement.enabled = false;
    }

    public void damageHealth(string state)
    {
        switch(state)
        {
            case "Cancel":
                CancelInvoke();
                break;
            case "Starvation":
                InvokeRepeating("damageHealth_Starvation", 1, 1);
                break;
        }
    }

                    /* Player States */
    /* the assigned values are just default placeholders */

    // Player: Starving
    void damageHealth_Starvation()
    {
        currentHealth -= 1;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    // Player: Eating
    void restoreHealth_Eating()
    {
        currentHealth += 50;
        healthSlider.value = currentHealth;
        if (currentHealth > 100) { currentHealth = 100; }
    }
    public void updateHealth()
    {
        healthSlider.value = currentHealth;
    }

}
