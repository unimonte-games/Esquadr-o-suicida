using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExit : MonoBehaviour
{
    public EnemyStats ES;
    public EnemyPatrol EP;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1" && ES.Player1_inArea)
        {
            
            ES.PlayerInArea = false;
            ES.Player1_inArea = false;

            ES.OnPatrol();

            Debug.Log("Player 1 Fugiu!");
        }


        if (other.gameObject.name == "Player2" && ES.Player2_inArea)
        {
            
            ES.PlayerInArea = false;
            ES.Player2_inArea = false;

            ES.OnPatrol();

            Debug.Log("Player 2 Fugiu!");
        }
    }
}
