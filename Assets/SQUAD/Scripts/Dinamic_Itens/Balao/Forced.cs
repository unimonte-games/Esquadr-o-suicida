using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forced : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && other.GetComponent<EnemyStats>().InTarget)
        {
            other.GetComponent<EnemyStats>().Change();
        }

        if (other.gameObject.tag == "Enemy" && !other.GetComponent<EnemyStats>().InTarget)
        {

            other.GetComponent<EnemyStats>().OnPatrol();

        }
    }
    
}
