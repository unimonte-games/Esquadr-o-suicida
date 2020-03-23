using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFinal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player1")
        {
            Player P;
            P = other.GetComponent<Player>();

            if (!P.KeyFinal && P.Keys_Quantidade < 3)
            {
                P.KeyFinal = true;
                P.Keys_Quantidade++;
                Destroy(gameObject);
            }
        }

        if (other.gameObject.name == "Player2")
        {
            Player P;
            P = other.GetComponent<Player>();

            if (!P.KeyFinal && P.Keys_Quantidade < 3)
            {
                P.KeyFinal = true;
                P.Keys_Quantidade++;
                Destroy(gameObject);
            }

        }
    }
}
