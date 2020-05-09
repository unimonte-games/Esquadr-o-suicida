using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnOutline : MonoBehaviour
{

    bool P1;
    bool P2;

    public Outline OutLineObjcet;

    private void Start()
    {
        P1 = false;
        P2 = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1" && !P1 && !P2)
        {
            P1 = true;
            OutLineObjcet.ShowLine();
            return;
        }

        if (other.gameObject.name == "Player2" && !P1 && !P2)
        {
            P2 = true;
            OutLineObjcet.ShowLine();
            return;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1" && P1)
        {
            OutLineObjcet.DisabledLine();
            P1 = false;

        }

        if (other.gameObject.name == "Player2" && P2)
        {
            OutLineObjcet.DisabledLine();
            P2 = false;

        }
    }
}

