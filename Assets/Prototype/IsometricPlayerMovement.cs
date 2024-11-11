using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Player's movement speed
    private Rigidbody rb; // Reference to Rigidbody

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Get the horizontal and vertical input (WASD or arrow keys)
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate movement direction in world space
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // If there is input, move the player
        if (moveDirection.magnitude >= 0.1f)
        {
            // Move the player in the direction
            rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);
        }
    }
}
