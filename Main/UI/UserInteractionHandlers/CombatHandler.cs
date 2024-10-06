using UnityEngine;

public class CombatHandler : MonoBehaviour
{
    // Reference to the player's Health component
    public Health playerHealth;

    // Reference to the enemy's Health component
    public Health enemyHealth;

    // The color that represents a hit to the enemy (set dynamically based on level)
    private string enemyHitColor;

    // Method to handle combat input based on color
    public void HandleCombatInput(string color)
    {
        // Check if the input color matches the enemy hit color
        if (color == enemyHitColor)
        {
            // Decrease enemy's health
            if (enemyHealth != null && enemyHealth.IsAlive)
            {
                enemyHealth.Decrement();
                Debug.Log("Enemy hit! Decreasing enemy health.");
            }
            else
            {
                Debug.LogWarning("Enemy is either dead or enemyHealth is not assigned.");
            }
        }
        else
        {
            // Decrease player's health
            if (playerHealth != null && playerHealth.IsAlive)
            {
                playerHealth.Decrement();
                Debug.Log("Player hit! Decreasing player health.");
            }
            else
            {
                Debug.LogWarning("Player is either dead or playerHealth is not assigned.");
            }
        }

        // Check if either the player or enemy's health has reached zero
        if (!playerHealth.IsAlive)
        {
            Debug.Log("Player is dead.");
        }

        if (!enemyHealth.IsAlive)
        {
            Debug.Log("Enemy is dead.");
        }
    }

    // Method to update the enemy hit color based on the level
    public void UpdateEnemyHitColor(int level)
    {
        switch (level)
        {
            case 1:
                enemyHitColor = "purple";  // Enemy hit color for level 1
                break;
            case 2:
                enemyHitColor = "orange";  // Enemy hit color for level 2
                break;
            case 3:
                enemyHitColor = "cyan";    // Enemy hit color for level 3
                break;
            case 4:
                enemyHitColor = "magenta"; // Enemy hit color for level 4
                break;
            default:
                enemyHitColor = "purple";  // Default to purple if level is out of bounds
                break;
        }

        Debug.Log("Enemy hit color updated to: " + enemyHitColor);
    }
}
