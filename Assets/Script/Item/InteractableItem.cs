using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    private ItemBase interactableItem;

    void Update()
    {
        // ตรวจจับการกดปุ่ม E
        if (Input.GetKeyDown(KeyCode.E) && interactableItem != null)
        {
            interactableItem.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่าชนวัตถุที่เป็น ItemBase
        if (other.TryGetComponent<ItemBase>(out ItemBase item))
        {
            interactableItem = item;
            Debug.Log("Press E to interact with: " + item.itemName);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // ออกจากระยะของ Item
        if (other.GetComponent<ItemBase>() != null)
        {
            interactableItem = null;
        }
    }
}
