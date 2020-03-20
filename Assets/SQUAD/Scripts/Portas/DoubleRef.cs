using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleRef : MonoBehaviour
{
    public Porta_Double D;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1")
        {
            D.P1_ColorA = true;
        }

        if (other.gameObject.name == "Player2")
        {
            D.P2_ColorB = true;
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
