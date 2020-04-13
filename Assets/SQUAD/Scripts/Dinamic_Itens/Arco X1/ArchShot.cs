﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchShot : MonoBehaviour
{
    public int ID;
    public ArchController AC;

    private void OnTriggerEnter(Collider other)

    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }

        if(ID == 1 && other.gameObject.name == "Player2")
        {
            AC.P1_Points++;
            this.gameObject.SetActive(false);
            return;
        }

        if (ID == 2 && other.gameObject.name == "Player1")
        {
            AC.P2_Points++;
            this.gameObject.SetActive(false);
            return;
        }
    }
}
