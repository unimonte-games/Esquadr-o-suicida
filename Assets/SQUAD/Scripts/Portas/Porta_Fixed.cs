using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[AddComponentMenu("PortaScripts/Fixed")]
public class Porta_Fixed : MonoBehaviour
{
    public LevelController LC;
    public int Fixed_Unlock;
    public bool Fixed_Area;
    public GameObject Door;
    public GameObject Conector;
    public bool P1, P2;
    public Player P;

    private void Start()
    {
        LC = FindObjectOfType<LevelController>();
    }

    public void FixedUpdate()
    {
        if (Fixed_Area)
        {
            if (P1 && Input.GetKeyDown(P.Accept))
            {
                if (LC.FixedOpen >= Fixed_Unlock)
                {
                    LC.FixedOpen -= Fixed_Unlock;
                    Door.SetActive(false);
                    Conector.SetActive(true);
                    Debug.Log("Portao Liberado!");
                }
            }

            if (P2 && Input.GetKeyDown(P.Accept))
            {
                if (LC.FixedOpen >= Fixed_Unlock)
                {
                    LC.FixedOpen -= Fixed_Unlock;
                    Door.SetActive(false);
                    Conector.SetActive(true);
                    Debug.Log("Portao Liberado!");
                }
            }

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1" && Fixed_Area == false)
        {
            P1 = true;
            P2 = false;

            P = other.GetComponent<Player>();

            Fixed_Area = true;
        }

        if (other.gameObject.name == "Player2" && Fixed_Area == false)
        {
            P2 = true;
            P1 = false;

            P = other.GetComponent<Player>();

            Fixed_Area = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1" && Fixed_Area)
        {     
            Fixed_Area = false;
            P1 = false;
        }

        if (other.gameObject.name == "Player2" && Fixed_Area)
        {          
            Fixed_Area = false;
            P2 = false;
        }
    }

}
