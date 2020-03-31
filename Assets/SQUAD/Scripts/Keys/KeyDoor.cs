﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
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
                P.KeysDoor++;
                
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
                P.KeysDoor++;

                Destroy(gameObject);
            }

        }
    }
}
