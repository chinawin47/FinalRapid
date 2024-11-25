using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public string itemName; // ชื่อของไอเท็ม
    public string interactionMessage; // ข้อความเมื่อ interact

    // ฟังก์ชันสำหรับโต้ตอบ
    public virtual void Interact()
    {
        Debug.Log("Interacted with: " + itemName);
    }
}
