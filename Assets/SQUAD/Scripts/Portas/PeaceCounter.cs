using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeaceCounter : MonoBehaviour
{
    public Porta_Default PD;
    float CounterToSurvivor;
    public Image peaceBar;

    private void OnEnable()
    {
        InvokeRepeating("Countdown", 0, 1);
    }

    void Countdown()
    {
        CounterToSurvivor++;
        peaceBar.fillAmount = CounterToSurvivor / PD.TimeToSurviveInPeace;

        if (CounterToSurvivor >= PD.TimeToSurviveInPeace)
        {
            CancelInvoke("Countdown");
            PD.PeaceDestroyAllEnemys();
        }
    }
}
