using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEliteShot : MonoBehaviour
{
    public int Force;

    private void FixedUpdate()
    {
       GetComponent<Rigidbody>().AddForce(transform.forward * Force);
    }
}
