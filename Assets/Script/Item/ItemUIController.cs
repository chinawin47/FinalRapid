using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUIController : MonoBehaviour
{
    public GameObject itemUIPanel; // อ้างอิงไปยัง Panel UI
    private bool isPlayerNearby = false; // ตรวจสอบว่าผู้เล่นอยู่ใกล้ Item หรือไม่

    private void Start()
    {
        if (itemUIPanel != null)
        {
            itemUIPanel.SetActive(false); // ซ่อน Panel ในตอนเริ่มเกม
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่าผู้เล่นเข้าใกล้ Item
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // ตรวจสอบว่าผู้เล่นออกห่างจาก Item
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (itemUIPanel != null)
            {
                itemUIPanel.SetActive(false); // ซ่อน UI เมื่อผู้เล่นออกจากระยะ
            }
        }
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (itemUIPanel != null)
            {
                bool isActive = itemUIPanel.activeSelf;
                itemUIPanel.SetActive(!isActive); // เปิด/ปิด UI Panel
            }
        }
    }

}
