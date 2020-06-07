using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[AddComponentMenu("PortaScripts/_RoomController")]
public class RoomController : MonoBehaviour
{
    public int Room_ID;
 
    LevelController LC;
    SoundController SC;

    public Porta_Default Default;
    public Porta_Color Color;
    public Porta_Double Double;
    public Porta_Timer Timer;
    
    public bool ColorInTheRoom, DoubleInTheRoom, FixedInTheRoom, TimerInTheRoom;
    public bool DefaultComplete, ColorComplete, DoubleComplete, TimerComplete;

    public GameObject[] ColorIsAtived;
    public GameObject[] DoubleIsAtived;
    public GameObject[] TimerIsAtived;
    public GameObject FixedIsAtived;
    public GameObject DefaultIsAtived;

    public int MissionInTheRoom;
    public int CompleteMissions;

    public GameObject[] C_Default;
    public GameObject[] C_Color;
    public GameObject[] C_Double;
    public GameObject[] C_Timer;

    public GameObject BauC;

    public MapSystem mapSystem;
    PlayerUI PUI;

    public AudioSource RoomClean_DoorSound;

    void Start()
    {
        PUI = FindObjectOfType<PlayerUI>();
        LC = FindObjectOfType<LevelController>();
        mapSystem = FindObjectOfType<MapSystem>();
        SC = FindObjectOfType<SoundController>();
        

        MissionInTheRoom++;
        if (!ColorInTheRoom && !DoubleInTheRoom && !TimerInTheRoom)
        {
            DefaultIsAtived.SetActive(true);
            return;
        }

        if (ColorInTheRoom)
        {
            for (int i = 0; i < 2; i++)
            {
                ColorIsAtived[i].SetActive(true);
            }

            Color.enabled = true;
            MissionInTheRoom++;
            return;

        }
        if (DoubleInTheRoom)
        {
            for (int i = 0; i < 2; i++)
            {
               DoubleIsAtived[i].SetActive(true);
            }

            Double.enabled = true;
            MissionInTheRoom++;
            return;
        }
        if (FixedInTheRoom)
        {

            FixedIsAtived.SetActive(true);
            MissionInTheRoom++;
            return;
        }
        if (TimerInTheRoom)
        {
            for (int i = 0; i < 2; i++)
            {
                TimerIsAtived[i].SetActive(true);
            }

            Timer.enabled = true;
            MissionInTheRoom++;
            return;
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
            PUI.Mission_SetDoor(true);

            RoomClean();
            return;
        }
        else if (Complete == 1 && DefaultComplete)
        {
            PUI.Mission_SetDoor(true);

            int Type = Random.Range(0, 30);
            Default.PlayerPunition(Type, 1);
            return;

        }

        if (Complete == 2 && DefaultComplete == false)
        {
            DoubleComplete = true;
            CompleteMissions++;
            PUI.Mission_SetDoor(true);

            RoomClean();
            return;
        }
        else if (Complete == 2 && DefaultComplete)
        {
            PUI.Mission_SetDoor(true);

            int Type = Random.Range(0, 30);
            Default.PlayerPunition(Type, 2);
            return;
        }

        if (Complete == 3 && DefaultComplete == false)
        {
            TimerComplete = true;
            CompleteMissions++;
            PUI.Mission_SetDoor(true);

            RoomClean();
            return;
        }
        else if (Complete == 3 && DefaultComplete)
        {
            PUI.Mission_SetDoor(true);

            int Type = Random.Range(0, 30);
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

        PUI.Mission_SetSurprise(true);
        PUI.CancelAllSurpriseWaves();
        RoomClean();

    }

    public void RoomClean()
    {

        if (CompleteMissions == MissionInTheRoom)
        {
            SC.RoomClean();
            Default.SetDoorComplete();
            RoomClean_DoorSound.Play();

            PUI.RoomCleanSet();
            PUI.Mission_SetDoor(true);

            Default.enabled = false;
            LC.CompleteRoom[Room_ID] = true;
            mapSystem.RoomExplored[Room_ID] = true;
            mapSystem.UI_MapExplored[Room_ID].SetActive(true);

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


            Invoke("OnBauController", 3);
            Debug.Log("Room Clean!");
        }
    }

    void OnBauController()
    {
        BauC.SetActive(true);
    }
}
