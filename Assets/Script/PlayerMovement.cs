using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player's movement
    private Rigidbody2D rb;
    private Animator animator; // Reference to the Animator
    private Vector2 movement;
    AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    void Update()
    {
        // Get horizontal input (A/D or Left/Right arrows)
        float moveInput = Input.GetAxis("Horizontal");

        // Set movement direction
        movement = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip the player's sprite based on direction
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1); // Facing right
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1); // Facing left

        // Update the isWalking animation parameter
        animator.SetBool("isWalking", moveInput != 0);

        if (moveInput !=0) // ถ้าเดินเสียงจะออก
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    void FixedUpdate()
    {
        // Move the player
        rb.velocity = movement;
    }
}
