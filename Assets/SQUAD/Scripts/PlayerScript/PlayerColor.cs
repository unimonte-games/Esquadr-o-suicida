using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{

    public int Color_number;
    public bool RandomColor;
    public int SetVelocityToRandom = 2;
 
    public GameObject[] Colors;

   

    private void Start()
    {
        Colors[Color_number].SetActive(true);

        if (RandomColor)
        {
            InvokeRepeating("ChangeColor",0, SetVelocityToRandom);   
        }
    }

    void  ChangeColor()
    {
        Colors[Color_number].SetActive(false);

        int R = Random.Range(0, 15);
        Color_number = R;
        Colors[Color_number].SetActive(true);
        
    }

    
}
