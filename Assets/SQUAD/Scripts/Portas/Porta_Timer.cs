using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[AddComponentMenu("PortaScripts/Timer")]
public class Porta_Timer : MonoBehaviour
{
    RoomController RoomControl;

    CameraTarget cameraTarget;

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
        cameraTarget = FindObjectOfType<CameraTarget>();
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
                if (timeToAdd >= 5f)
                {
                    timeToAdd = 0;
                    DoorBar++;
                    Ui_Open.fillAmount = DoorBar / DoorMax;

                    cameraTarget.targets[2] = Door.transform;

                    if (DoorBar >= DoorMax)
                    {
                        IsOpen = true;
                        Door.SetActive(false);
                        cameraTarget.targets[2] = cameraTarget.targets[1];
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
                    Ui_Open.fillAmount = DoorBar / DoorMax;

                    cameraTarget.targets[2] = cameraTarget.targets[1];

                    timeToCancel = 0;
                    UI_Door.SetActive(false);
                }
            }

        }

    }


}
