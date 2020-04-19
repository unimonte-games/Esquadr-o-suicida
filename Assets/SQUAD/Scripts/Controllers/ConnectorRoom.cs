using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorRoom : MonoBehaviour
{

    GameObject ref1;
    GameObject ref2;

    public Transform Origem1;
    public Transform Origem2;

    public ConnectorRoom CR;

    KeyCode First;

    public bool CompleteKeyOpenFirst;
    bool Go;
    bool Next;
    bool P1_inArea;
    bool P2_inArea;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(First) && !Next && P1_inArea && P2_inArea)
        {
            Next = true;
            Invoke("NextRoom", 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!CompleteKeyOpenFirst)
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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1" && !P1_inArea)
        {
            P1_inArea = false;
            SetNewFirst();
        }

        if (other.gameObject.name == "Player2" && !P2_inArea)
        {
            P2_inArea = false;
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
        ref2.transform.position = CR.Origem2.transform.position;

        Debug.Log("Proxima Sala!");
    }

}
