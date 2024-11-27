using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public Transform player;  // Reference to the player's Transform
    public float moveSpeed = 2f;  // Speed at which the enemy moves
    public float followDistance = 5f;  // Distance within which the enemy will start following
    public float stopDistance = 1f;   // Distance at which the enemy stops following the player

    private void Update()
    {
        // Check if player reference is assigned
        if (player != null)
        {
            // Calculate the distance between the player and the enemy
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // If the player is within the follow distance
            if (distanceToPlayer <= followDistance && distanceToPlayer > stopDistance)
            {
                // Move the enemy towards the player
                Vector2 direction = (player.position - transform.position).normalized;
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

                // Flip the enemy's sprite based on the direction (optional for visual effect)
                if (direction.x > 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);  // Face right
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1); // Face left
                }
            }
        }
    }
}
