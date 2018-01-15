using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public static PlayerHealth playerInstance;
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    [SerializeField] float currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    public float CurrentPlayerHealth {
        get { return this.currentHealth; }
        set { this.currentHealth = value;  }
    }

    EnemyHealth enemyHealth;
    GameObject enemy;
    PlayerController playerController;

    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.

	// Use this for initialization
	void Awake () {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyHealth = enemy.GetComponent<EnemyHealth>();
        playerController = GetComponent<PlayerController>();
        currentHealth = startingHealth;
        playerInstance = this;
	}
	
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyWeapon")
        {
            EnemyAttack();
        } 
      
    }

    public void AddHealth() {
        currentHealth += 10;
        UpdateHealthSlider();
    }

	// Update is called once per frame
	void Update () {
        // If the player has just been damaged...
        if (damaged == true)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;

    }

    public void TakeDamage (int attackAmount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= attackAmount;

        // Set the health bar's value to the current health.
        UpdateHealthSlider();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if(currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death ();
        }
    }

    void EnemyAttack()
    {
        if (currentHealth > 0)
        {
            TakeDamage(enemyHealth.attackDamage);
        }
    }


    public void Death ()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;
        playerController.onSpawn();
        currentHealth = startingHealth / 2;
        UpdateHealthSlider();


    }
    public void showHealth() {
        if(currentHealth <= 0f) {
            return;
        }
    }

    public void UpdateHealthSlider(){
        healthSlider.value = currentHealth;
    }

}
