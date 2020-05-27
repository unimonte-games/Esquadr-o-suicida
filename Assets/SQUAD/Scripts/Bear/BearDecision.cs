using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearDecision : MonoBehaviour
{

    public bool Trap;
    public bool Bonus;
    public bool Gatilho;
    public Animation A;

    public bool P1;
    public bool P2;
    public Player P;

    public PlayerUI PUI;
    public GameObject[] WeaponsExclusives;
    int index;
    public int Damage;

    private void Start()
    {
        PUI = FindObjectOfType<PlayerUI>();
        index = Random.Range(0, 2);
        Damage = Random.Range(25, 100);


    }

   void Cancel()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1" && P1 && !Gatilho)
        {
            if (Trap)
            {
                P.LifeBar -= Damage;
                P.SetDamage();

                Gatilho = true;
                A.Play("BearTrap");

                Invoke("Cancel",3);
                Debug.Log("Armadilha");
            }

            if (Bonus)
            {
                A.Play("BearBonus");
                P.LifeBar += Damage;
                P.ManaBar += Damage;
                P.SetDamage();

                Instantiate(WeaponsExclusives[index], transform.position, transform.rotation);

                Debug.Log("Bonus");
                Invoke("Cancel", 3);
            }
        }

        if (other.gameObject.name == "Player2" && P2 && !Gatilho)
        {

            if (Trap)
            {
                P.LifeBar -= Damage;
                P.SetDamage();

                Gatilho = true;
                A.Play("BearTrap");

                Invoke("Cancel", 3);
                Debug.Log("Armadilha");
            }

            if (Bonus)
            {
                A.Play("BearBonus");
                P.LifeBar += Damage;
                P.ManaBar += Damage;
                P.SetDamage();

                Instantiate(WeaponsExclusives[index], transform.position, transform.rotation);

                Debug.Log("Bonus");
                Invoke("Cancel", 3);
            }
        }
    }


    public void AutoTrap()
    {
        P.LifeBar -= Damage;
        P.SetDamage();

        Gatilho = true;
        A.Play("BearTrap");

        Invoke("Cancel", 3);
        Debug.Log("Armadilha");
    }
    
}
