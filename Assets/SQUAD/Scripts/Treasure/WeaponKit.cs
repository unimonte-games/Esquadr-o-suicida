using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponKit : MonoBehaviour
{
    Player P;
    bool Player1, Player2, Atived;

    public int ID;

    public int KeysToOpen;

    public int MaxListDrop;
    public int ListNumberToDrop;
    public int QtdNumbersDrop;
    public GameObject[] ListToDrop;
    public Transform[] SpawnToDrop;

    int CountToSell;


    private void FixedUpdate()
    {
        if (Player1 && Input.GetKeyDown(P.Accept) && !Atived)
        {

            UsingItem();
        }


        if (Player2 && Input.GetKeyDown(P.Accept) && !Atived)
        {
            UsingItem();

        }
    }


    void UsingItem()
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



            Debug.Log("Abriu WeaponKit com Key.");
            DropItem();

        }
    }

    void DropItem()
    {
        QtdNumbersDrop = Random.Range(1, 3);

        if(QtdNumbersDrop == 1)
        {
            ListNumberToDrop = Random.Range(0, MaxListDrop);
            Instantiate(ListToDrop[ListNumberToDrop], SpawnToDrop[0].position, SpawnToDrop[0].rotation);
        }
       
        if(QtdNumbersDrop == 2)
        {
            ListNumberToDrop = Random.Range(0, MaxListDrop);
            Instantiate(ListToDrop[ListNumberToDrop], SpawnToDrop[0].position, SpawnToDrop[0].rotation);

            ListNumberToDrop = Random.Range(0, MaxListDrop);
            Instantiate(ListToDrop[ListNumberToDrop], SpawnToDrop[1].position, SpawnToDrop[1].rotation);
        }


        if (QtdNumbersDrop == 3)
        {
            ListNumberToDrop = Random.Range(0, MaxListDrop);
            Instantiate(ListToDrop[ListNumberToDrop], SpawnToDrop[0].position, SpawnToDrop[0].rotation);

            ListNumberToDrop = Random.Range(0, MaxListDrop);
            Instantiate(ListToDrop[ListNumberToDrop], SpawnToDrop[1].position, SpawnToDrop[1].rotation);

            ListNumberToDrop = Random.Range(0, MaxListDrop);
            Instantiate(ListToDrop[ListNumberToDrop], SpawnToDrop[2].position, SpawnToDrop[2].rotation);
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
