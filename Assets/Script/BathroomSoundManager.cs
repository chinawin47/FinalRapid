using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSound : MonoBehaviour
{
    public AudioSource audioSource;     // Audio Source ����������§
    public AudioClip switchSound;       // ���§�ͧ��Ե��

    private void OnMouseDown()
    {
        if (audioSource != null && switchSound != null)
        {
            audioSource.PlayOneShot(switchSound); // ������§����͡�
        }
        else
        {
            Debug.LogWarning("Audio Source ���� Audio Clip ������駤��� Inspector");
        }
    }
}


