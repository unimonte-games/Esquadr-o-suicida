using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int Level;
    public bool SoloPlayer;

    public bool P1_inRoom;
    public bool P2_inRoom;

    public bool P1_dead;
    public bool P2_dead;

    public int FixedOpen;

    public GameObject[] AllRoomList;
    CameraTarget CT;

    public bool[] CompleteRoom;

    private void Awake()
    {
        CT = FindObjectOfType<CameraTarget>();
    }

    public void UpdatePlayers()
    {
        if(P1_inRoom && !P2_inRoom || !P1_inRoom && P2_inRoom)
        {
            SoloPlayer = true;
        } 

        if(P1_inRoom && P2_inRoom)
        {
            SoloPlayer = false;
        }

        if (!CT.enabled)
        {
            CT.enabled = true;
        }

        CT.UpdateCamera();
    }


}
