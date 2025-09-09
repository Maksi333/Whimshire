using System.Collections;
using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    public float attackRange = 20f;
    public float attackCooldown =  2f;
    public float detectionRange = 30f;
    public float projectileSpeed = 20f; // Speed of the projectile
    public Vector3 projectileSpawnOffset = new Vector3(0, 1.5f, 1f); // Fine-tune to look like it's coming from a hand or weapon


    public GameObject projectilePrefab;
    public GameObject player;

    public bool playerDetected = false;
    public bool isOnCooldown = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Find the player object in the scene by its tag
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
        Attack();
    }


    public void DetectPlayer()
    {
        // Check if the player is within the detection range
        if (Vector3.Distance(transform.position, player.transform.position) <= detectionRange)
        {
            playerDetected = true;
            Debug.Log("Player detected within range: " + playerDetected);
        }
        else
        {
            playerDetected = false;
            
        }
    }

    void Attack()
    {
        if (!playerDetected || isOnCooldown)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < attackRange)
        {
            Vector3 spawnPosition = transform.position + transform.TransformDirection(projectileSpawnOffset); // Uses local space offset
            Vector3 direction = (player.transform.position - spawnPosition).normalized;

            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.LookRotation(direction));

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = false; // Optional
                rb.linearVelocity = direction * projectileSpeed;
            }

            isOnCooldown = true;
            StartCoroutine(AttackTimer());
        }
    }


    IEnumerator AttackTimer()
    {
        Debug.Log("Attack cooldown started for " + attackCooldown + " seconds.");
        yield return new WaitForSeconds(attackCooldown); // Wait for the attack cooldown duration
        isOnCooldown = false; // Set canAttack back to true after the cooldown
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a red sphere to visualize the attack range in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        // Draw a green sphere to visualize the detection range in the editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}

