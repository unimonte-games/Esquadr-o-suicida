using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearDecision : MonoBehaviour
{

    public bool Trap;
    public bool Bonus;
    public bool Gatilho;

    public bool P1;
    public bool P2;
    public Player P;

    private void FixedUpdate()
    {
        if (Gatilho)
        {
            Debug.Log("BOOM!");
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1" && P1 && !Gatilho)
        {
            if (Trap)
            {
                Gatilho = true;
                Debug.Log("Armadilha");
            }

            if (Bonus)
            {
                Debug.Log("Bonus");
                this.gameObject.SetActive(false);
            }
        }

        if (other.gameObject.name == "Player1" && P2 && !Gatilho)
        {

            if (Trap)
            {
                Gatilho = true;
                Debug.Log("Armadilha");
            }

            if (Bonus)
            {
                Debug.Log("Bonus");
                this.gameObject.SetActive(false);
            }
        }
    }
    
}
