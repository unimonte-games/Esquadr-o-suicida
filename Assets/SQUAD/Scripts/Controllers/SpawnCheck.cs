using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCheck : MonoBehaviour
{
    public SpawnController SC;
    public Transform SpawnObj;

    private void Start()
    {
        Invoke("Atived", 1);
        Invoke("DestroyThis", 5f);
    }

    void Atived()
    {
        SC.List(SpawnObj);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            Destroy(gameObject);
            return;

        }         
    }

    void DestroyThis()
    {
        this.gameObject.SetActive(false);        
    }

}
