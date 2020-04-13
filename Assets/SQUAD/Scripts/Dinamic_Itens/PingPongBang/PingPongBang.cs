using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongBang : MonoBehaviour
{
    KeyCode P1;
    KeyCode P2;

    bool P1_inArea;
    bool P2_inArea;

    bool P1_ready;
    bool P2_ready;

   

    public bool StartPong;
    public GameObject Ball;
    public Ball BallScript;

    public BoxCollider BC;

    void FixedUpdate()
    {

        if (P1_inArea && !StartPong)
        {
            if (Input.GetKeyDown(P1))
            {
                P1_ready = true;
                Debug.Log("Player 1 Pronto!");
                
            }
        }

        if (P2_inArea && !StartPong)
        {
            if (Input.GetKeyDown(P2))
            {
                P2_ready = true;
                Debug.Log("Player 2 Pronto!");
            }
        }

        if (P1_ready && P2_ready && !StartPong)
        {
            StartPong = true;

            BallScript.Atual = BallScript.P1_ref;
            Ball.SetActive(true);
            
            BC.enabled = false;

            Debug.Log("Ping Pong Bang!");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1" && !P1_inArea && !StartPong) //para pegar
        {
            if (!other.GetComponent<Player>().UsingItenDinamic)
            {
                BallScript.P1_ref = other.GetComponent<Transform>();
                P1 = other.GetComponent<Player>().Accept;
                P1_inArea = true;
                BallScript.p1 = P1;
                return;
            }
        }

        if (other.gameObject.name == "Player2" && !P2_inArea && !StartPong)// para pegar
        {
            if (!other.GetComponent<Player>().UsingItenDinamic)
            {
                BallScript.P2_ref = other.GetComponent<Transform>();
                P2 = other.GetComponent<Player>().Accept;
                P2_inArea = true;
                BallScript.p2 = P2;
                return;
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
