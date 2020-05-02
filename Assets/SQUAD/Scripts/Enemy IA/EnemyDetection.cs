using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public EnemyPatrol EP;
    public bool Check;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 13 && !Check)
        {
            
            Check = true;
            int timeToRotation = Random.Range(3, 7);
            Invoke("ReCheck", timeToRotation);
            EP.EnemyHit(timeToRotation);
           

        }
    }

    void ReCheck()
    {
        Check = false;
    }
}
