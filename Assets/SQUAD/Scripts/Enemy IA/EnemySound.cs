﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    public AudioSource Sound;
    bool Player1;
    bool Player2;

    public bool Lata;
    public Enemy1_Attack EA;

    private void Start()
    {
        Sound.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player1" && !Player1)
        {
            CancelInvoke("CancelSound");

            Sound.volume = 0.03f;
            Sound.enabled = true;
            Player1 = true;

            if (Lata)
            {
                EA.isSoundInGosma = true;
            }
        }

        if (other.gameObject.name == "Player2" && !Player2)
        {
            CancelInvoke("CancelSound");

            Sound.volume = 0.03f;
            Sound.enabled = true;
            Player2 = true;

            if (Lata)
            {
                EA.isSoundInGosma = true;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1" && Player1)
        {
            Sound.volume = 0.01f;
            Invoke("CancelSound", 3);
            Player1 = false;

            if (Lata)
            {
                EA.isSoundInGosma = false;
            }
        }

        if (other.gameObject.name == "Player2" && Player2)
        {

            Sound.volume = 0.01f;
            Invoke("CancelSound", 3);
            Player2 = false;

            if (Lata)
            {
                EA.isSoundInGosma = false;
            }
        }
    }


    void CancelSound()
    {
        Sound.enabled = false;
    }
}
