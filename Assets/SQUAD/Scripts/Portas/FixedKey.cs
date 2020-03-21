﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedKey : MonoBehaviour
{

    public RoomController R;
    bool Fixed_Area, P1, P2;
    public int QtdPress;
    public int MaxTimeInPress;
    float timeToAdd;



    public void FixedUpdate()
    {
        if (Fixed_Area)
        {
            if (P1 && Input.GetKey(KeyCode.Q))
            {
                timeToAdd += 0.01f;
                if (timeToAdd >= 1)
                {
                    timeToAdd = 0;
                    QtdPress++;
                    if(QtdPress >= MaxTimeInPress)
                    {
                        R.FixedComplete++;
                        QtdPress = 0;
                        Destroy(gameObject);
                    }
                }

            }

            if (P2 && Input.GetKey(KeyCode.E))
            {
                timeToAdd += 0.01f;
                if (timeToAdd >= QtdPress)
                {
                    timeToAdd = 0;
                    QtdPress++;
                    if (QtdPress >= MaxTimeInPress)
                    {
                        R.FixedComplete++;
                        QtdPress = 0;
                        Destroy(gameObject);
                    }
                }
            }

        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1" && !P2)
        {
            P1 = true;
            P2 = false;

            Fixed_Area = true;
        }

        if (other.gameObject.name == "Player2" && !P1)
        {
            P2 = true;
            P1 = false;

            Fixed_Area = true;
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1" && Fixed_Area && P1)
        {
            Fixed_Area = false;
            P1 = false;
            timeToAdd = 0;
        }

        if (other.gameObject.name == "Player2" && Fixed_Area && P2)
        {
            Fixed_Area = false;
            P2 = false;
            timeToAdd = 0;
        }
    }

}
