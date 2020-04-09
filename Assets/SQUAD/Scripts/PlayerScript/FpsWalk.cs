using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FpsWalk : MonoBehaviour
{

    public float speed = 20f;
    Player P;

    bool PlayerController;

    KeyCode Up;
    KeyCode Down;
    KeyCode Right;
    KeyCode Left;

    public bool ToMove;

    public void UpdateMoviment()
    {
        P = GetComponent<Player>();
        PlayerController = P.PlayerType;

        Up = P.Up;
        Down = P.Down;
        Right = P.Right;
        Left = P.Left;
    }

    void FixedUpdate()
    {
        if (!ToMove)
        {
            Vector3 pos = transform.position;

            if (Input.GetKey(Up))
            {
                pos.z += speed * Time.deltaTime;
            }
            if (Input.GetKey(Down))
            {
                pos.z -= speed * Time.deltaTime;
            }
            if (Input.GetKey(Right))
            {
                pos.x += speed * Time.deltaTime;
            }
            if (Input.GetKey(Left))
            {
                pos.x -= speed * Time.deltaTime;
            }

            transform.position = pos;
        }
        
    }
  
}