using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropKey : MonoBehaviour
{
    public bool ControllerCheck;
    public GameObject[] C_check;
    public DropKey DK;
    public int AtualID;


    private void OnTriggerStay(Collider other)
    {
        if (!ControllerCheck)
        {
            if (other.gameObject.layer == 8)
            {
                DK.C_check[AtualID] = null;
              
            } 
          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            DK.C_check[AtualID] = this.gameObject;
        }
    }

}
