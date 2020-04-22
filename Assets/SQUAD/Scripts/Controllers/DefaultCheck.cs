using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCheck : MonoBehaviour
{
    public Porta_Default PD;

    private void Start()
    {
        Invoke("DeletedThis", 3);
    }

    void DeletedThis()
    {
        GameObject P1 = GameObject.Find("Player1");
        if (P1 != null)
        {
            Player Player1 = P1.GetComponent<Player>();
            Player1.PD = PD;
            PD.player1 = Player1;

            this.gameObject.SetActive(false);
        }

        GameObject P2 = GameObject.Find("Player2");
        if (P2 != null)
        {
            Player Player2 = P2.GetComponent<Player>();
            Player2.PD = PD;
            PD.player2 = Player2;

            this.gameObject.SetActive(false);
        }
    }
}
