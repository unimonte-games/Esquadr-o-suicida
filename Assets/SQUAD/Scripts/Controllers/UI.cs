using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject Map;

    public KeyCode P1;
    public KeyCode P2;

    bool MapAtived;

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(P1) || Input.GetKeyDown(P2) && !MapAtived)
        {
            MapAtived = true;
            Map.SetActive(true);
            Invoke("CancelAuto", 3);

        }
    }

    void CancelAuto()
    {
        if (MapAtived)
        {
            Map.SetActive(false);
            MapAtived = false;
            CancelInvoke("CancelAuto");
            
        }
    }

}
