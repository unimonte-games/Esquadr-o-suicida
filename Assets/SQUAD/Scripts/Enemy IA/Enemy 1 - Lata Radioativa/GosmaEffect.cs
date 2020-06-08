using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GosmaEffect : MonoBehaviour
{
    
    public int dano;
    public GameObject GosmaArea;

    public AudioSource AtkSound;
    public bool isSound;
    bool isTrigger;

    void Start()
    {
        dano = GetComponent<EnemyHit>().dano;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 18 && !isTrigger)
        {
            isTrigger = true;
            GameObject gosma = Instantiate(GosmaArea, new Vector3(transform.position.x, -0.88f, transform.position.z), transform.rotation) as GameObject;
            gosma.GetComponent<EnemyHit>().dano = dano;
            gosma.GetComponent<EnemyHit>().timeToDestroy = 5;

            if (isSound)
            {
                AtkSound.Play();
            }

            Invoke("Cancel", 0.5f);
        }
    }

    void Cancel()
    {
        this.gameObject.SetActive(true);
    }

}
