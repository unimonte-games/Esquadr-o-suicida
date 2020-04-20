using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorRoom : MonoBehaviour
{

    GameObject ref1;
    GameObject ref2;

    BoxCollider ThisBox;

    public Transform Origem1;
    public Transform Origem2;

    public ConnectorRoom CR;

    KeyCode First;

    public bool CompleteKeyOpenFirst;
    bool Go;
    bool Next;
    bool P1_inArea;
    bool P2_inArea;

    LevelController LC;


    private void Awake()
    {
        LC = FindObjectOfType<LevelController>();
    }

    private void Start()
    {
        ThisBox = GetComponent<BoxCollider>(); 
    }

    private void FixedUpdate()
    {
     
        if (Input.GetKeyDown(First) && !Next && P1_inArea && P2_inArea)
        {
            Next = true;
            Invoke("NextRoom", 1);
        }

        if (CompleteKeyOpenFirst)
        {
            ThisBox.enabled = false;
        }
        else
        {
            ThisBox.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!CompleteKeyOpenFirst)
        {
            if (LC.SoloPlayer)
            {
                if (other.gameObject.name == "Player1" && !P1_inArea)
                {
                    P1_inArea = true;
                    P2_inArea = true;

                    ref1 = other.gameObject; //mesma referencia

                    if (!Go)
                    {
                        Go = true;
                        First = other.GetComponent<Player>().Accept;
                    }

                    return;
                }

                if (other.gameObject.name == "Player2" && !P2_inArea)
                {
                    P1_inArea = true;
                    P2_inArea = true;

                    ref1 = other.gameObject; //mesma referencia

                    if (!Go)
                    {
                        Go = true;
                        First = other.GetComponent<Player>().Accept;
                    }

                    return;
                }
            }
            else
            {

                if (other.gameObject.name == "Player1" && !P1_inArea)
                {
                    P1_inArea = true;
                    ref1 = other.gameObject;

                    if (!Go)
                    {
                        Go = true;
                        First = other.GetComponent<Player>().Accept;
                    }
                }

                if (other.gameObject.name == "Player2" && !P2_inArea)
                {
                    P2_inArea = true;
                    ref2 = other.gameObject;

                    if (!Go)
                    {
                        Go = true;
                        First = other.GetComponent<Player>().Accept;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1")
        {
            P1_inArea = false;
            Go = false;
            Next = false;
            SetNewFirst();
        }

        if (other.gameObject.name == "Player2")
        {
            P2_inArea = false;
            Go = false;
            Next = false;
            SetNewFirst();
        }
    }

    void SetNewFirst()
    {
        if (!P1_inArea && !P2_inArea)
        {
            Go = false;
        }
    }

    void NextRoom()
    {
        ref1.transform.position = CR.Origem1.transform.position;
        if (!LC.SoloPlayer) //se n for solo, envia os dois
        {
            ref2.transform.position = CR.Origem2.transform.position;
        }

        Go = false;
        Next = false;
        P1_inArea = false;
        P2_inArea = false;
        
        Debug.Log("Proxima Sala!");
    }

}
