using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    // บันทึกข้อมูล Inventory
    public static void SaveInventory()
    {
        List<string> items = InventoryManager.Instance.GetItems();
        PlayerPrefs.SetInt("ItemCount", items.Count); // บันทึกจำนวนไอเท็ม
        for (int i = 0; i < items.Count; i++)
        {
            PlayerPrefs.SetString("Item_" + i, items[i]); // บันทึกไอเท็มแต่ละชิ้น
        }
        PlayerPrefs.Save();
        Debug.Log("Inventory Saved");
    }

    // โหลดข้อมูล Inventory
    public static void LoadInventory()
    {
        InventoryManager.Instance.GetItems().Clear();
        int itemCount = PlayerPrefs.GetInt("ItemCount", 0);
        for (int i = 0; i < itemCount; i++)
        {
            string itemName = PlayerPrefs.GetString("Item_" + i, "");
            if (!string.IsNullOrEmpty(itemName))
            {
                InventoryManager.HasKey = true;
            }
        }
        Debug.Log("Inventory Loaded");
    }
}
