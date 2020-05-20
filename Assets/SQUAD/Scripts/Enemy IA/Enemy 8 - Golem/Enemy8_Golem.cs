using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy8_Golem : MonoBehaviour
{
    
    bool OnAttack;
    public EnemyHit HH;

    public Transform Target;

    public GameObject Area;

    public EnemyStats ES;
 

    public float TimeToAttack;
    
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

        TimeToAttack = Random.Range(15,20);
        if (!OnAttack)
        {
            OnAttack = true;
            ES.A_Attack();
            Invoke("Cancel", 10);
        }


    }

    void Cancel()
    {
        OnAttack = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && OnAttack)
        {
            ES.A_AttackExtra();
        }
    }

}
