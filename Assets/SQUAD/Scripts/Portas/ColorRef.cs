using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRef : MonoBehaviour
{
    public Porta_Color P;

    public bool ColorPlayer; //true = Player 1, false = Player 2

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player1" && ColorPlayer)
        {
            P.P1_ColorA = true;
           
        }

        if (other.gameObject.name == "Player2" && ColorPlayer == false)
        {
            P.P2_ColorB = true;
            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1" && ColorPlayer)
        {
            P.P1_ColorA = false;
            P.LastChance = true;
        }

        if (other.gameObject.name == "Player2" && ColorPlayer == false)
        {
            P.P2_ColorB = false;
            P.LastChance = true;
        }
    }

}
