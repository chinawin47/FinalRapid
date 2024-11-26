using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyChecker : MonoBehaviour
{
    private void Start()
    {
        // Check if the player has the key
        if (InventoryManager.HasKey)
        {
            Debug.Log("Player has the key. Destroying this object.");
            Destroy(gameObject); // Destroy the object this script is attached to
        }
        else
        {
            Debug.Log("Player does not have the key.");
        }
    }
}
