using System.Collections;
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
        GlobalMusic.clip = Sound;
        GlobalMusic.Play();

        Debug.Log("Iniciando musica.");
    }

}
