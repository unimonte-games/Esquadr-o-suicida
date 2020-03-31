using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTreasure : MonoBehaviour
{
    public int KeyID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1")
        {
            Player P;
            P = other.GetComponent<Player>();

            if (P.Keys_Quantidade < 3)
            {
                P.Key[P.Keys_Quantidade] = P.KeyList[KeyID];
                P.Keys_Quantidade++;
                P.KeyTreasure++;
                Destroy(gameObject);
            }
        }

        if (other.gameObject.name == "Player2")
        {
            Player P;
            P = other.GetComponent<Player>();

            if (P.Keys_Quantidade < 3)
            {
                P.Key[P.Keys_Quantidade] = P.KeyList[KeyID];
                P.Keys_Quantidade++;
                P.KeyTreasure++;
                Destroy(gameObject);
            }

        }
    }
}
