using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public int KeyID;
    Player P;
    ///bool PlayerDiscart; 


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1")
        {
            P = other.GetComponent<Player>();
            SetKey();
        }
        

        if (other.gameObject.name == "Player2")
        {
            P = other.GetComponent<Player>();
            SetKey();
        }
    }

    void SetKey()
    {

        if (P.Keys_Quantidade < 3)
        {
            P.Key[P.Keys_Quantidade] = P.KeyList[KeyID];
            P.KeyUI[P.Keys_Quantidade].sprite = P.KeyUIList[KeyID];

            P.Keys_Quantidade++;
            P.KeyID[KeyID]++;

            
            this.gameObject.SetActive(false);
           
        }else
        {
            Debug.Log("Inventory Full");
        }

    }
}
