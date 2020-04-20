using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropKeyHabiity : MonoBehaviour
{
    public int LifeKey;
    public DropKey DK;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hit")
        {
            other.gameObject.SetActive(false);

            LifeKey--;
            if (LifeKey <= 0)
            {
                DK.BC.enabled = true;
                Debug.Log("Chave Utilizavel!");

                this.gameObject.SetActive(false);
            }
            Debug.Log("Hit!");
        }
    }

}
