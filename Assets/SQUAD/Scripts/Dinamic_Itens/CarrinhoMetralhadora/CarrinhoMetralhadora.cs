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
    KeyCode P1_Drop;
    KeyCode P2_Drop;
    bool P1InArea;
    bool P2InArea;
    public bool P1ready;
    public bool P2ready;
    bool Atived;

    public bool Assault;
    public bool Moviment;
    public Transform AssaultPosition;
    public Transform MovimentPosition;
    public Transform DropAssault;
    public Transform DropMoviment;

    GameObject P1_OriginalParent;
    GameObject P2_OriginalParent;

    public CarrinhoController CC;
    public CarrinhoAssault CA;

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
               
                if (!Assault && !P1ready)
                {
                    Assault = true;
                    Player_Assault = P1_ref;
                    Player_Assault.transform.position = AssaultPosition.position;
                    Player_Assault.transform.parent = AssaultPosition;
                    Player_Assault.GetComponent<PlayerMovement>().enabled = false;

                    P1ready = true;

                    Player temp = Player_Assault.GetComponent<Player>();
                    UpdateControllers1_Assault(temp);

                    Debug.Log("Player 1 é o Assault!");
                    return;

                }

                if (!Moviment && !P1ready)
                {
                    Moviment = true;
                    Player_Moviment = P1_ref;
                    Player_Moviment.transform.position = MovimentPosition.position;
                    Player_Moviment.transform.parent = MovimentPosition;
                    Player_Moviment.GetComponent<PlayerMovement>().enabled = false;

                    P1ready = true;
                    
                    Player temp = Player_Moviment.GetComponent<Player>();
                    UpdateControllers1_Moviment(temp);
                    
                    Debug.Log("Player 1 é o Controller!");
                    return;

                }

            }

        }

        if (P2InArea && !P2ready)
        {
            if (Input.GetKeyDown(P2))
            {
                if (!Assault && !P2ready)
                {
                    Assault = true;
                    Player_Assault = P2_ref;
                    Player_Assault.transform.position = AssaultPosition.position;
                    Player_Assault.transform.parent = AssaultPosition;
                    Player_Assault.GetComponent<PlayerMovement>().enabled = false;
                    
                    P2ready = true;

                    Player temp = Player_Assault.GetComponent<Player>();
                    UpdateControllers2_Assault(temp);

                    Debug.Log("Player 2 é o Assault!");
                    return;

                }

                if (!Moviment && !P2ready)
                {
                    Moviment = true;
                    Player_Moviment = P2_ref;
                    Player_Moviment.transform.position = MovimentPosition.position;
                    Player_Moviment.transform.parent = MovimentPosition;
                    Player_Moviment.GetComponent<PlayerMovement>().enabled = false;

                    P2ready = true;
                    

                    Player temp = Player_Moviment.GetComponent<Player>();
                    UpdateControllers2_Moviment(temp);

                    Debug.Log("Player 2 é o Controller!");
                    return;

                }

            }

        }

        if(P1InArea && P1ready)
        {
            if (Input.GetKeyDown(P1_Drop))
            {
                if(P1_ref == Player_Assault)
                {
                    Player_Assault.transform.position = DropAssault.position;
                    
                    Player_Assault.GetComponent<PlayerMovement>().enabled = true;
                    Player_Assault.transform.parent = P1_OriginalParent.transform;

                    Player_Assault = null;
                    P1ready = false;
                    Assault = false;
                    return;
                }

                if (P1_ref == Player_Moviment)
                {
                    Player_Moviment.transform.position = DropMoviment.position;

                    Player_Moviment.GetComponent<PlayerMovement>().enabled = true;
                    Player_Moviment.transform.parent = P1_OriginalParent.transform;

                    Player_Moviment = null;
                    P1ready = false;
                    Moviment = false;
                    return;
                }

            }
        }
        if (P2InArea && P2ready)
        {
            if (Input.GetKeyDown(P2_Drop))
            {
                if (P2_ref == Player_Assault)
                {
                    Player_Assault.transform.position = DropAssault.position;

                    Player_Assault.GetComponent<PlayerMovement>().enabled = true;
                    Player_Assault.transform.parent = P2_OriginalParent.transform;

                    Player_Assault = null;
                    P2ready = false;
                    Assault = false;
                    return;
                }

                if (P2_ref == Player_Moviment)
                {
                    Player_Moviment.transform.position = DropMoviment.position;

                    Player_Moviment.GetComponent<PlayerMovement>().enabled = true;
                    Player_Moviment.transform.parent = P2_OriginalParent.transform;

                    Player_Moviment = null;
                    P2ready = false;
                    Moviment = false;
                    return;
                }

            }
        }

        if(P1ready && P2ready && !Atived)
        {
            P1_ref.GetComponent<Player>().UsingItenDinamic = true;
            P2_ref.GetComponent<Player>().UsingItenDinamic = true;
            Atived = true;

        }

        if(!Assault && !Moviment)
        {
            Atived = false;
        }

    }

    void UpdateControllers1_Assault(Player P)
    {
        CA.Assault_Gatilho = P.Accept;
        CA.Assault_Up = P.Up;
        CA.Assault_Down = P.Down;
        CA.Assault_Left = P.Left;
        CA.Assault_Right = P.Right;
            
        //Controles
    }

    void UpdateControllers1_Moviment(Player P)
    {
        CC.Moviment_Up = P.Up;
        CC.Moviment_Down = P.Down;
        CC.Moviment_Right = P.Right;
        CC.Moviment_Left = P.Left;
    }

    void UpdateControllers2_Assault(Player P)
    {
        CA.Assault_Gatilho = P.Accept;
        CA.Assault_Up = P.Up;
        CA.Assault_Down = P.Down;
        CA.Assault_Left = P.Left;
        CA.Assault_Right = P.Right;
    }

    void UpdateControllers2_Moviment(Player P)
    {
        CC.Moviment_Up = P.Up;
        CC.Moviment_Down = P.Down;
        CC.Moviment_Right = P.Right;
        CC.Moviment_Left = P.Left;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1")
        {
            P1_ref = other.gameObject;
            Player temp = other.gameObject.GetComponent<Player>();

            if (!temp.UsingItenDinamic)
            {
                P1 = temp.Accept;
                P1_Drop = temp.Dropar_set;
                P1InArea = true;
            }
        }

        if (other.gameObject.name == "Player2")
        {
            P2_ref = other.gameObject;
            Player temp = other.gameObject.GetComponent<Player>();

            if (!temp.UsingItenDinamic)
            {
                P2 = temp.Accept;
                P2_Drop = temp.Dropar_set;
                P2InArea = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1")
        {
            P1InArea = false;
            P1ready = false;
           

            if (Player_Assault == other.gameObject)
            {
                Player_Assault.GetComponent<PlayerMovement>().enabled = true;
                Player_Assault.transform.parent = P1_OriginalParent.transform;
                Player_Assault.GetComponent<Player>().UsingItenDinamic = false;
                
                Player_Assault = null;
                Assault = false;
                return;
            }

            if(Player_Moviment == other.gameObject)
            {
                Player_Moviment.GetComponent<PlayerMovement>().enabled = true;
                Player_Moviment.transform.parent = P1_OriginalParent.transform;
                Player_Moviment.GetComponent<Player>().UsingItenDinamic = false;

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
                Player_Assault.GetComponent<PlayerMovement>().enabled = true;
                Player_Assault.transform.parent = P2_OriginalParent.transform;
                Player_Assault.GetComponent<Player>().UsingItenDinamic = false;

                Player_Assault = null;
                Assault = false;
                return;
            }

            if (Player_Moviment == other.gameObject)
            {
                Player_Moviment.GetComponent<PlayerMovement>().enabled = true;
                Player_Moviment.transform.parent = P2_OriginalParent.transform;
                Player_Moviment.GetComponent<Player>().UsingItenDinamic = false;

                Player_Moviment = null;
                Moviment = false;
                return;
            }
        }
    }

   
}
