using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    SpawnController SC_;
    public GameObject SpawnPrefab;
    public Transform RoomSize;
    public Transform[] ListSpawn;
    public Transform SceneTransformList;
    Vector3 center;
    Vector3 size;

    public int Qtd = 100;
    public int Acionados;

    public GameObject RoomController;

    void Start()
    {
        SC_ = this;

        center.x = RoomSize.transform.position.x;
        center.y = RoomSize.transform.position.y;
        center.z = RoomSize.transform.position.z;

        size.x = RoomSize.transform.localScale.x;
        size.z = RoomSize.transform.localScale.z;

        Spawn();
    }

    void Spawn()
    {
        
        for (int i = 0; i < Qtd; i++)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));

            GameObject SpawnP = Instantiate(SpawnPrefab, pos, Quaternion.identity);
            SpawnP.transform.parent = SceneTransformList;
            SpawnP.GetComponent<SpawnCheck>().SC = SC_;
        }

        Invoke("RoomControl_Start", 2f);
        
    }

    void RoomControl_Start()
    {
        Debug.Log("Iniciando sala...");
        RoomController.SetActive(true);
        RoomController.GetComponent<Porta_Default>().SC_spawn = SC_;

        DestroySpawn();


    }

    public void List(Transform spw)
    {
        for (int i = 0; i < Qtd; i++)
        {
            if(ListSpawn[i] == null)
            {
                ListSpawn[i] = spw;
                
                Acionados++;
                i = Qtd + 1; //encerrar
                
            }  
        }

    }

    public void DestroySpawn()
    {
        int StartElement = Acionados - 1;

        for (int i = 0; i <= StartElement; i++) //tirar o Box de cada spawn acionado para nao ficar colidindo com tudo
        {
            BoxCollider Obj;
            Obj = ListSpawn[i].GetComponent<BoxCollider>();
            Obj.enabled = false;

        }

    }

   
}
