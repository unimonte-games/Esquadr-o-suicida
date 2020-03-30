using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoTeste : MonoBehaviour
{
    public bool Controller;
    public ObjetivoTeste OT;

    public int value;

    public bool Player1;
    public bool Player2;

    
    
    void Update()
    {
        if (Controller)
        {
            if(Player1 && Player2)
            {
                Debug.Log("Complete");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player1" && value == 1)
        {
            OT.Player1 = true;
        }
        if (other.gameObject.name == "Player2" && value == 2)
        {
            OT.Player2 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1" && value == 1)
        {
            OT.Player1 = false;
        }
        if (other.gameObject.name == "Player2" && value == 2)
        {
            OT.Player2 = false;
        }
    }
}
