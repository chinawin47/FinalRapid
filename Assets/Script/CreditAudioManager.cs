using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    

    public AudioClip background;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}
