using System.Collections;
using System.Xml.Serialization;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    public float lifeTime = 2f;
    public GameObject explosion;
    public AudioSource audioSource; // Audio source for the fireball sound effect
    public AudioClip fireballSound; // Sound effect for the fireball
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component from the fireball game object
        StartCoroutine(DestroyAndExplode(lifeTime)); // Start the coroutine to destroy the fireball after a certain time
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision != null)
        {
            GameObject explosionInstance = Instantiate(explosion, transform.position, transform.rotation); // Instantiate the explosion effect at the fireball's position and rotation
            GameObject hitObject = collision.gameObject; // Get the object that was hit by the fireball


            if (hitObject.tag == "Enemy")
            {
                EnemyHealth enemyHealth = hitObject.GetComponent<EnemyHealth>(); // Get the EnemyHealth component from the hit object
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(10); // Call the TakeDamage method on the enemy's health component
                }
            }
            AudioSource.PlayClipAtPoint(fireballSound, explosionInstance.transform.position); // Play the fireball sound effect at the fireball's position
            Destroy(explosionInstance, 2f); // Destroy the explosion effect after it has been instantiated
            Destroy(gameObject);
            
        }
        else
        {
            return; // If there is no collision, do nothing
        }
    }
    

    IEnumerator DestroyAndExplode(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject explosionInstance = Instantiate(explosion, transform.position, transform.rotation); // Instantiate the explosion effect at the fireball's position and rotation
        Destroy(explosionInstance, 2f); // Destroy the explosion effect after 2 seconds to clean up
        Destroy(gameObject); // Destroy the fireball
    }


}
