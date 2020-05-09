using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy8_Golem : MonoBehaviour
{
    
    bool OnAttack;
    public EnemyHit HH;

    public Transform Target;

    public Animation ShotAnin;
    public GameObject Area;

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
            TimeToAttack = Random.Range(10, 12);
            if (!OnAttack)
            {
                OnAttack = true;
                ShotAnin.Play("LeiserGolem");
                Invoke("Cancel", 2);
            }

        }
    }

    void Cancel()
    {
        OnAttack = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Area.SetActive(true);
            Invoke("CancelArea",2);
        }
    }

    void CancelArea()
    {
        Area.SetActive(false);
    }

    

}
