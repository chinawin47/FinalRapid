using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public Transform player;  // Reference to the player's Transform
    public float moveSpeed = 2f;  // Speed at which the enemy moves
    public float followDistance = 5f;  // Distance within which the enemy will start following
    public float stopDistance = 1f;   // Distance at which the enemy stops following the player
    public float followDelay = 1f;    // Delay before following the player

    private Animator animator;  // Reference to the Animator component
    private bool isFollowing = false; // Tracks if the enemy is currently following
    private Vector3 initialPosition;  // The enemy's starting position

    private void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();

        // Save the initial position
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Check if player reference is assigned
        if (player != null && !isFollowing)
        {
            // Calculate the distance between the player and the enemy
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // If the player is within the follow distance and not already following
            if (distanceToPlayer <= followDistance && distanceToPlayer > stopDistance)
            {
                // Start following with a delay
                StartCoroutine(FollowWithDelay());
            }
            else
            {
                // Stop walking and return to original position
                animator.SetBool("isWalking", false);

                if (!isFollowing)
                {
                    ReturnToInitialPosition();
                }
            }
        }
    }

    private System.Collections.IEnumerator FollowWithDelay()
    {
        isFollowing = true; // Prevent multiple coroutine calls
        yield return new WaitForSeconds(followDelay); // Wait for the specified delay

        while (player != null)
        {
            // Calculate the distance between the player and the enemy
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // Follow the player if within follow distance but not too close
            if (distanceToPlayer <= followDistance && distanceToPlayer > stopDistance)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

                // Play walking animation
                animator.SetBool("isWalking", true);

                // Flip the enemy's sprite based on the direction
                if (direction.x > 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);  // Face right
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1); // Face left
                }
            }
            else
            {
                // Stop following if the player is out of range
                animator.SetBool("isWalking", false);
                isFollowing = false; // Allow the coroutine to restart later
                yield break; // Exit the coroutine
            }

            yield return null; // Wait for the next frame
        }

        // Reset following state if the player is null
        isFollowing = false;
    }

    private void ReturnToInitialPosition()
    {
        // Move the enemy back to its initial position if it's not already there
        if (Vector2.Distance(transform.position, initialPosition) > 0.1f)
        {
            // Move towards the initial position
            Vector2 direction = (initialPosition - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, initialPosition, moveSpeed * Time.deltaTime);

            // Play walking animation
            animator.SetBool("isWalking", true);

            // Flip the sprite based on the direction
            if (direction.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);  // Face right
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1); // Face left
            }
        }
        else
        {
            // Stop walking animation when at the initial position
            animator.SetBool("isWalking", false);
        }
    }
}
