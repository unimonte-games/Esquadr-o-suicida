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

    private void Start()
    {
        P = GetComponent<Player>();
        PlayerController = P.PlayerType;

        if (PlayerController)
        {
            Up = KeyCode.W;
            Down = KeyCode.S;
            Right = KeyCode.D;
            Left = KeyCode.A;
        }
        else
        {
            Up = KeyCode.UpArrow;
            Down = KeyCode.DownArrow;
            Right = KeyCode.RightArrow;
            Left = KeyCode.LeftArrow;
        }
    }

    void Update()
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
