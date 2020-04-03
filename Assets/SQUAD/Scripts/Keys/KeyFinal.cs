using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFinal : MonoBehaviour
{
    public int KeyID;
    Player P;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player1")
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
        if (!P.KeyFinal && P.Keys_Quantidade < 3)
        {
            P.Key[P.Keys_Quantidade] = P.KeyList[KeyID];

            P.KeyFinal = true;
            P.Keys_Quantidade++;

            P.KeyUI[P.Keys_Quantidade].sprite = P.KeyUIList[KeyID];
            this.gameObject.SetActive(false);
        }
    }
}
