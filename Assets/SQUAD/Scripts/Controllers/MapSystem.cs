using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSystem : MonoBehaviour
{
    public bool[] RoomExist;
    public bool[] RoomExplored;

    public GameObject[] UI_MapExist;
    public GameObject[] UI_MapExplored;
    public GameObject[] UI_End;
    public GameObject[] UI_LocalPlayer;
    public int LocalPlayer_RoomID;

    public GameObject[] Triggers;
    
    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            Triggers[i].SetActive(true);
        }
    }

    public void EndCheck()
    {
        for (int i = 0; i < 15; i++)
        {
            UI_End[i].SetActive(false);
        }

        UI_End[LocalPlayer_RoomID].SetActive(true);
    }

}
