using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExit : MonoBehaviour
{
    public EnemyStats ES;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1" && ES.Player1_inArea)
        {
            ES.PlayerTarget = null;
            ES.PlayerInArea = false;
            ES.Player1_inArea = false;

            Debug.Log("Player 1 Fugiu!");
        }


        if (other.gameObject.name == "Player2" && ES.Player2_inArea)
        {
            ES.PlayerTarget = null;
            ES.PlayerInArea = false;
            ES.Player2_inArea = false;

            Debug.Log("Player 2 Fugiu!");
        }
    }
}
