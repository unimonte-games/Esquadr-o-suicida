using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadNormal : MonoBehaviour
{

    public SphereCollider SC;

    private void Start()
    {
        Invoke("Cancel", 25);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && !other.GetComponent<EnemyStats>().InTarget)
        {

            other.GetComponent<EnemyStats>().OnPatrol();

        }

    }

    void Cancel()
    {
        SC.enabled = false;
    }
}
