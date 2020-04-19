using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndDoor : MonoBehaviour
{

    
    Player P;
    bool Player1, Player2, Atived;

    public int ID;

    public int SceneNext; 

    public int KeysToOpen;
    int CountToSell;


    private void FixedUpdate()
    {

        if (Player1 && Input.GetKeyDown(P.Accept) && !Atived)
        {
            OpenDoor();
        }

        if (Player2 && Input.GetKeyDown(P.Accept) && !Atived)
        {
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



            SceneManager.LoadScene(SceneNext);
            Debug.Log("Venceu o Level!");
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
