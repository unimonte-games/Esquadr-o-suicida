using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedKey : MonoBehaviour
{

    public LevelController LC; 
    bool Fixed_Area, P1, P2;
    public int QtdPress;
    public int MaxTimeInPress;
    float timeToAdd;
    Player P;

    private void Start()
    {
        LC = FindObjectOfType<LevelController>();
    }
    public void FixedUpdate()
    {
        if (Fixed_Area)
        {
            if (P1 && Input.GetKey(P.Accept))
            {
                timeToAdd += 0.1f;
                if (timeToAdd >= 1)
                {
                    timeToAdd = 0;
                    QtdPress++;
                    if(QtdPress >= MaxTimeInPress)
                    {
                        LC.FixedOpen++;
                        QtdPress = 0;
                        this.gameObject.SetActive(false);
                    }
                }

            }

            if (P2 && Input.GetKey(P.Accept))
            {
                timeToAdd += 0.1f;
                if (timeToAdd >= QtdPress)
                {
                    timeToAdd = 0;
                    QtdPress++;
                    if (QtdPress >= MaxTimeInPress)
                    {
                        LC.FixedOpen++;
                        QtdPress = 0;
                        this.gameObject.SetActive(false);
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

            P = other.GetComponent<Player>();
            Fixed_Area = true;
        }

        if (other.gameObject.name == "Player2" && !P1)
        {
            P2 = true;
            P1 = false;

            P = other.GetComponent<Player>();
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
