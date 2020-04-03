﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardWeapon : MonoBehaviour
{
    public int KeyID;
    Player P;

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

            P.Keys_Quantidade++;
            P.KeyWeaponTech++;

            P.KeyUI[P.Keys_Quantidade].sprite = P.KeyUIList[KeyID];
            this.gameObject.SetActive(false);
        }
    }
}
