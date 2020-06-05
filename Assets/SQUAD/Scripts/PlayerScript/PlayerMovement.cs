using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public bool Stun;
    public bool Slow;

    public float speed = 5f;
    public float speedRotate = 6f;
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
    KeyCode Turn;

    bool Esquiva_Forward;

    bool EsquivaInUsing;
    float time_Esquiva;

    bool Rotete_Turn;
    float TimeTurn;

    bool isTurn;

    float timeToClik = 5;
    public Animator Anin;

    private void Start()
    {
        Anin.SetInteger("WeaponState", 1);
        Anin.SetBool("isIddle", true);
        
    }

    void FixedUpdate()
    {
        if (!ToMove)
        {

            if (Input.GetKey(Up) && !EsquivaInUsing) //Walk
            {
                Anin.SetBool("isWalk", true);

                Anin.SetBool("isIddle", false);
                Anin.SetBool("isWalkBack", false);
                Anin.SetBool("isTurn", false);
                isTurn = false;

                transform.Translate(Vector3.forward * speed * Time.deltaTime);

            }

            if (Input.GetKey(Down) && !EsquivaInUsing)//Walk Back
            {
                Anin.SetBool("isWalkBack", true);

                Anin.SetBool("isIddle", false);
                Anin.SetBool("isWalk", false);
                Anin.SetBool("isTurn", false);
                isTurn = false;

                transform.Translate(-Vector3.forward * downSpeed * Time.deltaTime);

            }


            if (Input.GetKeyUp(Up) || Input.GetKeyUp(Down)) //Iddle
            {
                Anin.SetBool("isIddle", true);

                Anin.SetBool("isWalkBack", false);
                Anin.SetBool("isWalk", false);
                Anin.SetBool("isTurn", false);
                isTurn = true;
            }

            if (Input.GetKeyUp(Left) && isTurn || Input.GetKeyUp(Right) && isTurn) //Iddle dps de girar parado
            {
                Anin.SetBool("isIddle", true);

                Anin.SetBool("isWalkBack", false);
                Anin.SetBool("isWalk", false);
                Anin.SetBool("isTurn", false);
                isTurn = true;
            }

            if (isTurn)
            {
                if (Input.GetKey(Right))
                {

                    Anin.SetBool("isTurn", true);

                    Anin.SetBool("isIddle", false);
                    Anin.SetBool("isWalkBack", false);
                    Anin.SetBool("isWalk", false);


                    transform.Rotate(Vector3.up, TurnSpeed * Time.deltaTime);
                    
                }
                else if (Input.GetKey(Left))
                {

                    Anin.SetBool("isTurn", true);

                    Anin.SetBool("isIddle", false);
                    Anin.SetBool("isWalkBack", false);
                    Anin.SetBool("isWalk", false);


                    transform.Rotate(Vector3.up, -TurnSpeed * Time.deltaTime);

                }
            }
            else
            {
                if (Input.GetKey(Right))
                {
                    transform.Rotate(Vector3.up, TurnSpeed * Time.deltaTime);

                }
                else if (Input.GetKey(Left))
                {
                    transform.Rotate(Vector3.up, -TurnSpeed * Time.deltaTime);

                }
            }

            if (Input.GetKeyDown(Turn) && !EsquivaInUsing)
            {
                Rotete_Turn = true;
            }

            if (EsquivaInUsing)
            {
                timeToClik += Time.deltaTime;
            }

            if (Input.GetKeyDown(Esquiva) && !EsquivaInUsing && timeToClik > 3) 
            {
                EsquivaInUsing = true;
                Anin.SetTrigger("isEsquiva");

                timeToClik = 0;
                Esquiva_Forward = true;

            }

            if (Esquiva_Forward)
            {
                transform.Translate(Vector3.forward * 10 * Time.deltaTime);
                time_Esquiva += Time.deltaTime;
                if (time_Esquiva >= 1.2f)
                {
                    Esquiva_Forward = false;
                    time_Esquiva = 0f;
                    EsquivaInUsing = false;

                    timeToClik = 5;
                }
            }

            if (Rotete_Turn)
            {
                transform.Rotate(Vector3.up, 600 * Time.deltaTime);
                TimeTurn += 0.1f;
                if(TimeTurn >= 1.5f)
                {
                    Rotete_Turn = false;
                    TimeTurn = 0f;
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
        Turn = P.Turn;

    }
   
}