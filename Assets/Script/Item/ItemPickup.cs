using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string HasKey; // ชื่อไอเท็มที่เก็บ

    private void OnMouseDown()
    {
        // เพิ่มไอเท็มเข้า Inventory
        InventoryManager.HasKey = true; // ตั้งค่าสถานะว่ามีกุญแจ

        // ลบไอเท็มออกจากฉาก
        Destroy(gameObject);
    }
}
