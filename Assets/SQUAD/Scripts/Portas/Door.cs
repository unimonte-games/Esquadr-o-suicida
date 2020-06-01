using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public ConnectorRoom CR;
    Player P;
    bool Player1, Player2, Atived;

    public int ID;
    bool PlayerOpenThis;
    public int KeysToOpen;
    int CountToSell;

    public GameObject Keys1;
    public GameObject Keys2;
    public GameObject Keys3;

    private void Start()
    {
        CR.CompleteKeyOpenFirst = true;

        if(KeysToOpen == 1)
        {
            Keys1.SetActive(true);
        }

        if (KeysToOpen == 2)
        {
            Keys2.SetActive(true);
        }

        if (KeysToOpen == 3)
        {
            Keys3.SetActive(true);
        }
    }

    private void FixedUpdate()
    {

        if (Player1 && Input.GetKeyDown(P.Accept) && !Atived && !PlayerOpenThis)
        {
            PlayerOpenThis = true;
            OpenDoor();
        }

        if (Player2 && Input.GetKeyDown(P.Accept) && !Atived && !PlayerOpenThis)
        {
            PlayerOpenThis = true;
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        if (P.Keys_Quantidade >= KeysToOpen && P.KeyID[ID] >= KeysToOpen)
        {

            for (int i = 0; i <= 2; i++)
            {
                if (P.Key[i].GetComponent<DropKey>().ID == ID)
                {

                    P.Key[i] = null;
                    P.KeyUI[i].sprite = null;
                    Debug.Log("Verificando Inventory: " + i);

                    CountToSell++;
                    if (CountToSell == KeysToOpen)
                    {
                        Debug.Log("Quantos foram usados: " + CountToSell);
                        i = 3;
                    }


                }
            }

            for (int i = 0; i <= 2; i++)
            {
                P.ListReOrganize[i] = null;
                P.ListReOrganizeUI[i] = null;
            }

            Atived = true;

            P.SetDropKey();

            P.Keys_Quantidade -= KeysToOpen;
            P.KeyID[ID] -= KeysToOpen;


            CR.CompleteKeyOpenFirst = false;
            Debug.Log("Porta Liberada!");

            this.gameObject.SetActive(false);



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
            PlayerOpenThis = false;
        }

        if (other.gameObject.name == "Player2")
        {
            Player2 = false;
            PlayerOpenThis = false;
        }
    }

}
