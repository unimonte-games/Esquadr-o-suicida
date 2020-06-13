using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyFreeSpawn : MonoBehaviour
{

    public GameObject SpawnEnergy;
    public Transform RoomSize;
    public Transform[] ListRoomSize;
    public Transform SceneTransformList;
    Vector3 center;
    Vector3 size;
    bool ToDrop;

    private void Awake()
    {
        int CheckYourLucky = Random.Range(0, 100);
        if(CheckYourLucky > 80)
        {
            ToDrop = true;
            int RL = Random.Range(0, 4);
            RoomSize = ListRoomSize[RL];
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
        int Qtd = Random.Range(8, 17);
        for (int i = 0; i < Qtd; i++)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));

            GameObject SpawnP = Instantiate(SpawnEnergy, pos, Quaternion.identity);
            SpawnP.transform.parent = SceneTransformList;
            
        }

        Debug.Log("Energy Drop");

    }
}
