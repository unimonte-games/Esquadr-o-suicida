using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSystem : MonoBehaviour
{
    public bool[] RoomExist;
    public bool[] RoomExplored;

    public GameObject[] Triggers;

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            Triggers[i].SetActive(true);
        }
    }

}
