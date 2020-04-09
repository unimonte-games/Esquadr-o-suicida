using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseAttack : MonoBehaviour
{
    public bool Player1;
    public bool Player2;

    public Porta_Default PD;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player1" && Player2)
        {
            PD.RescueComplete();
        }


        if (other.gameObject.name == "Player2" && Player1)
        {
            PD.RescueComplete();
        }
    }
}
