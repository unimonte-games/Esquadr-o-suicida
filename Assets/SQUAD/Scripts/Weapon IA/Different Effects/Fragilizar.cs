using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragilizar : MonoBehaviour
{
    public Weapon W;
    int Aumentar = 2;
    int ManaAumentar = 1;


    private void OnEnable()
    {
        W.Fire_Plant = 1;
        W.Fire_Tech = 1;
        W.Mana = 1;

        Aumentar = 2;
        ManaAumentar = 3;

        InvokeRepeating("SubirDano", 0, 3);

    }

    void SubirDano()
    {
        W.Fire_Plant += Aumentar;
        W.Fire_Tech += Aumentar;
        W.Mana = ManaAumentar;

        Aumentar += 1;
        ManaAumentar += 2;

        if(W.Fire_Plant >= 25)
        {
            W.Fire_Plant = 1;
            W.Fire_Tech = 1;
            W.Mana = 1;

            Aumentar = 2;
            ManaAumentar = 3;
        }

        Debug.Log("Fragilizar: " + W.Fire_Plant);
        Debug.Log("Mana: " + W.Mana);
    }

    private void OnDisable()
    {
        W.Fire_Plant = 1;
        W.Fire_Tech = 1;
        W.Mana = 1;

        Aumentar = 2;
        ManaAumentar = 3;

        CancelInvoke("SubirDano");
    }
}
