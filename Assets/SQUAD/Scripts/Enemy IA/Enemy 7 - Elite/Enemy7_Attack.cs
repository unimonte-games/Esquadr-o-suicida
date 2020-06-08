using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy7_Attack : MonoBehaviour
{
    public int Dano;

    public EnemyStats ES;
    public EnemyPatrol EP;

    public Transform Target;

    public GameObject Shot;
    public Transform Spawn;
    public float Force;
    public float TimeToAttack;

    public GameObject BombEffect;

    public AudioSource AtkSound;


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
            TimeToAttack = Random.Range(3, 10);
            ES.A_Attack();
            Invoke("Effect", 1f);

        }
    }


    void Effect()
    {

        AtkSound.Play();
        TimeToAttack = Random.Range(3, 10);

        GameObject bullet1 = Instantiate(Shot, Spawn.position, Quaternion.identity) as GameObject;
        bullet1.GetComponent<Rigidbody>().AddForce(Spawn.transform.forward * Force);
        bullet1.GetComponent<EnemyHit>().dano = Dano;
        bullet1.GetComponent<EnemyHit>().timeToDestroy = 10;

    }

    public void Bomb()
    {
        Instantiate(BombEffect, Spawn.position, Spawn.rotation);
    }

}
