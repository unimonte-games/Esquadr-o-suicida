using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemArea : MonoBehaviour
{
   
    
    public AudioSource AtkSound;

    private void OnEnable()
    {
        
        AtkSound.Play();
    }

    
}
