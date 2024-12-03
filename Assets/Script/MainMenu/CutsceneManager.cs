using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;   // อ้างอิงถึง Video Player
    public string DreamScene;      // ชื่อ Scene ถัดไป

    void Start()
    {
        // ตรวจสอบเมื่อวิดีโอเล่นจบ
        videoPlayer.loopPointReached += OnVideoEnd;

        // เริ่มเล่นวิดีโอ
        videoPlayer.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // เปลี่ยนไปยัง Scene ถัดไปเมื่อวิดีโอเล่นจบ
        SceneManager.LoadScene(DreamScene);
    }
}
