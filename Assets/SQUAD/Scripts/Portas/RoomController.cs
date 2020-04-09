using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[AddComponentMenu("PortaScripts/_RoomController")]
public class RoomController : MonoBehaviour
{
    public Porta_Default Default;
    public Porta_Color Color;
    public Porta_Double Double;
    public Porta_Fixed Fixed;
    public Porta_Timer Timer;
    

    public bool ColorInTheRoom, DoubleInTheRoom, FixedInTheRoom, TimerInTheRoom;
    public bool DefaultComplete, ColorComplete, DoubleComplete, TimerComplete;
    public int FixedComplete;

    public int MissionInTheRoom;
    public int CompleteMissions;

    void Start()
    {
         MissionInTheRoom++;

        if (ColorInTheRoom)
        {
            MissionInTheRoom++;
        }
        if (DoubleInTheRoom)
        {
            MissionInTheRoom++;
        }
        if (FixedInTheRoom)
        {
            MissionInTheRoom++;
        }
        if (TimerInTheRoom)
        {
            MissionInTheRoom++;
        }

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
        else if(Complete == 1 && DefaultComplete)
        {
            int Type = Random.Range(0, 25); 
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
        else if (Complete == 2 && DefaultComplete)
        {
            int Type = Random.Range(0, 25); 
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
        else if (Complete == 3 && DefaultComplete)
        {
            int Type = Random.Range(16, 20); 
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
