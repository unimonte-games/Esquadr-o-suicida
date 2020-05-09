using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy9_Sucata : MonoBehaviour
{
    public int Dano;

    public int dano_min;
    public int dano_max;

    public EnemyHit HH;
    public BoxCollider Attack;

    public Transform Target;

    public float TimeToAttack;

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
        InvokeRepeating("CombatCountDown", 0, TimeToAttack);
    }

    private void OnDisable()
    {
        CancelInvoke("CombatCountDown");
    }


    void CombatCountDown()
    {
        Attack.enabled = true;
        Invoke("CancelAtk", TimeToAttack);
    }

    void CancelAtk()
    {
        Attack.enabled = false;
    }


}