using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public Transform player;  // Reference to the player's Transform
    public float moveSpeed = 2f;  // Speed at which the enemy moves
    public float followDistance = 5f;  // Distance within which the enemy will start following
    public float stopDistance = 1f;   // Distance at which the enemy stops following the player
    public float followDelay = 1f;    // Delay before following the player

    private Animator animator;  // Reference to the Animator component
    private AudioSource audioSource;  // Reference to the AudioSource component
    private bool isFollowing = false; // Tracks if the enemy is currently following
    private Vector3 initialPosition;  // The enemy's starting position

    private void Start()
    {
        // Get the Animator and AudioSource components
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        // Save the initial position
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (player != null && !isFollowing)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer <= followDistance && distanceToPlayer > stopDistance)
            {
                StartCoroutine(FollowWithDelay());
            }
            else
            {
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
        isFollowing = true;
        yield return new WaitForSeconds(followDelay);

        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play(); // Play the chasing sound
        }

        while (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer <= followDistance && distanceToPlayer > stopDistance)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

                animator.SetBool("isWalking", true);

                if (direction.x > 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            else
            {
                animator.SetBool("isWalking", false);
                isFollowing = false;

                if (audioSource != null && audioSource.isPlaying)
                {
                    audioSource.Stop(); // Stop the chasing sound
                }

                yield break;
            }

            yield return null;
        }

        isFollowing = false;

        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    private void ReturnToInitialPosition()
    {
        if (Vector2.Distance(transform.position, initialPosition) > 0.1f)
        {
            Vector2 direction = (initialPosition - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, initialPosition, moveSpeed * Time.deltaTime);

            animator.SetBool("isWalking", true);

            if (direction.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
