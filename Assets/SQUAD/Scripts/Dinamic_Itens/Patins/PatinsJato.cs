using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatinsJato : MonoBehaviour
{

    bool P1_inArea;
    bool P2_inArea;

    bool P1_ready;
    bool P2_ready;

    KeyCode P1;
    KeyCode P2;

    PlayerMovement P1_ref;
    PlayerMovement P2_ref;

    public int timeToCancel;

    private void FixedUpdate()
    {
        if (P1_inArea && Input.GetKeyDown(P1) && !P1_ready)
        {
            P1_ready = true;
            P1_ref.speed = 10;
            

            Debug.Log("Patins Ativado no Player 1");
            Invoke("CancelP1", timeToCancel);
            
        }

        if (P2_inArea && Input.GetKeyDown(P2) && !P2_ready)
        {
            P2_ready = true;
            P2_ref.speed = 10;
            

            Debug.Log("Patins Ativado no Player 2");
            Invoke("CancelP2", timeToCancel);
        }

    }

    void CancelP1()
    {
        Debug.Log("Patins Player 1, cancelado");
        P1_ref.speed = 6;
       
    }

    void CancelP2()
    {
        Debug.Log("Patins Player 2, cancelado");
        P2_ref.speed = 6;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player1" && !P1_inArea)
        {
            if (!other.GetComponent<Player>().UsingItenDinamic)
            {
                P1_inArea = true;
                P1_ref = other.GetComponent<PlayerMovement>();
                P1 = other.GetComponent<Player>().Accept;
                
            }
        }

        if (other.gameObject.name == "Player2" && !P2_inArea)
        {
            if (!other.GetComponent<Player>().UsingItenDinamic)
            {
                P2_inArea = true;
                P2_ref = other.GetComponent<PlayerMovement>();
                P2 = other.GetComponent<Player>().Accept;
                
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1")
        {
            P1_inArea = false;
        }

        if (other.gameObject.name == "Player2")
        {
            P2_inArea = false;
        }
    }

}
