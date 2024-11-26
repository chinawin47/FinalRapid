using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // ทำให้ระบบ Inventory เป็น Singleton

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

    // เพิ่มไอเท็มเข้า Inventory
    public void AddItem(string itemName)
    {
        if (!playerItems.Contains(itemName))
        {
            playerItems.Add(itemName);
            Debug.Log("Item Added: " + itemName);
        }
    }

    // ตรวจสอบว่า Player มีไอเท็มนี้หรือไม่
    public bool HasItem(string itemName)
    {
        return playerItems.Contains(itemName);
    }

    // รับรายการไอเท็มทั้งหมด
    public List<string> GetItems()
    {
        return playerItems;
    }
}
