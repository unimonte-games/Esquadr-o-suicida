using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeaceCounter : MonoBehaviour
{
    public Porta_Default PD;
    public float TimeToSurvivor;
    float CounterToSurvivor;
    public Image peaceBar;

    void FixedUpdate()
    {
        CounterToSurvivor += 0.01f;
        peaceBar.fillAmount = CounterToSurvivor / TimeToSurvivor;
        if (CounterToSurvivor >= TimeToSurvivor)
        {
            PD.PeaceDestroyAllEnemys();
        }
    }
}
