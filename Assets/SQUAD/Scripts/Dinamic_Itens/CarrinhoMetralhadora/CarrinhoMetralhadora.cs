using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrinhoMetralhadora : MonoBehaviour
{
    public float speed = 10f;

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

    KeyCode Moviment_Up;
    KeyCode Moviment_Down;
    KeyCode Moviment_Right;
    KeyCode Moviment_Left;

    public bool Assault;
    public bool Moviment;
    public Transform AssaultPosition;
    public Transform MovimentPosition;
    public Transform DropAssault;
    public Transform DropMoviment;
    public GameObject CarrinhoBody;

    public GameObject P1_OriginalParent;
    public GameObject P2_OriginalParent;

    private void Start()
    {
        P1_OriginalParent = GameObject.Find("Player1_Original");
        P2_OriginalParent = GameObject.Find("Player2_Original");

    }

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
                    Player_Assault.transform.parent = AssaultPosition;
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
                    Player_Moviment.transform.parent = MovimentPosition;
                    Player_Moviment.GetComponent<FpsWalk>().enabled = false;

                    P1ready = true;

                    Player temp = Player_Moviment.GetComponent<Player>();

                    Moviment_Up = temp.Up;
                    Moviment_Down = temp.Down;
                    Moviment_Right = temp.Right;
                    Moviment_Left = temp.Left;

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
                    Player_Assault.transform.parent = AssaultPosition;
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
                    Player_Moviment.transform.parent = MovimentPosition;
                    Player_Moviment.GetComponent<FpsWalk>().enabled = false;

                    P2ready = true;

                    Player temp = Player_Moviment.GetComponent<Player>();

                    Moviment_Up = temp.Up;
                    Moviment_Down = temp.Down;
                    Moviment_Right = temp.Right;
                    Moviment_Left = temp.Left;

                    Debug.Log("Player 2 é o Controller!");
                    return;

                }

            }

        }

        if(P1ready && P2ready)
        {
            Vector3 pos = CarrinhoBody.transform.position;

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

            CarrinhoBody.transform.position = pos;
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
                Player_Assault.GetComponent<FpsWalk>().enabled = true;
                Player_Assault.transform.parent = P1_OriginalParent.transform;

                Player_Assault = null;
                Assault = false;
                return;
            }

            if(Player_Moviment == other.gameObject)
            {
                Player_Moviment.GetComponent<FpsWalk>().enabled = true;
                Player_Moviment.transform.parent = P1_OriginalParent.transform;

                Player_Moviment = null;
                Moviment = false;
                return;
            }

        }

        if (other.gameObject.name == "Player2")
        {
            P2InArea = false;
            P2ready = false;
            if (Player_Assault == other.gameObject)
            {
                Player_Assault.GetComponent<FpsWalk>().enabled = true;
                Player_Assault.transform.parent = P2_OriginalParent.transform;

                Player_Assault = null;
                Assault = false;
                return;
            }

            if (Player_Moviment == other.gameObject)
            {
                Player_Moviment.GetComponent<FpsWalk>().enabled = true;
                Player_Moviment.transform.parent = P2_OriginalParent.transform;

                Player_Moviment = null;
                Moviment = false;
                return;
            }
        }
    }
}
