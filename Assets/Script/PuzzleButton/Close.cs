using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
    public GameObject panelToClose; // Panel ที่ต้องการปิด

    // ฟังก์ชันสำหรับปิด Panel
    public void ClosePanel()
    {
        if (panelToClose != null)
        {
            panelToClose.SetActive(false); // ปิด Panel
        }
        else
        {
            Debug.LogWarning("Panel to close is not assigned in the Inspector!");
        }
    }
}
