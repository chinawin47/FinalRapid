using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // ทำให้ระบบ Inventory เป็น Singleton
    public static bool HasKey = false; // ตัวแปรสำหรับเก็บสถานะกุญแจ
    private List<string> playerItems = new List<string>(); // รายการไอเท็มที่เก็บไว้

    private void Awake()
    {
        // Singleton Pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // รักษา GameObject ไว้ขณะเปลี่ยน Scene
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // รับรายการไอเท็มทั้งหมด
    public List<string> GetItems()
    {
        return playerItems;
    }
}
