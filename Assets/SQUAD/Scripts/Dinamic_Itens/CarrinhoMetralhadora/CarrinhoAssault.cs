using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrinhoAssault : MonoBehaviour
{
    public KeyCode Assault_Gatilho;
    public KeyCode Assault_Up;
    public KeyCode Assault_Down;
    public KeyCode Assault_Left;
    public KeyCode Assault_Right;

    public CarrinhoMetralhadora CM;

    private void FixedUpdate()
    {
        if (CM.P1ready && CM.P2ready)
        {
            if (Input.GetKeyDown(Assault_Gatilho))
            {
                Debug.Log("Atirando.");
            }
            
        }
    }
}
