using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnabled : MonoBehaviour
{

    public GameObject[] Complete;
    public GameObject[] Doors;
    public Porta_Default PD;

    private void Start()
    {
        PD.GetDoorEnabled = this;

    }

    public void SetCompleteDoor()
    {
        for (int i = 0; i < 4; i++)
        {
            Doors[i].SetActive(false);
            Complete[i].SetActive(true);
        }

    }
}
