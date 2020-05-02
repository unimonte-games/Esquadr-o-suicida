using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    public EnemyPatrol EP;
    public bool Check;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == 11 && !Check)
        {
            Check = true;
            Invoke("ReCheck", 3f);
            EP.ObjectHit(); 
        }
    }

    void ReCheck()
    {
       Check = false;
    }
   
}
