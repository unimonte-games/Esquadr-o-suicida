using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrinhoMetralhadora : MonoBehaviour
{
    public GameObject Player_Assault; //Assault
    public GameObject Player_Moviment; //Moviment

    GameObject P1_ref;
    GameObject P2_ref;
    KeyCode P1;
    KeyCode P2;
    bool P1InArea;
    bool P2InArea;
    bool P1ready;
    bool P2ready;

    public bool Assault;
    public bool Moviment;
    public Transform AssaultPosition;
    public Transform MovimentPosition;
    public Transform DropAssault;
    public Transform DropMoviment;
    public BoxCollider BC;
    public Rigidbody CarrinhoBody;

    private void FixedUpdate()
    {
        if (P1InArea && !P1ready)
        {
            if (Input.GetKeyDown(P1))
            {
                if (!Assault)
                {
                    Assault = true;
                    Player_Assault = P1_ref;
                    Player_Assault.transform.position = AssaultPosition.position;
                    Player_Assault.GetComponent<FpsWalk>().enabled = false;
                    P1ready = true;
                    Debug.Log("Player 1 é o Assault!");
                    return;

                }

                if (!Moviment)
                {
                    Moviment = true;
                    Player_Moviment = P1_ref;
                    Player_Moviment.transform.position = MovimentPosition.position;
                    Player_Moviment.GetComponent<FpsWalk>().enabled = false;
                    P1ready = true;
                    Debug.Log("Player 1 é o Controller!");
                    return;

                }

            }

        }


        if (P2InArea && !P2ready)
        {
            if (Input.GetKeyDown(P2))
            {
                if (!Assault && !Moviment)
                {
                    Assault = true;
                    Player_Assault = P2_ref;
                    Player_Assault.transform.position = AssaultPosition.position;
                    Player_Assault.GetComponent<FpsWalk>().enabled = false;
                    P2ready = true;
                    Debug.Log("Player 2 é o Assault!");
                    return;

                }

                if (Assault && !Moviment)
                {
                    Moviment = true;
                    Player_Moviment = P2_ref;
                    Player_Moviment.transform.position = MovimentPosition.position;
                    Player_Moviment.GetComponent<FpsWalk>().enabled = false;
                    P2ready = true;
                    Debug.Log("Player 2 é o Controller!");
                    return;

                }

            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1")
        {
            P1_ref = other.gameObject;
            P1 = other.gameObject.GetComponent<Player>().Accept;
            P1InArea = true;
        }

        if (other.gameObject.name == "Player2")
        {
            P2_ref = other.gameObject;
            P2 = other.gameObject.GetComponent<Player>().Accept;
            P2InArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1")
        {
            P1InArea = false;
            P1ready = false;
            if(Player_Assault == other.gameObject)
            {
                Player_Assault = null;
                Assault = false;
                Player_Assault.GetComponent<FpsWalk>().enabled = true;
                return;
            }

            if(Player_Moviment == other.gameObject)
            {
                Player_Moviment = null;
                Moviment = false;
                Player_Moviment.GetComponent<FpsWalk>().enabled = true;
                return;
            }

        }

        if (other.gameObject.name == "Player2")
        {
            P2InArea = false;
            P2ready = false;
            if (Player_Assault == other.gameObject)
            {
                Player_Assault = null;
                Assault = false;
                Player_Assault.GetComponent<FpsWalk>().enabled = true;
                return;
            }

            if (Player_Moviment == other.gameObject)
            {
                Player_Moviment = null;
                Moviment = false;
                Player_Moviment.GetComponent<FpsWalk>().enabled = true;
                return;
            }
        }
    }
}
