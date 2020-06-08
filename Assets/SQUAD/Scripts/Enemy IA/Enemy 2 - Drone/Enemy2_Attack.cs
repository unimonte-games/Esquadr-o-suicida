﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_Attack : MonoBehaviour
{
    public int Dano;

    public EnemyStats ES;
    public EnemyPatrol EP;

    public Transform Target;

    public GameObject Shot;
    public Transform Spawn;
    public GameObject Eff;
    public float Force;
    public float TimeToAttack;
    public AudioSource AtkSound;

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

        ES.A_Attack();
        AtkSound.Play();
        GameObject E = Instantiate(Eff, Spawn.transform.position, Spawn.transform.rotation) as GameObject;
        E.transform.parent = Spawn;

        GameObject bullet1 = Instantiate(Shot, Spawn.position, Quaternion.identity) as GameObject;
        bullet1.GetComponent<Rigidbody>().AddForce(Spawn.transform.forward * Force);
        bullet1.GetComponent<EnemyHit>().dano = Dano;
        bullet1.GetComponent<EnemyHit>().timeToDestroy = 2;

    }
    

}
