using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMusic : MonoBehaviour
{
    SoundController SC;
    public AudioSource[] RoomList;
    int randomNumber;
    public int MusicStep_min;
    public int MusicStep_max;

    void Start()
    {
        SC = FindObjectOfType<SoundController>();

        for (int i = 0; i < 15; i++)
        {
            randomNumber = Random.Range(MusicStep_min, MusicStep_max);
            RoomList[i] = SC.AllSounds[randomNumber];

        }

    }

}
