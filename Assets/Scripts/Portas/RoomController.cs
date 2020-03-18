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
    public bool DefaultComplete, ColorComplete, DoubleComplete, TimerComplete;
    public int FixedComplete;

    public int MissionInTheRoom;
    public int CompleteMissions;

    void Start()
    {
        Default = GetComponent<Porta_Default>(); MissionInTheRoom++;

        if (ColorInTheRoom){Color = GetComponent<Porta_Color>(); MissionInTheRoom++; }
        if (DoubleInTheRoom){Double = GetComponent<Porta_Double>(); MissionInTheRoom++; }
        if (FixedInTheRoom){Fixed = GetComponent<Porta_Fixed>(); }
        if (TimerInTheRoom){Timer = GetComponent<Porta_Timer>(); MissionInTheRoom++; }

    }

    public void CompleteRoom(int Complete)
    {
        if(Complete == 0)
        {
            DefaultComplete = true;
            CompleteMissions++;
            RoomClean();
            return;
        }

        if (Complete == 1 && DefaultComplete == false)
        {
           ColorComplete = true;
           CompleteMissions++;
            RoomClean();
           return;
        }
        else if(Complete == 1 && Default)
        {
            int Type = Random.Range(0, 18); //chance mediana de sair "surprise wave"
            Default.PlayerPunition(Type, 1);
            return;
                
        }

        if (Complete == 2 && DefaultComplete == false)
        {
           DoubleComplete = true;
           CompleteMissions++;
           RoomClean();
           return;
        }
        else if (Complete == 2 && Default)
        {
            int Type = Random.Range(0, 18); //chance pequena de sair "Surprise wave"
            Default.PlayerPunition(Type, 2);
            return;
        }

        if (Complete == 3 && DefaultComplete == false)
        {
            TimerComplete = true;
            CompleteMissions++;
            RoomClean();
            return;
        }
        else if (Complete == 3 && Default)
        {
            int Type = Random.Range(0, 18); //chance maior de sair "surprise wave"
            Default.PlayerPunition(Type, 3);
            return;
        }



    }

    public void ReWaveContest(int complete)
    {
        Default.ReWave = false;

        if (complete == 1)
        {
            ColorComplete = true;
            CompleteMissions++;
        }


        if (complete == 2)
        {
            DoubleComplete = true;
            CompleteMissions++;
        }


        if (complete == 3)
        {
            TimerComplete = true;
            CompleteMissions++;
        }

        RoomClean();

    }


    void RoomClean()
    {

        if (CompleteMissions == MissionInTheRoom)
        {
            Debug.Log("Room Clean!");
        }
    }

    
   
}
