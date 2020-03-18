﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


[AddComponentMenu("PortaScripts/Color")]
public class Porta_Color : MonoBehaviour
{

    Porta_Color C;
    RoomController RoomControl;

    public GameObject Door;
    public GameObject UI_Door;
    public Image Ui_Open;
    float DoorBar = 0f;
    public float DoorMax = 10f;

    public bool P1_ColorA, P2_ColorB, LastChance, IsOpen;
    float timeToAdd, timeToCancel;

    

    void Start()
    {

        C = GetComponent<Porta_Color>();
        RoomControl = GetComponent<RoomController>();

        UI_Door.SetActive(false);
        Ui_Open.fillAmount = DoorBar / DoorMax;

    }

    private void FixedUpdate()
    {
        if (P1_ColorA && P2_ColorB && IsOpen == false)
        {
            UI_Door.SetActive(true);
            LastChance = false;

             timeToAdd+= 0.1f;
            if (timeToAdd >= 2f)
            {
                timeToAdd = 0;
                DoorBar++;
                Ui_Open.fillAmount = DoorBar / DoorMax;

                if(DoorBar >= DoorMax)
                {
                    IsOpen = true;
                    Door.SetActive(false);
                    Debug.Log("Portao Liberado!");

                    RoomControl.CompleteRoom();
                }

            }

        }
       
        if (LastChance)
        {
            timeToCancel += 0.1f;
            if (timeToCancel >= 5f)
            {
                timeToCancel = 0;
                UI_Door.SetActive(false);
            }
        }
        
    }
  
}
