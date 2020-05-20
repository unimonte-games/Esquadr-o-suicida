using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6_Attack : MonoBehaviour
{
    public int Dano;

    public int dano_min;
    public int dano_max;

    public EnemyHit HH;
    public BoxCollider Attack;
    public EnemyStats ES;
    public Transform Target;

    private void Awake()
    {
        Dano = Random.Range(dano_min, dano_max);
    }

    private void Start()
    {
        HH.dano = Dano;
    }

    private void OnEnable()
    {
        InvokeRepeating("CombatCountDown", 1, 2);
    }

    private void OnDisable()
    {
        CancelInvoke("CombatCountDown");

    }

    void CombatCountDown()
    {
        
            ES.A_Attack();
            Attack.enabled = true;
            Invoke("CancelAtk", 1);
        
    }


    void CancelAtk()
    {
        Attack.enabled = false;
    }


 }