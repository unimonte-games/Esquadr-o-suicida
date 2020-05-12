﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip[] AllSounds;
    public AudioSource GlobalMusic;

    private void Start()
    {

    }


    public void SetGlobalMusic(AudioClip Sound)
    {
        GlobalMusic.volume = 0.15f;

        GlobalMusic.clip = Sound;
        GlobalMusic.Play();

        Debug.Log("Iniciando musica.");
    }

    public void RoomClean()
    {
        GlobalMusic.volume = 0.01f;
    }

}
