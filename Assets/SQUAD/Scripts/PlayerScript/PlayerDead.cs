using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    public bool P1_dead;
    public bool P2_dead;

    public DUBSystemEd DUB_ED;
    public DUBSystemNix DUB_NIX;
    bool isVoice;

    public SphereCollider SC;

    private void Start()
    {
        Invoke("Cancel", 25);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && other.GetComponent<EnemyStats>().InTarget)
        {
            other.GetComponent<EnemyStats>().Change();
        }

        if (other.gameObject.name == "Player1" && P2_dead && !isVoice)
        {
            Invoke("DUB", 5);
        }

        if (other.gameObject.name == "Player2" && P1_dead && !isVoice)
        {
            Invoke("DUB", 5);
        }


    }
    void Cancel()
    {
        SC.enabled = false;
    }

    void DUB()
    {
        isVoice = true;
        if (P2_dead)
        {
            DUB_ED.SetAmigoMorto();
        }
        
        if(P1_dead)
        {
            DUB_NIX.SetAmigoMorto();
        }
    }
}
