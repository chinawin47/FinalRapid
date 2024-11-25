using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // ชื่อของ Scene ที่ต้องการย้ายไป
    public string targetSceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่า GameObject ที่ชนคือ Player หรือไม่
        if (other.CompareTag("Player"))
        {
            // โหลด Scene ใหม่
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
