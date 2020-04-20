using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRef : MonoBehaviour
{
    public Porta_Color P;
    public bool ColorPlayer; //true = Player 1, false = Player 2

    LevelController LC;

    private void Start()
    {
        LC = FindObjectOfType<LevelController>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Obj" && LC.SoloPlayer && !LC.P1_inRoom && ColorPlayer) // se o jogador 1 n estiver
        {

            P.P1_ColorA = true;

        }
        if (other.gameObject.tag == "Obj" && LC.SoloPlayer && !LC.P2_inRoom && !ColorPlayer) // se o jogador 2 n estiver
        {

            P.P2_ColorB = true;

        }

        if(other.gameObject.name == "Player1" && ColorPlayer)
        {
            P.P1_ColorA = true;
            return;
        }

        if (other.gameObject.name == "Player2" && !ColorPlayer)
        {
            P.P2_ColorB = true;
            return;
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Obj" && LC.SoloPlayer)
        {
            if (!LC.P1_inRoom)
            {
                P.P1_ColorA = false;
                
            }

            if (!LC.P2_inRoom)
            {
                P.P2_ColorB = false;
                
            }
        }

        if (other.gameObject.name == "Player1" && ColorPlayer)
        {
            P.P1_ColorA = false;
            P.LastChance = true;
        }

        if (other.gameObject.name == "Player2" && !ColorPlayer)
        {
            P.P2_ColorB = false;
            P.LastChance = true;
        }
    }

}
