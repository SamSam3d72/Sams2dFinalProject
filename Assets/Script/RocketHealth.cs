using UnityEngine;
using UnityEngine.UI;

public class RocketHealth : MonoBehaviour
{
    // The maximum health of the Rocket
    public int maxHealth = 100;

    // The current health of the Rocket
    private int currentHealth;

    // Reference to the health bar UI element
    public Slider healthBar;

    void Start()
    {
        // Initialize the current health to the maximum health
        currentHealth = maxHealth;

        // Update the health bar UI
        UpdateHealthBar();
    }

    // Method to reduce the Rocket's health
    public void TakeDamage(int damage)
    {
        // Subtract the damage from the current health
        currentHealth -= damage;

        // Update the health bar UI
        UpdateHealthBar();

        // Check if the Rocket has run out of health
        if (currentHealth <= 0)
        {
            // Call the Die method to handle the Rocket's death
            Die();
        }
    }

    // Method to update the health bar UI
    void UpdateHealthBar()
    {
        // Calculate the health percentage (0-1)
        float healthPercentage = (float)currentHealth / maxHealth;

        // Set the value of the health bar UI to the health percentage
        healthBar.value = healthPercentage;
    }

    // Method to handle the Rocket's death
    void Die()
    {
        // TODO: Add death logic here, such as game over, respawn, etc.
        Debug.Log("Rocket has died!");
    }
}
