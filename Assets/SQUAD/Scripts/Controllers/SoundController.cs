using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip[] AllSounds;
    public AudioSource GlobalMusic;

    public RoomMusic RM_atual;

    private void Start()
    {

    }


    public void SetGlobalMusic(AudioClip Sound, RoomMusic room)
    {

        if (RM_atual != null)
        {
            RM_atual.Muted();
        }

        RM_atual = room;

        GlobalMusic.volume = 0.15f;
        GlobalMusic.clip = Sound;
        GlobalMusic.Play();

    }

    public void RoomClean()
    {
        GlobalMusic.volume = 0.01f;
    }

    

}
