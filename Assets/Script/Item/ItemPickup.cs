using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string HasKey; // ชื่อไอเท็มที่เก็บ
    public AudioClip pickupSound; // เสียงเมื่อเก็บไอเท็ม

    private void OnMouseDown()
    {
        // เพิ่มไอเท็มเข้า Inventory
        InventoryManager.HasKey = true; // ตั้งค่าสถานะว่ามีกุญแจ

        // เล่นเสียงเมื่อเก็บไอเท็ม
        if (pickupSound != null)
        {
            // สร้าง GameObject ใหม่สำหรับเล่นเสียง
            GameObject audioObject = new GameObject("PickupSound");
            AudioSource audioSource = audioObject.AddComponent<AudioSource>();
            audioSource.clip = pickupSound;
            audioSource.Play();

            // ทำลาย GameObject หลังเสียงเล่นจบ
            Destroy(audioObject, pickupSound.length);
        }

        // ลบไอเท็มออกจากฉาก
        Destroy(gameObject); // ลบวัตถุทันที
    }
}
