using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip[] AllSounds;
    public AudioSource GlobalMusic;

    public RoomMusic RM_atual;

    public bool Muted;

    private void Start()
    {
        if (Muted)
        {
            GlobalMusic.enabled = false;
        }
        else
        {
            GlobalMusic.enabled = true;
        }
    }


    public void SetGlobalMusic(AudioClip Sound, RoomMusic room)
    {

        if (RM_atual != null)
        {
            RM_atual.Muted();
        }

        RM_atual = room;

        GlobalMusic.volume = 0.07f;
        GlobalMusic.clip = Sound;
        GlobalMusic.Play();

    }

    public void RoomClean()
    {
        GlobalMusic.volume = 0.01f;
    }

    public void PlayerDead()
    {
        StartCoroutine("RePitch");
    }
    
    IEnumerator RePitch()
    {
        GlobalMusic.pitch = 0.4f;

        yield return new WaitForSeconds(2);
        GlobalMusic.pitch = 0.6f;

        yield return new WaitForSeconds(1);
        GlobalMusic.pitch = 0.8f;

        yield return new WaitForSeconds(1);
        GlobalMusic.pitch = 1f;
        GlobalMusic.volume = 0.07f;
    }

    public void AllPlayersDead()
    {
        GlobalMusic.pitch = 0.4f;
        GlobalMusic.volume = 0.01f;
    }

}
