using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed at which the enemy moves towards the player

    public EnemyRangedAttack enemyRangedAttack; // Reference to the EnemyRangedAttack script

    public bool canMove = true; // Flag to control whether the enemy can move
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRangedAttack = GetComponent<EnemyRangedAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayerPosition();
    }

    public void MoveTowardsPlayerPosition()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, enemyRangedAttack.player.transform.position);

        // Check if the player is detected and within attack range
        if (enemyRangedAttack.playerDetected && canMove)
        {
            // Move towards the player's position
            Vector3 direction = (enemyRangedAttack.player.transform.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
            if(distanceToPlayer < enemyRangedAttack.attackRange - 2)
            {
                canMove = false;
            }
            
        }
        if (distanceToPlayer > enemyRangedAttack.attackRange + 1)
        {
            canMove = true;
        }
    }
}
