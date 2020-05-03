using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GosmaEffect : MonoBehaviour
{
    
    public int dano;
    public GameObject GosmaArea;


    void Start()
    {
        dano = GetComponent<EnemyHit>().dano;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 18)
        {
           GameObject gosma =  Instantiate(GosmaArea, new Vector3 (transform.position.x, 0, transform.position.z), transform.rotation) as GameObject;
            gosma.GetComponent<EnemyHit>().dano = dano;
            gosma.GetComponent<EnemyHit>().timeToDestroy = 5;

            this.gameObject.SetActive(false);
        }
    }

}
