using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneToGame : MonoBehaviour
{
    public VideoPlayer videoPlayer;   // อ้างอิงถึง Video Player
    public string nextSceneName;      // ชื่อ Scene ถัดไป (หน้าเกม)

    void Start()
    {
        // ตรวจสอบเมื่อวิดีโอเล่นจบ
        videoPlayer.loopPointReached += OnVideoEnd;

        // เริ่มเล่นวิดีโอทันทีที่ Scene นี้เริ่มต้น
        videoPlayer.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // เปลี่ยนไปยัง Scene ถัดไปเมื่อวิดีโอเล่นจบ
        SceneManager.LoadScene(nextSceneName);
    }
}
