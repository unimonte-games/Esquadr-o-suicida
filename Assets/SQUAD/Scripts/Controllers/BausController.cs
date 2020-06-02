using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BausController : MonoBehaviour
{
    public GameObject[] BausObj;
    int BauEscolhido;

    private void Awake()
    {
        int BauNumber = Random.Range(0, 5);
    }

    void Start()
    {
        
    }

    
}
