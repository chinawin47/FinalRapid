using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : ItemBase
{
    public string targetSceneName; // ชื่อ Scene ที่จะย้ายไป
    public GameObject player;      // อ้างอิงถึง Player

    public override void Interact()
    {
        Debug.Log("Opening the door: " + itemName);

        if (!string.IsNullOrEmpty(targetSceneName) && player != null)
        {
            // บันทึกตำแหน่ง Player และย้าย Scene
            player.GetComponent<SavePlayerPosition>().SavePositionAndMoveScene(targetSceneName);
        }
        else
        {
            Debug.LogWarning("Target scene name or player reference is missing!");
        }
    }
}
