using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePlayerPosition : MonoBehaviour
{
    public static Vector3 savedPosition; // ตำแหน่งที่บันทึกข้าม Scene
    private bool isPositionLoaded = false;

    void Start()
    {
        // โหลดตำแหน่งเมื่อกลับมายัง Scene เดิม
        if (!isPositionLoaded && savedPosition != Vector3.zero)
        {
            transform.position = savedPosition;
            isPositionLoaded = true;
        }
    }

    public void SavePositionAndMoveScene(string targetSceneName)
    {
        // บันทึกตำแหน่งปัจจุบันของ Player
        savedPosition = transform.position;

        // ย้ายไปยัง Scene ใหม่
        SceneManager.LoadScene(targetSceneName);
    }
}

