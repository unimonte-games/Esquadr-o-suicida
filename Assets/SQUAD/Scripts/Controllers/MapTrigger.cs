using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTrigger : MonoBehaviour
{
    public int TriggerID;
    public MapSystem MP;

    bool isCheck;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Room")
        {
            if (!isCheck)
            {
                isCheck = true;

                RoomController RC = other.GetComponent<RoomController>();
                RC.Room_ID = TriggerID;
                MP.RoomExist[TriggerID] = true;

                this.gameObject.SetActive(false);


            }
        }
    }
}
