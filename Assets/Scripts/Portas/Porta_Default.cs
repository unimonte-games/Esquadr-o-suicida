using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta_Default : MonoBehaviour
{
    BoxCollider triggerPlayers;
    public bool StartingWave;

    void Start()
    {

        triggerPlayers = FindObjectOfType<BoxCollider>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartingWave = true;
        }
    }


}
