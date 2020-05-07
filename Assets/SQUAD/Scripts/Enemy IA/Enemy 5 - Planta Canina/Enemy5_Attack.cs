using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5_Attack : MonoBehaviour
{
    public int Dano;

    public int dano_min;
    public int dano_max;


    public EnemyStats ES;
    public Transform Target;

    public GameObject Shot;
    public Transform Spawn;
    public int TimeToDestroy;

    private void Awake()
    {
        Dano = Random.Range(dano_min, dano_max);
        TimeToDestroy = Random.Range(5, 7);
    }

    private void OnEnable()
    {
        GameObject bullet1 = Instantiate(Shot, Spawn.position, Quaternion.identity) as GameObject;
        bullet1.GetComponent<EnemyHit>().dano = Dano;
        bullet1.GetComponent<EnemyHit>().timeToDestroy = TimeToDestroy;

        bullet1.GetComponent<IncreaseLife>().ES = ES;
        bullet1.GetComponent<IncreaseLife>().LifeAdd = Dano;
    }

}
