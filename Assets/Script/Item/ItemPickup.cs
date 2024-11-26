using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string itemName; // ชื่อไอเท็มที่เก็บ

    private void OnMouseDown()
    {
        // เพิ่มไอเท็มเข้า Inventory
        InventoryManager.Instance.AddItem(itemName);

        // ลบไอเท็มออกจากฉาก
        Destroy(gameObject);
    }
}
