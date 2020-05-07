using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExit : MonoBehaviour
{
    public EnemyStats ES;
    public EnemyPatrol EP;

    public EnemyEnter EE;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 19)
        {
            PlayerDead PD = other.gameObject.GetComponent<PlayerDead>();
            if (PD.P1_dead && ES.Player1_inArea)
            {
                ES.Player1_inArea = false;
                ES.PlayerInArea = false;
                ES.PlayerTarget = null;
                EE.SC.enabled = false;
                Invoke("EnabledEnter", 1);

                Debug.Log("Player 1 morreu, ignorando.");
                ES.OnPatrol();
            }
            if (PD.P2_dead && ES.Player2_inArea)
            {
                ES.Player2_inArea = false;
                ES.PlayerInArea = false;
                ES.PlayerTarget = null;
                EE.SC.enabled = false;
                Invoke("EnabledEnter", 1);

                Debug.Log("Player 2 morreu, ignorando.");
                ES.OnPatrol();
            }
        }
    }

    void EnabledEnter()
    {
        EE.SC.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1" && ES.Player1_inArea && !ES.InTarget)
        {

            ES.PlayerInArea = false;
            ES.Player1_inArea = false;

            ES.OnPatrol();

            Debug.Log("Player 1 Fugiu!");
        }


        if (other.gameObject.name == "Player2" && ES.Player2_inArea && !ES.InTarget)
        {
           
            ES.PlayerInArea = false;
            ES.Player2_inArea = false;

            ES.OnPatrol();

            Debug.Log("Player 2 Fugiu!");
        }


        if(ES.InTarget && other.gameObject.name == ES.PlayerTarget.name)
        {
            ES.PlayerInArea = false;
            EP.ObjectHit();

            Debug.Log("Player Alvo muito longe");
        }

       
    }
}
