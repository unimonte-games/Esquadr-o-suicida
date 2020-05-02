using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_Attack : MonoBehaviour
{
    public EnemyStats ES;

    public GameObject Shot;
    public Transform Spawn;
    public int TimeToAttack;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ES.PlayerTarget = other.gameObject.transform;
            ES.PlayerInArea = true;

            Debug.Log("Player Detectado!");
        }
    }

}
