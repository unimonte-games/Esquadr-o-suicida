using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatinsRacerTarget : MonoBehaviour
{
    public PatinsJato PJ;
    bool On;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player1" && !On)
        {
            On = true;
            PJ.P1_Placar++;
            PJ.ChangeTarget();
            this.gameObject.SetActive(false);
            return;
        }

        if (other.gameObject.name == "Player2" && !On)
        {
            On = true;
            PJ.P2_Placar++;
            PJ.ChangeTarget();
            this.gameObject.SetActive(false);
            return;
        }
    }
}
