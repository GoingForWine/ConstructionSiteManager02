using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumeControl : MonoBehaviour
{
    // Reference to Audio Source componenet
    private AudioSource audioSrc;
    // Music volume variable that can be modified with slider
    private float musicVolume = 1f;

    void Start()
    {
        // Assigning Audio Source component
        audioSrc = GetComponent<AudioSource>();
    }
    void Update()
    {
        // Setting volume option of Audio Source to be equal to musicVolume
        audioSrc.volume = musicVolume;
    }

    public void SetVolume (float vol)
    {
        musicVolume = vol;
    }
}
