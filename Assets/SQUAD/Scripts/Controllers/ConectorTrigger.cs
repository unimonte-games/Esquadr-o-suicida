using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConectorTrigger : MonoBehaviour
{
    public ConnectorRoom Room;

    public bool TopDown;
    public bool LeftRight;

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
        if (TopDown && other.gameObject.layer == 23)
        {
            ConectorTrigger CT = other.gameObject.GetComponent<ConectorTrigger>();
            Room.CR = CT.Room;
            Debug.Log("Conector Top to Down");
            return;
        }

        if (LeftRight && other.gameObject.layer == 24)
        {
            ConectorTrigger CT = other.gameObject.GetComponent<ConectorTrigger>();
            Room.CR = CT.Room;
            Debug.Log("Conector Left to Right");
            return;
        }
    }
}
