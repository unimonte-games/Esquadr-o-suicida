using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    Player P;
    bool Player1, Player2, Atived;

    public int ID;

    public int KeysToOpen;



    private void FixedUpdate()
    {

        if (Player1 && Input.GetKeyDown(KeyCode.Q) && !Atived)
        {
            OpenDoor();
        }

        if (Player2 && Input.GetKeyDown(KeyCode.E) && !Atived)
        {

            OpenDoor();
        }
    }

    void OpenDoor()
    {
        if (P.Keys_Quantidade >= KeysToOpen && P.KeyID[ID] >= KeysToOpen)
        {
            P.Keys_Quantidade -= KeysToOpen;
            P.KeyID[ID] -= KeysToOpen;
            Atived = true;
            Debug.Log("Abriu Portao com Key.");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1" && !Player2)
        {
            P = other.GetComponent<Player>();

            Player1 = true;
            Player2 = false;
        }

        if (other.gameObject.name == "Player2" && !Player1)
        {
            P = other.GetComponent<Player>();

            Player2 = true;
            Player1 = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1")
        {
            Player1 = false;

        }

        if (other.gameObject.name == "Player2")
        {
            Player2 = false;
        }
    }

}
