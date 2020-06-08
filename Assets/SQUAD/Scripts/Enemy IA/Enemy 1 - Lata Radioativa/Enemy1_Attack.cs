using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_Attack : MonoBehaviour
{
    
    public int Dano;

    public int dano_min;
    public int dano_max;

    public EnemyStats ES;
    public EnemyPatrol EP;

    public Transform Target;

    public GameObject Shot;
    public Transform Spawn;
    public float Force;
    public int TimeToAttack;

    public AudioSource AtkSound;
    public bool isSoundInGosma;

    private void Awake()
    {
        Dano = Random.Range(dano_min, dano_max);
    }
   

    private void OnEnable()
    {
        InvokeRepeating("CombatCountDown", 1, TimeToAttack);
    }

    private void OnDisable()
    {
        CancelInvoke("CombatCountDown");
        CancelInvoke("Effect");
    }


    void CombatCountDown()
    {
        {
            ES.A_Attack();

            TimeToAttack = Random.Range(3, 10);

            AtkSound.Play();
            Invoke("Effect", 0.3f);

        }
    }

    void Effect()
    {
        GameObject bullet1 = Instantiate(Shot, Spawn.position, Quaternion.identity) as GameObject;
        bullet1.GetComponent<Rigidbody>().AddForce(transform.forward * Force);
        bullet1.GetComponent<EnemyHit>().dano = Dano;
        bullet1.GetComponent<EnemyHit>().timeToDestroy = 2;
        bullet1.GetComponent<GosmaEffect>().isSound = isSoundInGosma;
    }

   
}
