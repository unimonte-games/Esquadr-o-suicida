using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemArea : MonoBehaviour
{
    public int Dano;
    public Animation AreaShot;
    public int TimeToAttack;

    private void OnEnable()
    {
        InvokeRepeating("CombatCountDown", 1, TimeToAttack);
    }

    private void OnDisable()
    {
        CancelInvoke("CombatCountDown");
    }


    void CombatCountDown()
    {
        {
            
            AreaShot.Play("AreaGolem");

        }

    }
}
