using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[AddComponentMenu("PortaScripts/Double")]
public class Porta_Double : MonoBehaviour
{
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
        RoomControl = GetComponent<RoomController>();

        UI_Door.SetActive(false);
        Ui_Open.fillAmount = DoorBar / DoorMax;
    }


    private void FixedUpdate()
    {

        if (RoomControl.ColorComplete == false)
        {
            if (P1_ColorA && P2_ColorB && IsOpen == false)
            {
                UI_Door.SetActive(true);
                LastChance = false;

                timeToAdd += 0.01f;
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

                        RoomControl.CompleteRoom(2);
                    }

                }

            }

            if (LastChance)
            {
                timeToCancel += 0.01f;
                if (timeToCancel >= 2f)
                {
                    timeToCancel = 0;
                    UI_Door.SetActive(false);
                }
            }

        }

    }

}
