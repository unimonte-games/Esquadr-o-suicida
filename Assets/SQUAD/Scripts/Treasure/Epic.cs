using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Epic : MonoBehaviour
{
    Player P;
    bool Player1, Player2, Atived;

    public int KeysToOpen;
    public int GoldToOpen;
    public bool Key;

    public int ID;

    public int MaxListDrop;
    public int ListNumberToDrop;
    public GameObject[] ListToDrop1;
    public GameObject[] ListToDrop2;
    public Transform[] SpawnToDrop;


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
                Debug.Log("Abriu Epic com Key.");

                DropItem();

            }
            return;
        }


        if (P.Gold >= GoldToOpen)
        {
            P.Gold -= GoldToOpen;
            Atived = true;
            Debug.Log("Abriu Epic com Ouro.");

            DropItem();

        }
    }

    void DropItem()
    {
        int NumberToDrop = Random.Range(1, 2);

        if(NumberToDrop == 1)
        {
            ListNumberToDrop = Random.Range(0, MaxListDrop);
            Instantiate(ListToDrop1[ListNumberToDrop], SpawnToDrop[0].position, SpawnToDrop[0].rotation);
        }

        if (NumberToDrop == 2)
        {
            ListNumberToDrop = Random.Range(0, MaxListDrop);
            Instantiate(ListToDrop1[ListNumberToDrop], SpawnToDrop[0].position, SpawnToDrop[0].rotation);

            ListNumberToDrop = Random.Range(0, MaxListDrop);
            Instantiate(ListToDrop2[ListNumberToDrop], SpawnToDrop[1].position, SpawnToDrop[1].rotation);
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

