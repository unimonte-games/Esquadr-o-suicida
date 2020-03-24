using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeGroundList : MonoBehaviour
{
    public GameObject[] Type1;
    public GameObject[] Type2;
    public GameObject[] Type3;
    public GameObject[] Type4;
    public GameObject[] Type5;
    public GameObject[] Type6;
    public GameObject[] Type7;
    public GameObject[] Type8;
    public GameObject[] Type9;
    public GameObject[] Type10;


    public void GroundRandom(GroundController Ground, int Type)
    {
        int randomNumber = Random.Range(0, 3);


        if (Type == 1)
        {
            Ground.GroundPrefab = Type1[randomNumber];
        }

        if (Type == 2)
        {
            Ground.GroundPrefab = Type2[randomNumber];
        }

        if (Type == 3)
        {
            Ground.GroundPrefab = Type3[randomNumber];
        }

        if (Type == 4)
        {
            Ground.GroundPrefab = Type4[randomNumber];
        }

        if (Type == 5)
        {
            Ground.GroundPrefab = Type5[randomNumber];
        }

        if (Type == 6)
        {
            Ground.GroundPrefab = Type6[randomNumber];
        }

        if (Type == 7)
        {
            Ground.GroundPrefab = Type7[randomNumber];
        }

        if (Type == 8)
        {
            Ground.GroundPrefab = Type8[randomNumber];
        }

        if (Type == 9)
        {
            Ground.GroundPrefab = Type9[randomNumber];
        }

        if (Type == 10)
        {
            Ground.GroundPrefab = Type10[randomNumber];
        }
    }

}
