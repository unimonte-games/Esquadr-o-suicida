using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingDestroyEnemy : MonoBehaviour
{
    public int TypeEnemy;
    public Transform PlayerTarget;
    public Porta_Default P_default;
    public GameObject EnergyCoin;

    bool Drop;
    int tempRandom;
    int QtdEnergy;
    public Transform RoomSize;
    Vector3 center;
    Vector3 size;

    private void Awake()
    {
        
        tempRandom = Random.Range(0, 100);
        if (tempRandom > 80)
        {
            Drop = true;

            center.x = RoomSize.transform.position.x;
            center.y = RoomSize.transform.position.y;
            center.z = RoomSize.transform.position.z;

            size.x = RoomSize.transform.localScale.x;
            size.z = RoomSize.transform.localScale.z;


            if (Drop)
            {
                if (tempRandom >= 80 && tempRandom <= 85)
                {
                    int quantidadeRandom = Random.Range(1, 2);
                    QtdEnergy = quantidadeRandom;
                    return;
                }

                if (tempRandom >= 86 && tempRandom <= 90)
                {
                    int quantidadeRandom = Random.Range(1, 3);
                    QtdEnergy = quantidadeRandom;
                    return;
                }

                if (tempRandom >= 91 && tempRandom <= 95)
                {
                    int quantidadeRandom = Random.Range(1, 4);
                    QtdEnergy = quantidadeRandom;
                    return;
                }

                if (tempRandom >= 96 && tempRandom <= 100)
                {
                    int quantidadeRandom = Random.Range(1, 5);
                    QtdEnergy = quantidadeRandom;
                    return;
                }


            }
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player1")
        {
            P_default.MonstersDefeat(1,TypeEnemy);
            this.gameObject.SetActive(false);
            if (Drop)
            {
                DropEnergy();
            }
            
        }

        if (other.gameObject.name == "Player2")
        {
            P_default.MonstersDefeat(2,TypeEnemy);
            this.gameObject.SetActive(false);
            if (Drop)
            {
                DropEnergy();
            }
        }

        if (other.gameObject.name == "Ball")
        {
            this.gameObject.SetActive(false);
            if (Drop)
            {
                DropEnergy();
            }
        }

       
    }

    void DropEnergy()
    {
        Debug.Log("Drop Energy");
        for (int i = 0; i < QtdEnergy; i++)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), -4 , Random.Range(-size.z / 2, size.z / 2));
            GameObject SpawnP = Instantiate(EnergyCoin, pos, Quaternion.identity);
            
        }
    }
}
