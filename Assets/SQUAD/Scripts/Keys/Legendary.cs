using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legendary : MonoBehaviour
{
    Player P;
    bool Player1, Player2, Atived;

    public int KeysToOpen;
    public int GoldToOpen;
    public bool Key;

    public int MaxListDrop;
    public int ListNumberToDrop;
    public GameObject[] ListToDrop1;
    public GameObject[] ListToDrop2;
    public GameObject[] ListToDrop3;
    public Transform[] SpawnToDrop;


    private void FixedUpdate()
    {

        if (Player1 && Input.GetKeyDown(KeyCode.Q) && !Atived)
        {
            if (Key)
            {
                if (P.Keys_Quantidade >= KeysToOpen && P.KeyLegendary >= KeysToOpen)
                {
                    P.Keys_Quantidade -= KeysToOpen;
                    P.KeyLegendary -= KeysToOpen;
                    Atived = true;


                    Debug.Log("Abriu com Key.");

                    DropItem();

                }
                return;
            }


            if (P.Gold >= GoldToOpen)
            {
                P.Gold -= GoldToOpen;
                Atived = true;
                Debug.Log("Abriu com Ouro.");

                DropItem();

            }
        }

        if (Player2 && Input.GetKeyDown(KeyCode.E) && !Atived)
        {
            if (Key)
            {
                if (P.Keys_Quantidade >= KeysToOpen && P.KeyLegendary >= KeysToOpen)
                {
                    P.Keys_Quantidade -= KeysToOpen;
                    P.KeyLegendary -= KeysToOpen;
                    Atived = true;
                    Debug.Log("Abriu com Key.");

                    DropItem();

                }
                return;
            }


            if (P.Gold >= GoldToOpen)
            {
                P.Gold -= GoldToOpen;
                Atived = true;
                Debug.Log("Abriu com Ouro.");

                DropItem();

            }
        }
    }

    void DropItem()
    {
        ListNumberToDrop = Random.Range(0, MaxListDrop);
        Instantiate(ListToDrop1[ListNumberToDrop], SpawnToDrop[0].position, SpawnToDrop[0].rotation);
        ListNumberToDrop = Random.Range(0, MaxListDrop);
        Instantiate(ListToDrop2[ListNumberToDrop], SpawnToDrop[1].position, SpawnToDrop[1].rotation);
        ListNumberToDrop = Random.Range(0, MaxListDrop);
        Instantiate(ListToDrop3[ListNumberToDrop], SpawnToDrop[2].position, SpawnToDrop[2].rotation);
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



