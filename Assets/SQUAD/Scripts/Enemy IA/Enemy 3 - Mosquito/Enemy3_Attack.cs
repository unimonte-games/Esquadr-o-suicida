using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3_Attack : MonoBehaviour
{
    public int Dano;

    public int dano_min;
    public int dano_max;

    public int TimeToSlow;

    public EnemyStats ES;
    public EnemyPatrol EP;
    public EnemyHit EH;

    public Transform Target;

    public int TimeToAttack;

    public int countToAttacks;
    public int EffectTime;
    public bool OnSlow;

    public BoxCollider AtkFront;
    public AudioSource AtkSound;
    

    private void Awake()
    {
        Dano = Random.Range(dano_min, dano_max);
        TimeToSlow = Random.Range(3, 5);
        EffectTime = Random.Range(0, 3);
        TimeToAttack = Random.Range(2, 5);
    }

    private void Start()
    {
        EH.dano = Dano;
    }

    private void OnEnable()
    {
        InvokeRepeating("CombatCountDown", 1, TimeToAttack);
        CancelInvoke("Effect");
    }

    private void OnDisable()
    {
        CancelInvoke("CombatCountDown");
    }

    void CombatCountDown()
    {

        ES.A_Attack();
        Invoke("Effect", 1.5f);

    }

    void Effect()
    {
        AtkFront.enabled = true;

        countToAttacks++;
        if(countToAttacks >= EffectTime)
        {
            countToAttacks = 0;
            EffectTime = Random.Range(0, 3);

            OnSlow = true;
            Debug.Log("Slow Aplicado!");
        }

        TimeToAttack = Random.Range(2, 5);

        AtkSound.Play();
        Invoke("CancelAtk",2);
    }

    void CancelAtk()
    {
        AtkFront.enabled = false;
        OnSlow = false;
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && OnSlow)
        {
            PlayerSlow PS = other.gameObject.GetComponent<PlayerSlow>();

            PS.TimeToSlow = TimeToSlow;
            PS.enabled = true;
            
        }
    }


}
