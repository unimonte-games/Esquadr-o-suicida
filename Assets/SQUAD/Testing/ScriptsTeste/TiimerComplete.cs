using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiimerComplete : MonoBehaviour
{
    public Porta_Default PD;
    public RoomController RC;

    public Text EnemyDestroy;
    public Text EnemyInRoom;
    public Text AtualWave;
    public Text MaxWave;

    public GameObject M_Porta;
    public GameObject M_Wave;

    public GameObject RoomComplete;
    public GameObject Info;

    public void Update()
    {
        EnemyDestroy.text = "" + PD.MonstersDestroy;
        EnemyInRoom.text = "" + PD.AtualMonsters;
        AtualWave.text = "" + PD.AtualWave;
        MaxWave.text = "" + PD.WaveNumbers;

        if (RC.TimerComplete)
        {
            M_Porta.SetActive(true);
        }

        if (RC.DefaultComplete)
        {
            M_Wave.SetActive(true);
        }

        if (RC.CompleteMissions == RC.MissionInTheRoom)
        {
            RoomComplete.SetActive(true);
        }

    }
}
