using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConectorTrigger : MonoBehaviour
{
    public ConnectorRoom CR;

    private void Start()
    {
        Invoke("Cancel", 10);
    }

    void Cancel()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Conector")
        {
            CR.CR = other.gameObject.GetComponent<ConnectorRoom>();
            Debug.Log("Conector Search");
        }
    }
}
