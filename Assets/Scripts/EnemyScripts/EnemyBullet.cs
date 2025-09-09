using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int damage = 10; // Damage dealt by the bullet

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject; // Get the object that was hit by the bullet


        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = hitObject.GetComponent<PlayerHealth>(); // Get the PlayerHealth component from the hit object
            playerHealth.TakeDamage(damage); // Call the TakeDamage method on the player's health component
            Debug.Log("Enemy bullet hit the player!");
            Destroy(gameObject); // Destroy the bullet after it hits the player
        }
        
    }
}
