using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonMove : MonoBehaviour
{
    public SpawnController SC;
    public Transform[] ListToMove;

    bool P1_inArea;
    bool P2_inArea;

    bool P1_ready;
    bool P2_ready;

    bool Go;

    KeyCode P1;
    KeyCode P2;

    private void FixedUpdate()
    {
        if (P1_inArea && Input.GetKeyDown(P1) && !P1_ready && !Go)
        {
            P1_ready = true;

            Debug.Log("Baloon Ativado no Player 1");
        }

        if (P2_inArea && Input.GetKeyDown(P2) && !P2_ready !Go)
        {
            P2_ready = true;

            Debug.Log("Baloon Ativado no Player 2");
        }

        if (P1_ready && P2_ready && !Go)
        {
            Go = true;
            ReOrganizeList();
            Debug.Log("Balon Iniciado!");
        }
    }

    void ReOrganizeList()
    {
        for (int i = 0; i <= SC.Acionados; i++)
        {
            ListToMove[i] = SC.ListSpawn[i];
        }

        Debug.Log("Lista Organizada");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1" && !P1_inArea)
        {
            if (!other.GetComponent<Player>().UsingItenDinamic)
            {
                P1_inArea = true;
                P1 = other.GetComponent<Player>().Accept;
            }
        }

        if (other.gameObject.name == "Player2" && !P2_inArea)
        {
            if (!other.GetComponent<Player>().UsingItenDinamic)
            {
                P2_inArea = true;
                P2 = other.GetComponent<Player>().Accept;
            }
        }

    }

}
