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
    KeyCode Esquiva;

    bool Esquiva_Forward;
    bool Esquiva_Right;
    bool Esquiva_Left;

    bool EsquivaInUsing;
    float time_Esquiva;

    bool Rotate_Right;
    float time_Right;

    bool Rotate_Left;
    float time_Left;

    void FixedUpdate()
    {
        if (!ToMove)
        {
            if (Input.GetKey(Up))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime );

                if (Input.GetKeyDown(Esquiva) && !EsquivaInUsing)
                {
                    EsquivaInUsing = true;
                    Esquiva_Forward = true;

                }

            } else if (Input.GetKey(Down))
            {
                transform.Translate(-Vector3.forward * downSpeed * Time.deltaTime);


                if (Input.GetKeyDown(Right) && !Rotate_Left)
                {
                    Rotate_Right = true;
                }

                if (Input.GetKeyDown(Left) && !Rotate_Right)
                {
                    Rotate_Left = true;
                }

            }

            if (Input.GetKey(Right))
            {
                transform.Rotate(Vector3.up, TurnSpeed * Time.deltaTime);

                if (Input.GetKeyDown(Esquiva) && !EsquivaInUsing)
                {
                    Esquiva_Right = true;
                    EsquivaInUsing = true;
                }


            }
            else if (Input.GetKey(Left))
            {
                transform.Rotate(Vector3.up, -TurnSpeed * Time.deltaTime);

                if (Input.GetKeyDown(Esquiva) && !EsquivaInUsing)
                {
                    Esquiva_Left = true;
                    EsquivaInUsing = true;
                }
            }

            if (Input.GetKeyDown(Esquiva) && !EsquivaInUsing)
            {
                int randomEsquiva = Random.Range(0, 2);
                if(randomEsquiva == 0)
                {
                    Esquiva_Forward = true;
                    EsquivaInUsing = true;
                }
                if (randomEsquiva == 1)
                {
                    Esquiva_Right = true;
                    EsquivaInUsing = true;
                }

                if (randomEsquiva == 2)
                {
                    Esquiva_Left = true;
                    EsquivaInUsing = true;
                }

            }

            if (Esquiva_Forward)
            {
                transform.Translate(Vector3.forward * 15 * Time.deltaTime);
                time_Esquiva += 0.1f;
                if (time_Esquiva >= 2f)
                {
                    Esquiva_Forward = false;
                    time_Esquiva = 0f;
                    EsquivaInUsing = false;
                }
            }

            if (Esquiva_Right)
            {
                transform.Translate(Vector3.right * 15 * Time.deltaTime);
                time_Esquiva += 0.1f;
                if (time_Esquiva >= 2f)
                {
                    Esquiva_Right = false;
                    time_Esquiva = 0f;
                    EsquivaInUsing = false;
                }
            }

            if (Esquiva_Left)
            {
                transform.Translate(Vector3.left * 15 * Time.deltaTime);
                time_Esquiva += 0.1f;
                if (time_Esquiva >= 2f)
                {
                    Esquiva_Left = false;
                    time_Esquiva = 0f;
                    EsquivaInUsing = false;
                }
            }

            if (Rotate_Right)
            {
                transform.Rotate(Vector3.up, 500 * Time.deltaTime);
                time_Right += 0.1f;
                if(time_Right >= 1.5f)
                {
                    Rotate_Right = false;
                    time_Right = 0f;
                }
            }

            if (Rotate_Left)
            {
                transform.Rotate(Vector3.up, -500 * Time.deltaTime);
                time_Left += 0.1f;
                if (time_Left >= 1.5f)
                {
                    Rotate_Left = false;
                    time_Left = 0f;
                }
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

        Esquiva = P.Esquiva;

    }

}