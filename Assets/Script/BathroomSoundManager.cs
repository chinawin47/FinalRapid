using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSound : MonoBehaviour
{
    public AudioSource audioSource;     // Audio Source ที่จะเล่นเสียง
    public AudioClip switchSound;       // เสียงของสวิตช์

    private void OnMouseDown()
    {
        if (audioSource != null && switchSound != null)
        {
            audioSource.PlayOneShot(switchSound); // เล่นเสียงเมื่อกด
        }
        else
        {
            Debug.LogWarning("Audio Source หรือ Audio Clip ไม่ได้ตั้งค่าใน Inspector");
        }
    }
}


