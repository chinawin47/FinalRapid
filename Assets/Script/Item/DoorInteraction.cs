using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    public string targetSceneName;
    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Press Q to open the door.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Q))
        {
            if (InventoryManager.HasKey) // ตรวจสอบว่าผู้เล่นมีกุญแจหรือไม่
            {
                Debug.Log("Door opened!");
                SceneManager.LoadScene(targetSceneName); // ย้ายไปยัง Scene ใหม่
            }
            else
            {
                Debug.Log("You need a key to open this door.");
            }
        }
    }
}
