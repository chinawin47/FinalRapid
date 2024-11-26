using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMG : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SaveLoadSystem.SaveInventory(); // บันทึก Inventory
        SceneManager.LoadScene(sceneName); // ย้าย Scene
    }

    private void Start()
    {
        SaveLoadSystem.LoadInventory(); // โหลด Inventory เมื่อเริ่ม Scene
    }
}
