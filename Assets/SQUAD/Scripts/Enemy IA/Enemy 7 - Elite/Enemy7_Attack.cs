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

            Invoke("Effect", 0.5f);

        }
    }


    void Effect()
    {
        {
            ES.A_Attack();
            TimeToAttack = Random.Range(3, 5);

            GameObject bullet1 = Instantiate(Shot, Spawn.position, Quaternion.identity) as GameObject;
            bullet1.GetComponent<Rigidbody>().AddForce(Spawn.transform.forward * Force);
            bullet1.GetComponent<EnemyHit>().dano = Dano;
            bullet1.GetComponent<EnemyHit>().timeToDestroy = 10;

            
        }
    }

}
