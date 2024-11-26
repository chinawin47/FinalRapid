using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemTextController : MonoBehaviour
{
    public string message = "Press E to interact"; // ข้อความที่จะแสดง
    public TextMeshProUGUI textUI;                // อ้างอิงถึง Text UI
    private bool isPlayerNearby = false;          // ตรวจสอบว่าผู้เล่นอยู่ใกล้ Item หรือไม่

    private void Start()
    {
        if (textUI != null)
        {
            textUI.gameObject.SetActive(false); // ซ่อนข้อความในตอนเริ่มเกม
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && textUI != null)
        {
            textUI.gameObject.SetActive(true);  // แสดงข้อความ
            textUI.text = message;             // ตั้งค่าข้อความ
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && textUI != null)
        {
            textUI.gameObject.SetActive(false); // ซ่อนข้อความเมื่อผู้เล่นออกจากระยะ
            isPlayerNearby = false;
        }
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interacting with item!");
            // ใส่โค้ดเพิ่มเติมสำหรับการโต้ตอบกับ Item ได้ที่นี่
        }
    }
}
