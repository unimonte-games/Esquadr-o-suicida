using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrinhoController : MonoBehaviour
{
    public KeyCode Moviment_Up;
    public KeyCode Moviment_Down;
    public KeyCode Moviment_Right;
    public KeyCode Moviment_Left;

    public float speed = 6f;
    public float TurnSpeed = 90f;
    public float downSpeed = 3f;
    public CarrinhoMetralhadora CM;

    private void FixedUpdate()
    {
        if (CM.P1ready && CM.P2ready)
        {

            if (Input.GetKey(Moviment_Up))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);

            }
            else if (Input.GetKey(Moviment_Down))
            {
                transform.Translate(-Vector3.forward * downSpeed * Time.deltaTime);
            }

            if (Input.GetKey(Moviment_Right))
            {
                transform.Rotate(Vector3.up, TurnSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(Moviment_Left))
            {
                transform.Rotate(Vector3.up, -TurnSpeed * Time.deltaTime);
            }
        }
    }
}
