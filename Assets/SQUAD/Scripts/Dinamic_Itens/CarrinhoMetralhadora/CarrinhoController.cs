using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrinhoController : MonoBehaviour
{
    public KeyCode Moviment_Up;
    public KeyCode Moviment_Down;
    public KeyCode Moviment_Right;
    public KeyCode Moviment_Left;

    public float speed = 10f;
    public CarrinhoMetralhadora CM;

    private void FixedUpdate()
    {
        if (CM.P1ready && CM.P2ready)
        {
            Vector3 pos = transform.position;

            if (Input.GetKey(Moviment_Up))
            {
                pos.z += speed * Time.deltaTime;
            }
            if (Input.GetKey(Moviment_Down))
            {
                pos.z -= speed * Time.deltaTime;
            }
            if (Input.GetKey(Moviment_Right))
            {
                pos.x += speed * Time.deltaTime;
            }
            if (Input.GetKey(Moviment_Left))
            {
                pos.x -= speed * Time.deltaTime;
            }

            transform.position = pos;
        }
    }
}
