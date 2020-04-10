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
        if(other.gameObject.name == "Player1")
        {
            P_default.MonstersDefeat(1,TypeEnemy);
            this.gameObject.SetActive(false);
        }

        if (other.gameObject.name == "Player2")
        {
            P_default.MonstersDefeat(2,TypeEnemy);
            this.gameObject.SetActive(false);
        }
    }
}
