using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleRef : MonoBehaviour
{
    public Porta_Double D;

    LevelController LC;

    private void Start()
    {
        LC = FindObjectOfType<LevelController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1" && LC.SoloPlayer && !LC.P2_inRoom)
        {
            D.P1_ColorA = true;
            D.P2_ColorB = true;
            return;
        }

        if (other.gameObject.name == "Player2" && LC.SoloPlayer && !LC.P1_inRoom)
        {
            D.P1_ColorA = true;
            D.P2_ColorB = true;
            return;
        }

        if (other.gameObject.name == "Player1" && !LC.SoloPlayer)
        {
            D.P1_ColorA = true;
            return;
        }

        if (other.gameObject.name == "Player2" && !LC.SoloPlayer)
        {
            D.P2_ColorB = true;
            return;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1")
        {
            D.P1_ColorA = false;
            D.LastChance = true;
        }

        if (other.gameObject.name == "Player2")
        {
            D.P2_ColorB = false;
            D.LastChance = true;
        }
    }
}
