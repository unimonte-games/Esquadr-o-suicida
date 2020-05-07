using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEnter : MonoBehaviour
{
    public EnemyStats ES;
    public SphereCollider SC;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1" && !ES.Player1_inArea && !ES.PlayerInArea && !ES.InTarget)
        {
       
            ES.PlayerTarget = other.gameObject.transform;
            ES.PlayerInArea = true;
            ES.Player1_inArea = true;

            ES.OnAttack();

            Debug.Log("Player 1 Detectado!");
        }


        if (other.gameObject.name == "Player2" && !ES.Player2_inArea && !ES.PlayerInArea && !ES.InTarget)
        {
            ES.PlayerTarget = other.gameObject.transform;
            ES.PlayerInArea = true;
            ES.Player2_inArea = true;

            ES.OnAttack();

            Debug.Log("Player 2 Detectado!");
        }

        if (ES.InTarget && other.gameObject.name == ES.PlayerTarget.name)
        {
            ES.PlayerInArea = true;
            ES.OnAttack();
            Debug.Log("Ele é o alvo, ataque!");
        }

       
    }
}
