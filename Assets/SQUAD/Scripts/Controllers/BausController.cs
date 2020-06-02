using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BausController : MonoBehaviour
{
    public GameObject[] BausObj;
    public Transform[] Spawn;
    int BauEscolhido;
    bool Nada;

    private void Awake()
    {
        int BauNumber = Random.Range(0, 115);

        if(BauNumber <= 20) //nada 20
        {
            Nada = true;
        }

        if (BauNumber >= 21 && BauNumber <= 51) //Comum 40
        {
            BauEscolhido = 0;
        }

        if (BauNumber >= 52 && BauNumber <= 72) //Epico 30
        {
            BauEscolhido = 1;
        }

        if (BauNumber >= 73 && BauNumber <= 93) //Lendario 30
        {
            BauEscolhido = 2;
        }

        if (BauNumber >= 94 && BauNumber <= 104) // Weapon kit 10
        {
            BauEscolhido = 3;
        }

        if (BauNumber >= 105 && BauNumber <= 115) //Medic kit 10
        {
            BauEscolhido = 4;
        }

    }

    private void OnEnable()
    {
        if (!Nada)
        {
            int S = Random.Range(0, 2);
            Instantiate(BausObj[BauEscolhido], Spawn[S].transform.position, Spawn[S].transform.rotation);
        }
    }


}
