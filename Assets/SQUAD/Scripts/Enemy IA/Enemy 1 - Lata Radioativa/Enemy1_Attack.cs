using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_Attack : MonoBehaviour
{
    public EnemyStats ES;
    public EnemyPatrol EP;

    public Transform Target;

    public GameObject Shot;
    public Transform Spawn;
    public int TimeToAttack;

    private void OnEnable()
    {
        Debug.Log("Attack");
    }


}
