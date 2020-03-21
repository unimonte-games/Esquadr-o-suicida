﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[AddComponentMenu("PortaScripts/Timer")]
public class Porta_Timer : MonoBehaviour
{
    public RoomController RoomControl;

    public GameObject Door;
    public GameObject UI_Door;
    public Image Ui_Open;
    public float DoorBar = 0f;
    public float DoorMax = 10f;

    public bool Player, LastChance, IsOpen;
    float timeToAdd, timeToCancel;

    void Start()
    {
        RoomControl = GetComponent<RoomController>();

        UI_Door.SetActive(false);
        Ui_Open.fillAmount = DoorBar / DoorMax;
    }

    private void FixedUpdate()
    {

        if (RoomControl.TimerComplete == false)
        {
            if (Player && IsOpen == false)
            {
                UI_Door.SetActive(true);
                LastChance = false;

                timeToAdd += 0.1f;
                if (timeToAdd >= 2f)
                {
                    timeToAdd = 0;
                    DoorBar++;
                    Ui_Open.fillAmount = DoorBar / DoorMax;

                    if (DoorBar >= DoorMax)
                    {
                        IsOpen = true;
                        Door.SetActive(false);
                        Debug.Log("Portao Liberado!");

                        RoomControl.CompleteRoom(3);
                    }

                }

            }

            if (LastChance)
            {
                timeToCancel += 0.1f;
                if (timeToCancel >= 1f)
                {
                    DoorBar = 0;
                    UI_Door.SetActive(false);
                    Ui_Open.fillAmount = DoorBar / DoorMax;

                }
            }

        }

    }


}
