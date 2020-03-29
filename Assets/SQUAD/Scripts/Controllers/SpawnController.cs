using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject SpawnPrefab;
    public Transform RoomSize;
    Vector3 center;
    Vector3 size;

    public int Qtd;

    void Start()
    {
        center.x = RoomSize.transform.position.x;
        center.y = RoomSize.transform.position.y;
        center.z = RoomSize.transform.position.z;

        size.x = RoomSize.transform.localScale.x;
        size.z = RoomSize.transform.localScale.z;

        Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i <= Qtd; i++)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));

            Instantiate(SpawnPrefab, pos, Quaternion.identity);
        }
        
    }

   
}
