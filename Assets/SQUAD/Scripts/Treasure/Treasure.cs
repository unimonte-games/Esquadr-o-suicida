using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public GameObject UI;

    public GameObject Energy;
    public TextMeshProUGUI Value;
    public GameObject Key1;
    public GameObject Key2;
    public GameObject Key3;

    public int[] numberLevels;
    public Animation OpenAnin;

    int CountToSell;

    LevelController LC;
    public bool isCard;

    private void Start()
    {
        LC = FindObjectOfType<LevelController>();
        UI.SetActive(true);

        if (isCard)
        {
            Key = true;
            int KeyQtd = Random.Range(1, 3);
            KeysToOpen = KeyQtd;

            if (KeysToOpen == 1)
            {
                Key1.SetActive(true);
            }

            if (KeysToOpen == 2)
            {
                Key2.SetActive(true);
            }

            if (KeysToOpen == 3)
            {
                Key3.SetActive(true);
            }

            return;
        }

        int KeyOn = Random.Range(0, 100);
        if(KeyOn <= 50)
        {
            Key = true;
            int KeyQtd = Random.Range(1, 3);
            KeysToOpen = KeyQtd;

            if(KeysToOpen == 1)
            {
                Key1.SetActive(true);
            }

            if (KeysToOpen == 2)
            {
                Key2.SetActive(true);
            }

            if (KeysToOpen == 3)
            {
                Key3.SetActive(true);
            }

        }
        if(KeyOn >= 51)
        {
            Key = false;
            int GoldQtd = Random.Range(GoldRandomMin, GoldRandomMax);
            GoldToOpen = GoldQtd;

            Value.text = "" + GoldToOpen;
            Energy.SetActive(true);

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
        UI.SetActive(false);
        OpenAnin.Play();

        if (LC.Level == 0)
        {
            ListNumberToDrop = Random.Range(0, numberLevels[0]);
        }

        if (LC.Level == 1)
        {
            ListNumberToDrop = Random.Range(0, numberLevels[1]);
        }

        if (LC.Level == 2)
        {
            ListNumberToDrop = Random.Range(0, numberLevels[2]);
        }

        if (LC.Level == 3)
        {
            ListNumberToDrop = Random.Range(0, numberLevels[3]);
        }

        if (LC.Level == 4)
        {
            ListNumberToDrop = Random.Range(0, numberLevels[4]);
        }

        if (LC.Level == 5)
        {
            ListNumberToDrop = Random.Range(0, numberLevels[5]);
        }

        GameObject Item = Instantiate(ListToDrop[ListNumberToDrop], SpawnToDrop.position, SpawnToDrop.rotation) as GameObject;
        Item.transform.parent = SpawnToDrop;
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
    
