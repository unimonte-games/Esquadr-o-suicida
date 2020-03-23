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

            if (!P.KeyFinal)
            {
                P.KeyFinal = true;
                Destroy(gameObject);
            }
        }

        if (other.gameObject.name == "Player2")
        {
            Player P;
            P = other.GetComponent<Player>();

            if (!P.KeyFinal)
            {
                P.KeyFinal = true;
                Destroy(gameObject);
            }

        }
    }
}
