using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Complete : MonoBehaviour
{
    
   
    public Porta_Default PD;
    

    public Text Count;
    public Text Defeat;
    public Text AtualWave;
    public Text WaveNumbers;

 
    void Update()
    { 
        Count.text = "" + PD.AtualMonsters;
        Defeat.text = "" + PD.MonstersDestroy;
        AtualWave.text = "" + PD.AtualWave;
        WaveNumbers.text = "" + PD.WaveNumbers;
    }
}
