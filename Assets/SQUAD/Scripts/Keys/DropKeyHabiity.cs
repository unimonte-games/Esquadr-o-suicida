using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropKeyHabiity : MonoBehaviour
{
    public float LifeKey;
    public float LifeMax;
    public DropKey DK;

    public GameObject UI;
    public Image LifeFilead;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hit")
        {
            other.gameObject.SetActive(false);
            UI.SetActive(true);

            LifeKey--;
            float KeyCal = LifeKey / LifeMax;
            LifeFilead.fillAmount = KeyCal;

            if (LifeKey <= 0)
            {
                DK.BC.enabled = true;
                Debug.Log("Chave Utilizavel!");

                CancelInvoke("Cancel");
                this.gameObject.SetActive(false);
            }

            Invoke("Cancel", 1);
            Debug.Log("Hit!");
        }
    }

   void Cancel()
    {
        UI.SetActive(false);
    }

}
