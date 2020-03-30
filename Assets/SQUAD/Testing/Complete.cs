using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Complete : MonoBehaviour
{
    public GameObject completeUI;
    public RoomController RC;
    public Porta_Default PD;

    public Text Count;
    public Text Defeat;

   
    void Update()
    { 
        Count.text = "" + PD.AtualMonsters;
        Defeat.text = "" + PD.MonstersDestroy;
    }
}
