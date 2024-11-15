using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public Transform player;          // Reference to the player's transform
    public float speed = 5f;          // Speed at which the enemy moves towards the player
    public float stoppingDistance = 2f; // Minimum distance to stop moving towards the player

void Start()
{
    // If the player reference is not assigned, find it by tag
    if (player == null)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}

    void Update()
    {
        // Check the distance between the enemy and the player
        float distance = Vector3.Distance(transform.position, player.position);

        // Move towards the player if beyond stopping distance
        if (distance > stoppingDistance)
        {
            // Make the enemy face the player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z)); // Optional to keep Y rotation fixed

            // Move the enemy towards the player
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
