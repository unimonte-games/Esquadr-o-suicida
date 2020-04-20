using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    public float downSpeed = 3f;
    public float TurnSpeed = 50f;
    Vector3 velocity;

    Player P;

    bool PlayerController;
    public bool ToMove;

    KeyCode Up;
    KeyCode Down;
    KeyCode Right;
    KeyCode Left;

    void FixedUpdate()
    {
        if (!ToMove)
        {
            
            if (Input.GetKey(Up))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime );

            } else if (Input.GetKey(Down))
            {
                transform.Translate(-Vector3.forward * downSpeed * Time.deltaTime);
            }
            
            if (Input.GetKey(Right))
            {
                transform.Rotate(Vector3.up, TurnSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(Left))
            {
                transform.Rotate(Vector3.up, -TurnSpeed * Time.deltaTime);
            }

            

        }
        
    }

    public void UpdateMoviment()
    {
        P = GetComponent<Player>();

        Up = P.Up;
        Down = P.Down;
        Right = P.Right;
        Left = P.Left;

    }

}