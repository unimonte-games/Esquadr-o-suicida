using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4_Attack : MonoBehaviour
{
    public int Dano;

    public int dano_min;
    public int dano_max;

    public int TimeToStun;

    public EnemyStats ES;
    public EnemyPatrol EP;
    public EnemyHit EH;

    public Transform Target;

    public int TimeToAttack;

    public int countToAttacks;
    public int EffectTime;
    public bool OnStun;

    public BoxCollider AtkFront;
    public AudioSource AtkSound;
  

    private void Awake()
    {
        Dano = Random.Range(dano_min, dano_max);
        TimeToStun = Random.Range(2, 4);
        EffectTime = Random.Range(0, 5);
        TimeToAttack = Random.Range(1, 3);
    }

    private void Start()
    {
        EH.dano = Dano;
    }


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
        AtkFront.enabled = true;
        ES.A_Attack();

        countToAttacks++;
        if (countToAttacks >= EffectTime)
        {
            countToAttacks = 0;
            EffectTime = Random.Range(0, 5);

            OnStun = true;
        }

        TimeToAttack = Random.Range(2, 5);


        AtkSound.Play();
        Invoke("CancelAtk", 2);
    }

    void CancelAtk()
    {
        AtkFront.enabled = false;
        OnStun = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && OnStun)
        {
            PlayerStun PS = other.gameObject.GetComponent<PlayerStun>();

            PS.TimeToStun = TimeToStun;
            PS.enabled = true;

        }
    }


}
