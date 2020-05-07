using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStun : MonoBehaviour
{

    public PlayerMovement PM;
    public GameObject Effect;
    
    private void OnEnable()
    {
        PM.Stun = true;

        Effect.SetActive(true);
        PM.enabled = false;
        Debug.Log("Player foi Stunado!");
        Invoke("Cancel", 3f);
    }

    void Cancel()
    {
        PM.Stun = false;
        Effect.SetActive(false);
        PM.enabled = true;
        this.enabled = false;
    }
}
