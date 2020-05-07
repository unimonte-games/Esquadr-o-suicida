using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStun : MonoBehaviour
{

    public PlayerMovement PM;
    public GameObject Effect;
    public int TimeToStun;

    private void OnEnable()
    {
        PM.Stun = true;

        Effect.SetActive(true);
        PM.enabled = false;
        Debug.Log("Player foi Stunado!");
        Invoke("Cancel", TimeToStun);
    }

    void Cancel()
    {
        PM.Stun = false;
        Effect.SetActive(false);
        PM.enabled = true;
        this.enabled = false;
    }
}
