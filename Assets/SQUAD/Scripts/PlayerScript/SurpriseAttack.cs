using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseAttack : MonoBehaviour
{
    public bool Player1;
    public bool Player2;
    public float LifeMax = 50;

    public bool Solo;
    public KeyCode PlayerSolo;

    public Porta_Default PD;
    LevelController LC;

    PlayerUI PUI;

    float tempFrame;

    private void Awake()
    {
        PUI = FindObjectOfType<PlayerUI>();
        LC = FindObjectOfType<LevelController>();
    }

    private void FixedUpdate()
    {
        if (Solo)
        {
            tempFrame += Time.deltaTime;
            if (Input.GetKeyDown(PlayerSolo) && tempFrame > 1f)
            {
                tempFrame = 0f;

                LifeMax -= 1;
                PUI.SetRescueDamage(LifeMax);
                if (LifeMax <= 0)
                {
                    PD.RescueComplete();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hit")
        {
            other.gameObject.SetActive(false);

            LifeMax -= 1;
            PUI.SetRescueDamage(LifeMax);
            if (LifeMax <= 0)
            {
                PD.RescueComplete();
            } 

            
        }
    }


    public void SetSoloPlayer(KeyCode Gatilho)
    {

        PlayerSolo = Gatilho;
        Solo = true;

        Debug.Log("Solo Rescue!");

    }
}
