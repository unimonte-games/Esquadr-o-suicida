using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCheck : MonoBehaviour
{

    LevelController LC;
    CameraTarget CT;

    public GameObject P1;
    public GameObject P2;

    private void Start()
    {
        LC = FindObjectOfType<LevelController>();
        CT = FindObjectOfType<CameraTarget>();

        if (LC.P1_dead)
        {
            Invoke("ReLive_Player1", 2);
        }

        if (LC.P2_dead)
        {
            Invoke("ReLive_Player2", 2);
        }

    }

    void ReLive_Player1()
    {
        P1.GetComponent<Player>().PD = P2.GetComponent<Player>().PD;
        P1.SetActive(true);
        LC.P1_dead = false;

        Debug.Log("Player 1 Renasceu");
    }

    void ReLive_Player2()
    {
        P2.GetComponent<Player>().PD = P1.GetComponent<Player>().PD;
        P2.SetActive(true);
        LC.P2_dead = false;
        

        Debug.Log("Player 2 Renasceu");
    }


    public void ReviveInRoom_Player1()
    {
        P1.GetComponent<Player>().PD = P2.GetComponent<Player>().PD;
        
        LC.P1_dead = false;
        LC.P1_inRoom = true;
        P1.GetComponent<Player>().Revive();
        P1.SetActive(true);
    }

    public void ReviveInRoom_Player2()
    {
        P2.GetComponent<Player>().PD = P1.GetComponent<Player>().PD;
        
        LC.P2_dead = false;
        LC.P2_inRoom = true;
        P2.GetComponent<Player>().Revive();
        P2.SetActive(true);
    }
}
