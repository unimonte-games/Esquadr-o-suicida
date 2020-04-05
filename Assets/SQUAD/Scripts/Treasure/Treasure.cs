using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    Player P;
    bool Player1, Player2, Atived;

    public int KeysToOpen;
    public int GoldToOpen;
    public bool Key;

    public int ID;

    public int MaxListDrop;
    public int ListNumberToDrop;
    public GameObject[] ListToDrop;
    public Transform SpawnToDrop;


    private void FixedUpdate()
    {

        if (Player1 && Input.GetKeyDown(KeyCode.Q) && !Atived)
        {
            UsingItem();
        }

        if (Player2 && Input.GetKeyDown(KeyCode.E) && !Atived)
        {
            UsingItem();
        }
    }

    void UsingItem()
    {
        if (Key)
        {
            if (P.Keys_Quantidade >= KeysToOpen && P.KeyID[ID] >= KeysToOpen)
            {
                P.Keys_Quantidade -= KeysToOpen;
                P.KeyID[ID] -= KeysToOpen;
                Atived = true;
                Debug.Log("Abriu Comum com Key.");

                DropItem();

            }
            return;
        }


        if (P.Gold >= GoldToOpen)
        {
            P.Gold -= GoldToOpen;
            Atived = true;
            Debug.Log("Abriu Comum com Ouro.");

            DropItem();

        }
    }

    void DropItem()
    {
        ListNumberToDrop = Random.Range(0, MaxListDrop);
        Instantiate(ListToDrop[ListNumberToDrop], SpawnToDrop.position, SpawnToDrop.rotation);
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
    
