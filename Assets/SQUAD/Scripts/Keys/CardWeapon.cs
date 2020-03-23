using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardWeapon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1")
        {
            Player P;
            P = other.GetComponent<Player>();

            if (P.Keys_Quantidade < 3)
            {
                P.Keys_Quantidade++;
                P.KeyWeaponTech++;
                Destroy(gameObject);
            }
        }

        if (other.gameObject.name == "Player2")
        {
            Player P;
            P = other.GetComponent<Player>();

            if (P.Keys_Quantidade < 3)
            {
                P.Keys_Quantidade++;
                P.KeyWeaponTech++;
                Destroy(gameObject);
            }

        }
    }
}
