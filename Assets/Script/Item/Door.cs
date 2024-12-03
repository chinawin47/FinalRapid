using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : ItemBase
{
    public string targetSceneName; // ชื่อ Scene ที่จะย้ายไป
    public GameObject player;      // อ้างอิงถึง Player
    public AudioClip openDoorSound; // เสียงเมื่อเปิดประตู

    private AudioSource audioSource; // ตัวเล่นเสียง

    private void Start()
    {
        // เพิ่ม AudioSource ให้กับวัตถุถ้ายังไม่มี
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // ปิดการเล่นอัตโนมัติ
    }

    public override void Interact()
    {
        Debug.Log("Opening the door: " + itemName);

        if (!string.IsNullOrEmpty(targetSceneName) && player != null)
        {
            // เล่นเสียงเมื่อเปิดประตู
            if (openDoorSound != null)
            {
                audioSource.clip = openDoorSound;
                audioSource.Play();
            }

            // รอสักครู่ก่อนโหลดฉากใหม่ เพื่อให้เสียงเล่นเสร็จ
            StartCoroutine(LoadSceneAfterDelay(openDoorSound.length));
        }
        else
        {
            Debug.LogWarning("Target scene name or player reference is missing!");
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // รอให้เสียงเล่นเสร็จ
        SceneManager.LoadScene(targetSceneName); // โหลด Scene ใหม่
    }
}

