using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy8_Golem : MonoBehaviour
{
    
    bool OnAttack;
    public EnemyHit HH;

    public Transform Target;

    public Animation ShotAnin;
    public float TimeToAttack;

    private void OnEnable()
    {
        InvokeRepeating("CombatCountDown", 3, TimeToAttack);
    }

    private void OnDisable()
    {
        CancelInvoke("CombatCountDown");
    }


    void CombatCountDown()
    {
        {
            TimeToAttack = Random.Range(3, 7);
            if (!OnAttack)
            {
                OnAttack = true;
                ShotAnin.Play();
                Invoke("Cancel", 2);
            }

        }
    }

    void Cancel()
    {
        OnAttack = false;
    }

}
