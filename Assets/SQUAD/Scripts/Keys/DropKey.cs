using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropKey : MonoBehaviour
{
    public int ID;
    public BoxCollider BC;

    public void BoxDisabled()
    {
        BC.enabled = false;
        Invoke("BoxEnabled", 2f);
    }

    public void BoxEnabled()
    {
        BC.enabled = true;
    }

}
