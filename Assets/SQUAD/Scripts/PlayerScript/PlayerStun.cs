﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStun : MonoBehaviour
{

    public PlayerMovement PM;
    
    private void OnEnable()
    {
        PM.enabled = false;
        Debug.Log("Player foi Stunado!");
        Invoke("Cancel", 3f);
    }

    void Cancel()
    {
        Debug.Log("Efeito Acabou.");
        PM.enabled = true;
        this.enabled = false;
    }
}
