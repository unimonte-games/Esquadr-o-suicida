using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonMove : MonoBehaviour
{

    public BaloonRandomMove P1;
    public BaloonRandomMove P2;

    FpsWalk P1_walk;
    FpsWalk P2_walk;

    GameObject P1_ref;
    GameObject P2_ref;

    public Transform P1_Baloon;
    public Transform P2_Baloon;

    GameObject P1_OriginalParent;
    GameObject P2_OriginalParent;

    bool P1_inArea;
    bool P2_inArea;

    bool P1_ready;
    bool P2_ready;

    bool Go;
    bool P1_using;
    bool P2_using;

    KeyCode P1_Accept;
    KeyCode P2_Accept;

    KeyCode P1_Drop;
    KeyCode P2_Drop;


    private void Start()
    {
        P1_OriginalParent = GameObject.Find("Player1_Original");
        P2_OriginalParent = GameObject.Find("Player2_Original");

    }

    private void FixedUpdate()
    {
        if (P1_inArea && Input.GetKeyDown(P1_Accept) && !P1_ready && !Go && !P1_using)
        {
            P1_ready = true;

            P1_walk.enabled = false;
            P1_ref.GetComponent<Rigidbody>().useGravity = false;
            P1_ref.GetComponent<CapsuleCollider>().enabled = false;

            P1_ref.transform.position = P1_Baloon.transform.position;
            P1_ref.transform.parent = P1_Baloon;
            


            Debug.Log("Baloon Ativado no Player 1");
        }

        if (P2_inArea && Input.GetKeyDown(P2_Accept) && !P2_ready && !Go && !P2_using)
        {
            P2_ready = true;

            P2_walk.enabled = false;
            P2_ref.GetComponent<Rigidbody>().useGravity = false;
            P2_ref.GetComponent<CapsuleCollider>().enabled = false;

            P2_ref.transform.position = P2_Baloon.transform.position;
            P2_ref.transform.parent = P2_Baloon;

            Debug.Log("Baloon Ativado no Player 2");
        }

        if(P1_ready && Input.GetKeyDown(P1_Drop))
        {
            P1_ready = false;

            P1_walk.enabled = true;
            P1_ref.GetComponent<Rigidbody>().useGravity = true;
            P1_ref.GetComponent<CapsuleCollider>().enabled = true;

            P1_ref.transform.parent = P1_OriginalParent.transform;
            
        }

        if (P2_ready && Input.GetKeyDown(P2_Drop))
        {
            P2_ready = false;

            P2_walk.enabled = true;
            P2_ref.GetComponent<Rigidbody>().useGravity = true;
            P2_ref.GetComponent<CapsuleCollider>().enabled = true;

            P2_ref.transform.parent = P2_OriginalParent.transform;
        }

        if (P1_ready && P2_ready && !Go)
        {
            Go = true;
            P1_using = true;
            P2_using = true;

            P1.StartBaloon();
            P2.StartBaloon();

            Invoke("StartBaloon", 2);
        }
    }

    void StartBaloon()
    {
        P1.Using = true;
        P2.Using = true;

        Debug.Log("Baloon Iniciado!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1" && !P1_inArea)
        {
            if (!other.GetComponent<Player>().UsingItenDinamic)
            {
                P1_inArea = true;
                P1_ref = other.gameObject;
                P1_Accept = other.GetComponent<Player>().Accept;
                P1_Drop = other.GetComponent<Player>().Dropar_set;
                P1_walk = other.GetComponent<FpsWalk>();
                
            }
        }

        if (other.gameObject.name == "Player2" && !P2_inArea)
        {
            if (!other.GetComponent<Player>().UsingItenDinamic)
            {
                P2_inArea = true;
                P2_ref = other.gameObject;
                P2_Accept = other.GetComponent<Player>().Accept;
                P2_Drop = other.GetComponent<Player>().Dropar_set;
                P2_walk = other.GetComponent<FpsWalk>();
            }
        }

    }

}
