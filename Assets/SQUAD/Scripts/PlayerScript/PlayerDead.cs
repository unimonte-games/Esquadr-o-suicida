using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    public bool P1_dead;
    public bool P2_dead;

    public SphereCollider SC;

    private void Start()
    {
        Invoke("Cancel", 25);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && other.GetComponent<EnemyStats>().InTarget)
        {
            other.GetComponent<EnemyStats>().Change();
        }
    }
    void Cancel()
    {
        SC.enabled = false;
    }
}
