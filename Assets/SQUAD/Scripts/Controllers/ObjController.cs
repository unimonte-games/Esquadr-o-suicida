using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjController : MonoBehaviour
{
    public int World_ID;
    public GameObject[] World_Florest;
    public GameObject[] World_Lab;
    public Transform[] SpawnToObj;

    private void Start()
    {
        if (World_ID == 0)
        {
            int n1 = Random.Range(0, 7);
            int s1 = Random.Range(0, 2);

            Instantiate(World_Florest[n1], SpawnToObj[s1].position, SpawnToObj[s1].rotation);

        }

        if(World_ID == 1)
        {
            int n2 = Random.Range(0, 3);
            int s2 = Random.Range(0, 2);

            Instantiate(World_Lab[n2], SpawnToObj[s2].position, SpawnToObj[s2].rotation);
        }
    }
}
