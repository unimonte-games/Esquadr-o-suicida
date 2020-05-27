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

    Player P1_Player;
    Player P2_Player;

    PlayerMovement P1_ref;
    PlayerMovement P2_ref;

    float tempSpeed1;
    float tempSpeed2;

    public int P1_Placar;
    public int P2_Placar;

    public GameObject RacerTarget;
    public SpawnController SC;
    public bool OnRacer;

    public int timeToCancel;
    public int timeToCancelRacer;

    private void FixedUpdate()
    {
        if (P1_inArea && Input.GetKeyDown(P1) && !P1_ready)
        {
            P1_ready = true;
            P1_ref.speed += 6;
            

            Debug.Log("Patins Ativado no Player 1");
            Invoke("CancelP1", timeToCancel);
        }

        if (P2_inArea && Input.GetKeyDown(P2) && !P2_ready)
        {
            P2_ready = true;
            P2_ref.speed += 6;


            Debug.Log("Patins Ativado no Player 2");
            Invoke("CancelP2", timeToCancel);
        }

        if(P1_ready && P2_ready && !OnRacer)
        {
            OnRacer = true;
            Invoke("StartRacer", 3);
        }

    }

    void StartRacer()
    {
        ChangeTarget();
        Invoke("CancelRacer", timeToCancelRacer);
        Debug.Log("Start Racer!");
    }

    void CancelRacer()
    {
        if(P1_Placar > P2_Placar)
        {
            P1_Player.LifeBar += 150;
            P1_Player.SetDamage();
            P1_ref.speed = tempSpeed1;

            Debug.Log("Player 1 Venceu!");
            this.gameObject.SetActive(false);
            return;

        }

        if (P2_Placar > P1_Placar)
        {
            P2_Player.LifeBar += 150;
            P2_Player.SetDamage();
            P2_ref.speed = tempSpeed2;

            Debug.Log("Player 2 Venceu!");
            this.gameObject.SetActive(false);
            return;
        }

        if(P1_Placar == P2_Placar)
        {
            P1_Player.LifeBar += 25;
            P1_Player.SetDamage();
            P1_ref.speed = tempSpeed1;

            P2_Player.LifeBar += 25;
            P2_Player.SetDamage();
            P2_ref.speed = tempSpeed2;

            Debug.Log("Empate!");
            this.gameObject.SetActive(false);
            return;
        }

        
    }

    void CancelP1()
    {
        if (!OnRacer)
        {
            Debug.Log("Patins Player 1, cancelado");
            P1_ref.speed = tempSpeed1;
        }
       
    }

    void CancelP2()
    {
        if (!OnRacer)
        {
            Debug.Log("Patins Player 2, cancelado");
            P2_ref.speed = tempSpeed2;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player1" && !P1_inArea)
        {
            if (!other.GetComponent<Player>().UsingItenDinamic)
            {
                P1_inArea = true;
                P1_ref = other.GetComponent<PlayerMovement>();
                P1_Player = other.GetComponent<Player>();
                P1 = other.GetComponent<Player>().Accept;

                tempSpeed1 = P1_ref.speed;
                
            }
        }

        if (other.gameObject.name == "Player2" && !P2_inArea)
        {
            if (!other.GetComponent<Player>().UsingItenDinamic)
            {
                P2_inArea = true;
                P2_ref = other.GetComponent<PlayerMovement>();
                P2_Player = other.GetComponent<Player>();
                P2 = other.GetComponent<Player>().Accept;

                tempSpeed2 = P2_ref.speed;

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

    public void ChangeTarget()
    {
        int tempIndex = Random.Range(0, SC.Acionados - 1);
        GameObject racer = Instantiate(RacerTarget, SC.ListSpawn[tempIndex].position, SC.ListSpawn[tempIndex].rotation) as GameObject;
        racer.transform.parent = SC.SceneTransformList.transform;
        racer.GetComponent<PatinsRacerTarget>().PJ = this;
        
    }
}
