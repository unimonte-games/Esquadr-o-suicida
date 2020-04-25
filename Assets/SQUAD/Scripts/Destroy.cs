using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float time;
    public bool PlayerDestroy;
    public int Hit;

    private void Start()
    {
        Invoke("destroyThis", time);
    }

    void destroyThis()
    {
        this.gameObject.SetActive(false);
    }

}
