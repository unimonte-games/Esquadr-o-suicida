using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5_Attack : MonoBehaviour
{
    public int Dano;

    public EnemyStats ES;
    public EnemyPatrol EP;

    public Transform Target;

    public GameObject Shot;
    public Transform Spawn;
    public int TimeToDestroy;


    private void Awake()
    {
        TimeToDestroy = Random.Range(5, 7);
    }
    private void OnEnable()
    {
        GameObject bullet1 = Instantiate(Shot, Spawn.position, Quaternion.identity) as GameObject;
        bullet1.GetComponent<EnemyHit>().dano = Dano;
        bullet1.GetComponent<EnemyHit>().timeToDestroy = TimeToDestroy;
        Invoke("Cancel", 1);
    }

    void Cancel()
    {
        this.enabled = false;
    }

    

}
