using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public int time;
    public bool PlayerDestroy;

    private void Start()
    {
        Invoke("destroyThis", time);
    }

    void destroyThis()
    {
        this.gameObject.SetActive(false);
    }

}
