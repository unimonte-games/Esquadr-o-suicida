using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicKit : MonoBehaviour
{

    Player P;
    bool Player1, Player2, Atived;

    public int KeysToOpen;

    public int MaxListDrop;
    public int ListNumberToDrop;
    public int QtdNumbersDrop;
    public GameObject[] ListToDrop;
    public Transform[] SpawnToDrop;


    private void FixedUpdate()
    {
        if (Player1 && Input.GetKeyDown(KeyCode.Q) && !Atived)
        {

            if (P.Keys_Quantidade >= KeysToOpen && P.KeyMedicKit >= KeysToOpen)
            {
                P.Keys_Quantidade -= KeysToOpen;
                P.KeyMedicKit -= KeysToOpen;
                Atived = true;


                Debug.Log("Abriu Medic Kit.");

                DropItem();

            }
        }


        if (Player2 && Input.GetKeyDown(KeyCode.E) && !Atived)
        {

            if (P.Keys_Quantidade >= KeysToOpen && P.KeyMedicKit >= KeysToOpen)
            {
                P.Keys_Quantidade -= KeysToOpen;
                P.KeyMedicKit -= KeysToOpen;
                Atived = true;
                Debug.Log("Abriu Medic Kit.");

                DropItem();

            }

        }
    }

    void DropItem()
    {
        QtdNumbersDrop = Random.Range(1, 3);
        for (int i = 1; i == QtdNumbersDrop; i++)
        {
            ListNumberToDrop = Random.Range(0, MaxListDrop);
            Instantiate(ListToDrop[ListNumberToDrop], SpawnToDrop[i].position, SpawnToDrop[i].rotation);
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
