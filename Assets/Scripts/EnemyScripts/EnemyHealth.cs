using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce current health by damage amount
        if(currentHealth <= 0)
        {
            Die(); // Call Die method if health is zero or below
        }
    }

    public void Die()
    {
        Destroy(gameObject); // Destroy the enemy game object
    }
}
