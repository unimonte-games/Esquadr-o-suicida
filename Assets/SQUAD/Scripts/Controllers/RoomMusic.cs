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
    int Atual;
    public int TimeToNext;

    void Start()
    {
        SC = FindObjectOfType<SoundController>();

        for (int i = MusicStep_min; i < MusicStep_max; i++)
        {
            RoomList[n] = SC.AllSounds[i];
            n++;
        }

    }

    public void StartMusicInRoom()
    {
        InvokeRepeating("ChangeMusic", 0, TimeToNext);
    }

    public void ChangeMusic()
    {
        SC.SetGlobalMusic(RoomList[Atual], this);
        Atual++;

        if (Atual >= 5)
        {
            Atual = 0;
            Debug.Log("Voltou a Primeira");
        }
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
