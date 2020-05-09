using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public EnemyPatrol EP;
    public bool Check;
    int timeToRotation;
    public int R_min;
    public int R_max;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 13 && !Check)
        {
            
            Check = true;
            timeToRotation = Random.Range(R_min, R_max);
            Invoke("ReCheck", timeToRotation);
            EP.EnemyHit(timeToRotation);
           

        }
    }

    void ReCheck()
    {
        Check = false;
    }
}
