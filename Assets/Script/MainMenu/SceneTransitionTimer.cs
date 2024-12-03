using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionTimer : MonoBehaviour
{
    public float delayTime = 5f;   // ระยะเวลาที่จะรอก่อนเปลี่ยน Scene
    public string DreamScene;   // ชื่อ Scene ที่จะเปลี่ยนไป

    void Start()
    {
        // เรียกฟังก์ชันเปลี่ยน Scene หลังจาก delayTime วินาที
        Invoke("ChangeScene", delayTime);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(DreamScene);
    }
}
