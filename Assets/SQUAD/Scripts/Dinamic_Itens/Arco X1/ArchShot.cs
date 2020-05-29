using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchShot : MonoBehaviour
{
    public int ID;
    public ArchController AC;

    public Porta_Default PD;

    private void OnTriggerEnter(Collider other)

    {

        if(ID == 1 && other.gameObject.name == "Player2")
        {
            AC.SetPoints(true);
            this.gameObject.SetActive(false);
            return;
        }

        if (ID == 2 && other.gameObject.name == "Player1")
        {
            AC.SetPoints(false);
            this.gameObject.SetActive(false);
            return;
        }
    }
}
