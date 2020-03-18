using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsWalk : MonoBehaviour
{

    public float speed = 20f;
    Player P;

    bool PlayerController;

    private void Start()
    {
        P = GetComponent<Player>();
        PlayerController = P.PlayerType;
    }
   
    void Update()
    {

        if (PlayerController) //Player1
        {

            Vector3 pos = transform.position;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                pos.z += speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                pos.z -= speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                pos.x += speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                pos.x -= speed * Time.deltaTime;
            }

            transform.position = pos;

        }
        else //Player2
        {
            Vector3 pos = transform.position;

            if (Input.GetKey("w"))
            {
                pos.z += speed * Time.deltaTime;
            }
            if (Input.GetKey("s"))
            {
                pos.z -= speed * Time.deltaTime;
            }
            if (Input.GetKey("d"))
            {
                pos.x += speed * Time.deltaTime;
            }
            if (Input.GetKey("a"))
            {
                pos.x -= speed * Time.deltaTime;
            }


            transform.position = pos;
        }
        
    }
}
