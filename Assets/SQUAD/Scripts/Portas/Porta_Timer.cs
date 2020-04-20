using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[AddComponentMenu("PortaScripts/Timer")]
public class Porta_Timer : MonoBehaviour
{
    public RoomController RoomControl;

    CameraTarget cameraTarget;

    public GameObject PlayerInArea;
    public GameObject Door;
    public GameObject UI_Door;
    public Image Ui_Open;
    public float DoorBar = 0f;
    public float DoorMax = 10f;


    public bool Player, LastChance, IsOpen;
    float timeToAdd, timeToCancel;

    LevelController LC;

    void Start()
    {
        LC = FindObjectOfType<LevelController>();

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
                        RoomControl.CompleteRoom(3);

                        PlayerInArea.GetComponent<Player>().playerWeapon.enabled = true;

                        Debug.Log("Portao Liberado!");

                    }

                }

            }

            if (LastChance)
            {
                timeToCancel += 0.1f;
                if (timeToCancel >= 1f)
                {
                    if (!LC.SoloPlayer)
                    {
                        DoorBar = 0;
                    }
                    
                    Ui_Open.fillAmount = DoorBar / DoorMax;

                    cameraTarget.targets[2] = cameraTarget.targets[1];

                    timeToCancel = 0;
                    UI_Door.SetActive(false);
                }
            }

        }

    }


}
