using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerRef : MonoBehaviour
{

    public Porta_Timer P;
    public RoomController R;
    public int PlayerInt;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1" && P.Player == false && R.TimerComplete == false)
        {
            P.Player = true;
            PlayerInt = 1;
        }

        if (other.gameObject.name == "Player2" && P.Player == false && R.TimerComplete == false)
        {
            P.Player = true;
            PlayerInt = 2;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1" && P.Player && PlayerInt != 2)
        {
            P.Player = false;
            PlayerInt = 0;
            P.LastChance = true;
           
        }

        if (other.gameObject.name == "Player2" && P.Player && PlayerInt != 1)
        {
            P.Player = false;
            PlayerInt = 0;
            P.LastChance = true;
            
        }
    }

}