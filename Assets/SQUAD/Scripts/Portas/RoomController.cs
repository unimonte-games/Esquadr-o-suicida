using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[AddComponentMenu("PortaScripts/_RoomController")]
public class RoomController : MonoBehaviour
{
    public int Room_ID;
    LevelController LC;
    public Porta_Default Default;
    public Porta_Color Color;
    public Porta_Double Double;
    public Porta_Timer Timer;
    
    public bool ColorInTheRoom, DoubleInTheRoom, FixedInTheRoom, TimerInTheRoom;
    public bool DefaultComplete, ColorComplete, DoubleComplete, TimerComplete;

    public int MissionInTheRoom;
    public int CompleteMissions;

    public GameObject defaultDoor;

    public GameObject[] C_Default;
    public GameObject[] C_Color;
    public GameObject[] C_Double;
    public GameObject[] C_Timer;


    void Start()
    {
        LC = FindObjectOfType<LevelController>();


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

        if(!ColorInTheRoom && !DoubleInTheRoom && !TimerInTheRoom)
        {
            defaultDoor.SetActive(true);
        }

    }

    public void CompleteRoom(int Complete)
    {
        if (Complete == 0)
        {
            DefaultComplete = true;
            CompleteMissions++;
            RoomClean();

            for (int i = 0; i < 4; i++)
            {
                C_Default[i].SetActive(true);
            }

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
            int Type = Random.Range(0, 30); 
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
            int Type = Random.Range(0, 30); 
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
            int Type = Random.Range(11, 15); 
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

    public void RoomClean()
    {

        if (CompleteMissions == MissionInTheRoom)
        {
            LC.CompleteRoom[Room_ID] = true;

            if (ColorComplete)
            {
                for (int i = 0; i < 4; i++)
                {
                    C_Color[i].SetActive(true);
                }
            }

            if (DoubleComplete)
            {
                for (int i = 0; i < 4; i++)
                {
                    C_Double[i].SetActive(true);
                }
            }

            if (TimerComplete)
            {
                for (int i = 0; i < 4; i++)
                {
                    C_Timer[i].SetActive(true);
                }
            }

            Debug.Log("Room Clean!");
        }
    }

    
   
}
