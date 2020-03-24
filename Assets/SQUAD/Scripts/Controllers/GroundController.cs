using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public GroundController G;
    public TypeGroundList TypeGroundList;
    
    public int TypeRoom;
    public GameObject GroundPrefab;

    private void Start()
    {
        TypeGroundList = FindObjectOfType<TypeGroundList>();
        TypeGroundList.GroundRandom(G, TypeRoom);
    }
}
