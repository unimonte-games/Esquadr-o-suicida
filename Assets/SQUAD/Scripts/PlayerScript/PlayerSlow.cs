using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlow : MonoBehaviour
{

    public PlayerMovement PM;
    public GameObject Effect;
    public int TimeToSlow;
    float tempSpeed;
    float tempDownSpeed;

    private void OnEnable()
    {
        tempSpeed = PM.speed;
        tempDownSpeed = PM.downSpeed;
        PM.Slow = true;
        Effect.SetActive(true);

        PM.speed = 1f;
        PM.downSpeed = 1f;
        Debug.Log("Player Slow!");
        Invoke("Cancel", TimeToSlow);
    }

    void Cancel()
    {
        PM.Slow = false;

        Effect.SetActive(false);
        PM.downSpeed = tempDownSpeed;
        PM.speed = tempSpeed;
        this.enabled = false;
    }
}
