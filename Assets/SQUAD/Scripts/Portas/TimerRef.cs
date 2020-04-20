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
        if (other.gameObject.name == "Player1" && !P.Player && R.TimerComplete == false)
        {
            P.Player = true;
            P.PlayerInArea = other.gameObject;
            other.gameObject.GetComponent<Player>().playerWeapon.enabled = false;
            PlayerInt = 1;
        }

        if (other.gameObject.name == "Player2" && !P.Player && R.TimerComplete == false)
        {
            P.Player = true;
            P.PlayerInArea = other.gameObject;
            other.gameObject.GetComponent<Player>().playerWeapon.enabled = false;
            PlayerInt = 2;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1" && P.Player && PlayerInt != 2)
        {
            P.Player = false;
            PlayerInt = 0;
            other.gameObject.GetComponent<Player>().playerWeapon.enabled = true;
            P.LastChance = true;   
        }

        if (other.gameObject.name == "Player2" && P.Player && PlayerInt != 1)
        {
            P.Player = false;
            PlayerInt = 0;
            other.gameObject.GetComponent<Player>().playerWeapon.enabled = true;
            P.LastChance = true;  
        }
    }

}