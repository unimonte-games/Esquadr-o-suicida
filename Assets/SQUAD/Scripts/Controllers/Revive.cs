using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revive : MonoBehaviour
{
    public int Gold;
    public bool Player;
    KeyCode ReviveKey;
    PlayerUI PUI;
    DeadCheck DC;
    bool InArea;
    bool revive;
    Player PlayerRef;

    private void Start()
    {
        DC = FindObjectOfType<DeadCheck>();
        PUI = FindObjectOfType<PlayerUI>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(ReviveKey) && InArea && !revive)
        {
            revive = true;

            PlayerRef.Gold -= Gold;
            PUI.ChangeGold(PlayerRef.PlayerType, PlayerRef.Gold);

            if (Player)
            {
                DC.ReviveInRoom_Player1();
            }
            else
            {
                DC.ReviveInRoom_Player2();
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !InArea && !revive)
        {

            Player P = other.gameObject.GetComponent<Player>();
            InArea = true;

            ReviveKey = P.Selecionar_set;
            PlayerRef = P;


        }
    }
}
