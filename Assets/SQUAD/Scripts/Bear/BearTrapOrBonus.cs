using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapOrBonus : MonoBehaviour
{
    

    public BearDecision BD;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player1")
        {
            if(!BD.P1 && !BD.P2)//ngm ter aproximado
            {
                BD.P1 = true;
                BD.P = other.GetComponent<Player>();

                int LocalSorte = Random.Range(0, 100);

                if (LocalSorte <= 50)
                {
                    BD.Trap = true;
                }

                if (LocalSorte >= 51)
                {
                    BD.Bonus = true;
                }

            }

            if(!BD.P1 && BD.P2)//O Player 2 já se aproximou
            {
                BD.Gatilho = true;
            }
            
        }

        if (other.gameObject.name == "Player2")
        {
            if (!BD.P1 && !BD.P2)//ngm ter aproximado
            {
                BD.P2 = true;
                BD.P = other.GetComponent<Player>();

                int LocalSorte = Random.Range(0, 100);

                if (LocalSorte <= 70)
                {
                    BD.Trap = true;
                }

                if (LocalSorte >= 71)
                {
                    BD.Bonus = true;
                }

            }

            if (BD.P1 && !BD.P2)//O Player 1 já se aproximou
            {
                BD.Gatilho = true;
            }

        }

        
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.name == "Player1")
        {
            BD.Bonus = false;
            BD.Trap = false;
            BD.P1 = false;
            BD.P2 = false;
            BD.P = null;

        }

        if (other.gameObject.name == "Player2")
        {
            BD.Bonus = false;
            BD.Trap = false;
            BD.P1 = false;
            BD.P2 = false;
            BD.P = null;
        }

    }
}
