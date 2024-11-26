using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName; // ชื่อ Scene ที่จะย้ายไป

    public void MoveToScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName); // ย้ายไปยัง Scene ที่ระบุ
        }
        else
        {
            Debug.LogError("Scene name is not set in the Inspector!");
        }
    }
}
