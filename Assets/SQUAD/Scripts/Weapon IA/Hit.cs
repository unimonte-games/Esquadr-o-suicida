using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public float time;
    public bool PlayerDestroy;
    public int Hit_Plant;
    public int Hit_Tech;


    private void Start()
    {
        Invoke("destroyThis", time);
    }

    void destroyThis()
    {
        this.gameObject.SetActive(false);
    }

}
