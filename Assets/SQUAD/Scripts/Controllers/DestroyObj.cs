using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("D", 1);
    }

    void D()
    {
        this.gameObject.SetActive(false);
    }
}
