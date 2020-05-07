using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlow : MonoBehaviour
{

    public PlayerMovement PM;
    float tempSpeed;
    float tempDownSpeed;

    private void OnEnable()
    {
        tempSpeed = PM.speed;
        tempDownSpeed = PM.downSpeed;
        PM.Slow = true;

        PM.speed = 1f;
        PM.downSpeed = 1f;
        Debug.Log("Player Slow!");
        Invoke("Cancel", 10f);
    }

    void Cancel()
    {
        PM.Slow = false;

        PM.downSpeed = tempDownSpeed;
        PM.speed = tempSpeed;
        this.enabled = false;
    }
}
