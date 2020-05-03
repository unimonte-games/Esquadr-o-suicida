using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_Attack : MonoBehaviour
{
    [Range(1, 3)]
    public int Dano;

    public EnemyStats ES;
    public EnemyPatrol EP;

    public Transform Target;

    public GameObject Shot;
    public Transform Spawn;
    public float Force;
    public int TimeToAttack;

    

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
        {
            TimeToAttack = Random.Range(3, 10);

            GameObject bullet1 = Instantiate(Shot, Spawn.position, Quaternion.identity) as GameObject;
            bullet1.GetComponent<Rigidbody>().AddForce(transform.forward * Force);
            bullet1.GetComponent<EnemyHit>().dano = Dano;
            bullet1.GetComponent<EnemyHit>().timeToDestroy = 2;

        }


    }

   
}
