using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    public EnemyPatrol EP;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 11)
        {
            EP.ObjectHit();
        }
    }
}
