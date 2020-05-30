using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DI_Show : MonoBehaviour
{
    public GameObject Info;

    void Start()
    {
        Info.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SetInfo();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Info.SetActive(false);
            CancelInvoke("CancelInfo");
        }
    }

    void SetInfo()
    {
        Info.SetActive(true);
        Invoke("CancelInfo", 3);
    }

    void CancelInfo()
    {
        Info.SetActive(false);
    }
}
