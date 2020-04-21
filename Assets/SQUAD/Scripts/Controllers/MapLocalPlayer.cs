using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLocalPlayer : MonoBehaviour
{
    public int Local_ID;
    public MapSystem MP;
    public bool Check;
    

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player" && !Check)
        {
            MP.UI_LocalPlayer[Local_ID].SetActive(true);
            MP.LocalPlayer_RoomID = Local_ID;
            Check = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && Check)
        {
            MP.UI_LocalPlayer[Local_ID].SetActive(false);
            Check = false;
        }
    }
}
