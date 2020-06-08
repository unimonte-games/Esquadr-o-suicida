using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseLife : MonoBehaviour
{
    public EnemyStats ES;
    public int LifeAdd;
    bool Add;

    public AudioSource AtkSound;

    private void OnEnable()
    {
        AtkSound.Play();
    }

    private void Start()
    {
        Add = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" && !Add)
        {
            Add = true;

            float tempMax = ES.L_Max;
            float tempAtual = ES.Life_Atual + LifeAdd;

            if(tempAtual >= tempMax)
            {
                tempMax = tempAtual;
            }

            ES.L_Max = tempMax;
            ES.Life_Atual = tempAtual;

            ES.TakeEnergy(LifeAdd);
            Invoke("Cancel", 2);
        }
    }

    void Cancel()
    {
        Add = false;
    }


}
