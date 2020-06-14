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
            DUB_ED.SetAmigoMorto();
            isVoice = true;
        }

        if (other.gameObject.name == "Player2" && P1_dead && !isVoice)
        {
            DUB_NIX.SetAmigoMorto();
            isVoice = true;
        }


    }
    void Cancel()
    {
        SC.enabled = false;
    }
}
