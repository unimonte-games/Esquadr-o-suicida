using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemArea : MonoBehaviour
{
   
    public Animation AreaShot;

    private void OnEnable()
    {
        AreaShot.Play("AreaGolem");
    }

    
}
