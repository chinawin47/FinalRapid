using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelelController : MonoBehaviour
{
    public Transform destination;
    GameObject player;
    GameObject enemy;
     
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger.");
            if (Vector3.Distance(player.transform.position, transform.position) > 0.3f)
            {
                player.transform.position = destination.position;
                Debug.Log("Player teleported to destination.");
            }
        }

        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemy entered the trigger.");
            if (Vector3.Distance(enemy.transform.position, transform.position) > 0.3f)
            {
                enemy.transform.position = destination.position;
                Debug.Log("Enemy teleported to destination.");
            }
        }
    }
}
