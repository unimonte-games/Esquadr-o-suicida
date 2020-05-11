using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGB : MonoBehaviour
{
    public MeshRenderer MR;
    public Material[] Color;
    
    int Number;

    private void OnEnable()
    {
        Number = Random.Range(0, 14);
        MR.material = Color[Number];
    }
}
