using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[AddComponentMenu("PortaScripts/_RoomController")]
public class RoomController : MonoBehaviour
{
    Porta_Default Default;
    Porta_Color Color;
    Porta_Double Double;
    Porta_Fixed Fixed;
    Porta_Timer Timer;

    public bool ColorInTheRoom, DoubleInTheRoom, FixedInTheRoom, TimerInTheRoom;

    public int MissionInTheRoom;
    public int CompleteMissions;

    void Start()
    {
        Default = GetComponent<Porta_Default>(); MissionInTheRoom++;

        if (ColorInTheRoom){Color = GetComponent<Porta_Color>(); MissionInTheRoom++; }
        if (DoubleInTheRoom){Double = GetComponent<Porta_Double>(); MissionInTheRoom++; }
        if (FixedInTheRoom){Fixed = GetComponent<Porta_Fixed>(); MissionInTheRoom++; }
        if (TimerInTheRoom){Timer = GetComponent<Porta_Timer>(); MissionInTheRoom++; }

    }

    public void CompleteRoom()
    {
        CompleteMissions++;
        if(CompleteMissions == MissionInTheRoom)
        {
            Debug.Log("Room Clean!");
        }

    }

    
   
}
