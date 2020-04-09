using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingDestroyEnemy : MonoBehaviour
{
    public int TypeEnemy;
    public Transform PlayerTarget;
    public Porta_Default P_default;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            P_default.MonstersDefeat();
            Destroy(gameObject);
        }
    }
}
