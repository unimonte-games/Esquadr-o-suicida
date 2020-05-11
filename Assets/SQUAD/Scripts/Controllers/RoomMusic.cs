using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMusic : MonoBehaviour
{
    SoundController SC;
    public AudioClip[] RoomList;
    int randomNumber;
    public int MusicStep_min;
    public int MusicStep_max;
    int Atual;

    void Start()
    {
        SC = FindObjectOfType<SoundController>();

        for (int i = 0; i < 5; i++)
        {
            randomNumber = Random.Range(MusicStep_min, MusicStep_max);
            RoomList[i] = SC.AllSounds[randomNumber];

        }

    }

    public void StartMusicInRoom()
    {
        SC.SetGlobalMusic(RoomList[Atual]);
       
    }

}
