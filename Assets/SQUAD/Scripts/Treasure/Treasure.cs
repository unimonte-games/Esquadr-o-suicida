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

    public int GoldRandomMin;
    public int GoldRandomMax;

    public int ID;

    public int MaxListDrop;
    public int ListNumberToDrop;
    public GameObject[] ListToDrop;
    public Transform SpawnToDrop;

    int CountToSell;

    LevelController LC;

    private void Start()
    {
        LC = FindObjectOfType<LevelController>();

        int KeyOn = Random.Range(0, 100);
        if(KeyOn <= 50)
        {
            Key = true;
            int KeyQtd = Random.Range(1, 3);
            KeysToOpen = KeyQtd;
                
        }
        if(KeyOn >= 51)
        {
            Key = false;
            int GoldQtd = Random.Range(GoldRandomMin, GoldRandomMax);
            GoldToOpen = GoldQtd;
        }
        
    }


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
        if (Key)
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
                        if(CountToSell == KeysToOpen)
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

                

                Debug.Log("Abriu Comum com Key.");
                DropItem();

            }
            return;
        }


        if (P.Gold >= GoldToOpen)
        {
            P.Gold -= GoldToOpen;
            P.SetGold();
            Atived = true;
            Debug.Log("Abriu Comum com Ouro.");

            DropItem();

        }
    }

    void DropItem()
    {
        if (LC.Level == 0)
        {
            ListNumberToDrop = Random.Range(0, 10);
        }

        if (LC.Level == 1)
        {
            ListNumberToDrop = Random.Range(0, 15);
        }

        if (LC.Level == 2)
        {
            ListNumberToDrop = Random.Range(0, 17);
        }

        if (LC.Level == 3)
        {
            ListNumberToDrop = Random.Range(0, 19);
        }

        if (LC.Level == 4)
        {
            ListNumberToDrop = Random.Range(0, 19);
        }

        if (LC.Level == 5)
        {
            ListNumberToDrop = Random.Range(0, 19);
        }

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
    
