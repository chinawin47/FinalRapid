using UnityEngine;
using UnityEngine.SceneManagement;  // ใช้สำหรับเปลี่ยน Scene

public class CurtainInteraction : MonoBehaviour
{
    public AudioSource curtainSound;   // AudioSource สำหรับเสียงผ้าม่าน
    public string sceneToLoad;         // ชื่อ Scene ที่ต้องการเปลี่ยนไป

    private bool isCurtainOpen = false; // สถานะของผ้าม่าน (เปิด/ปิด)

    void OnMouseDown()
    {
        if (!isCurtainOpen)
        {
            OpenCurtain(); // เปิดผ้าม่านทันที
        }
    }

    private void OpenCurtain()
    {
        if (!isCurtainOpen)
        {
            isCurtainOpen = true;  // ตั้งสถานะเป็นเปิดผ้าม่าน

            // เล่นเสียงผ้าม่าน (หากมี)
            if (curtainSound != null)
            {
                curtainSound.Play();
            }

            // เปลี่ยนไปยัง Scene ที่กำหนดทันที
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}