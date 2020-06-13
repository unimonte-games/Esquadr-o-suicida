using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysFreeSpawn : MonoBehaviour
{
    public GameObject[] SpawnEnergy;
    public Transform RoomSize;
    public Transform[] ListRoomSize;
    public Transform SceneTransformList;
    Vector3 center;
    Vector3 size;
    bool ToDrop;
    int IDKey;

    private void Awake()
    {
        int CheckYourLucky = Random.Range(0, 100);
        if (CheckYourLucky > 10)
        {
            ToDrop = true;
            int RL = Random.Range(0, 4);
            RoomSize = ListRoomSize[RL];

            int CheckYourKey = Random.Range(0, 100);
            if(CheckYourKey < 30)
            {
                IDKey = 0;
            }

            if (CheckYourKey >= 31 && CheckYourKey <= 60)
            {
                IDKey = 1;
            }

            if (CheckYourKey >= 61 && CheckYourKey <= 70)
            {
                IDKey = 2;
            }

            if (CheckYourKey >= 71 && CheckYourKey <= 80)
            {
                IDKey = 3;
            }

            if (CheckYourKey >= 81 && CheckYourKey <= 90)
            {
                IDKey = 4;
            }

            if (CheckYourKey >= 91 && CheckYourKey <= 100)
            {
                IDKey = 5;
            }
        }

    }

    void Start()
    {
        if (ToDrop)
        {

            center.x = RoomSize.transform.position.x;
            center.y = RoomSize.transform.position.y;
            center.z = RoomSize.transform.position.z;

            size.x = RoomSize.transform.localScale.x;
            size.z = RoomSize.transform.localScale.z;

            Spawn();
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    void Spawn()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));

        GameObject SpawnP = Instantiate(SpawnEnergy[IDKey], pos, Quaternion.identity);
        SpawnP.transform.parent = SceneTransformList;

        Debug.Log("Key Free Drop");

    }
}
