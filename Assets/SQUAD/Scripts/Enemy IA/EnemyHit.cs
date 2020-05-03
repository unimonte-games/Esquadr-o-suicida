using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{

    public int dano;
    public int timeToDestroy;

    private void Start()
    {
        Invoke("DestroyThis", timeToDestroy);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Player P = other.gameObject.GetComponent<Player>();
            if (P.PlayerType)
            {
                P.LifeBar -= dano;
                P.SetDamage();
                
            }
            else
            {
                P.LifeBar -= dano;
                P.SetDamage();
             
            }
        }
    }

    void DestroyThis()
    {
        this.gameObject.SetActive(false);
    }
}
