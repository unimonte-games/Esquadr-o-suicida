using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMusic : MonoBehaviour
{
    SoundController SC;
    public AudioClip[] RoomList;

    int n;
    public int MusicStep_min;
    public int MusicStep_max;
    int Music;
    int TotalMusic;
    public int TimeToNext;

    void Start()
    {
        SC = FindObjectOfType<SoundController>();

        for (int i = MusicStep_min; i < MusicStep_max; i++)
        {
            RoomList[n] = SC.AllSounds[i];
            n++;
        }

        TotalMusic = MusicStep_max - MusicStep_min;

    }

    public void StartMusicInRoom()
    {
        InvokeRepeating("ChangeMusic", 0, TimeToNext);
    }

    public void ChangeMusic()
    {
        Music = Random.Range(0, TotalMusic);
        SC.SetGlobalMusic(RoomList[Music], this);
        
    }

    public void VolumeOff()
    {
        CancelInvoke("ChangeMusic");
        SC.RoomClean();
    }

    public void Muted ()
    {
        CancelInvoke("ChangeMusic");
    }

}
