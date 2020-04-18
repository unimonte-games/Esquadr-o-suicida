using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonBomb : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyBomb", 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
           
        }
    }

    void DestroyBomb()
    {
        this.gameObject.SetActive(false);
    }
}
