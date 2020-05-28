using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forced : MonoBehaviour
{
    
    private void Start()
    {
        Invoke("Cancel", 5);
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
        this.gameObject.SetActive(false);
    }
}
