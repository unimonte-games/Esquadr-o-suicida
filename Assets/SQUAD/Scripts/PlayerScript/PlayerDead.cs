using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    public bool P1_dead;
    public bool P2_dead;

    public SphereCollider SC;

    private void Start()
    {
        Invoke("CancelRef", 15);
    }

    void CancelRef()
    {
        SC.enabled = false;
    }



}
