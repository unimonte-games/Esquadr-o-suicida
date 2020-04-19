using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


[AddComponentMenu("PortaScripts/Color")]
public class Porta_Color : MonoBehaviour
{

    public RoomController RoomControl;

    CameraTarget cameraTarget;

    public GameObject Door;
    
    public GameObject UI_Door;
    public Image Ui_Open;
    float DoorBar = 0f;
    public float DoorMax = 10f;

    public bool P1_ColorA, P2_ColorB, LastChance, IsOpen;
    float timeToAdd, timeToCancel;

    
    void Start()
    {
   
        cameraTarget = FindObjectOfType<CameraTarget>();

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
                        RoomControl.CompleteRoom(1);


                        Debug.Log("Portao Liberado!");

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
