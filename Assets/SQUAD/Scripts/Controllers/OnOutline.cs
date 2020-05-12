using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnOutline : MonoBehaviour
{

    bool P1;
    bool P2;

    bool PlayerDiscart;

    public bool IsItem;
    public GameObject UI_item;

    public Outline OutLineObjcet;

    private void Start()
    {
        P1 = false;
        P2 = false;
        PlayerDiscart = true;

        Invoke("Cancel", 2);
    }

    void Cancel()
    {
        PlayerDiscart = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1" && !P1 && !P2)
        {
            P1 = true;
            OutLineObjcet.ShowLine();

            if (IsItem)
            {
                UI_item.SetActive(true);
            }
            return;
        }

        if (other.gameObject.name == "Player2" && !P1 && !P2)
        {
            P2 = true;
            OutLineObjcet.ShowLine();
            if (IsItem)
            {
                UI_item.SetActive(true);
            }
            return;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1" && P1)
        {
            OutLineObjcet.DisabledLine();
            P1 = false;

            if (IsItem)
            {
                UI_item.SetActive(false);
            }
        }

        if (other.gameObject.name == "Player2" && P2)
        {
            OutLineObjcet.DisabledLine();
            P2 = false;

            if (IsItem)
            {
                UI_item.SetActive(false);
            }

        }

        if(PlayerDiscart && other.gameObject.tag == "Player")
        {
            OutLineObjcet.DisabledLine();
            
            if (IsItem)
            {
                PlayerDiscart = false;
                UI_item.SetActive(false);
            }
        }

    }

   

}

