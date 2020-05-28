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

    public int Player1Color;
    public int Player2Color;

    public bool P1_RGB;
    public bool P2_RGB;

    SoundController SC;

    private void Awake()
    {
        CT = FindObjectOfType<CameraTarget>();
    }

    private void Start()
    {
        SC = FindObjectOfType<SoundController>();
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

        if(P1_dead && P2_dead)
        {
            SC.AllPlayersDead();
        }

        if(P1_dead && SoloPlayer || P2_dead && SoloPlayer)
        {
            SC.AllPlayersDead();
        }

        CT.UpdateCamera();
    }
}
