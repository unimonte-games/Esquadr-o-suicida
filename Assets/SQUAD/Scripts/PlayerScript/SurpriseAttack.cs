using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseAttack : MonoBehaviour
{
    public bool Player1;
    public bool Player2;
    public float LifeMax = 100;

    public bool Solo;
    public KeyCode PlayerSolo;

    public Porta_Default PD;
    LevelController LC;

    PlayerUI PUI;

    float tempFrame;
    bool isDead;

    private void Awake()
    {
        PUI = FindObjectOfType<PlayerUI>();
        LC = FindObjectOfType<LevelController>();
    }

    private void FixedUpdate()
    {
        if (Solo && !isDead)
        {
            tempFrame += Time.deltaTime;
            if (Input.GetKeyDown(PlayerSolo) && tempFrame > 1f)
            {
                tempFrame = 0f;

                LifeMax -= 1;
                PUI.SetRescueDamage(LifeMax);
                if (LifeMax <= 0)
                {
                    isDead = true;
                    PD.RescueComplete();
                    this.gameObject.SetActive(false);
                    
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hit" && !isDead)
        {

            Hit h = other.GetComponent<Hit>();
            LifeMax -= h.Hit_Plant;
            PUI.SetRescueDamage(LifeMax);
            if (LifeMax <= 0)
            {
                isDead = true;
                PD.RescueComplete();
                this.gameObject.SetActive(false);
            }

            other.gameObject.SetActive(false);

        }
    }

    public void SetSoloPlayer(KeyCode Gatilho)
    {

        PlayerSolo = Gatilho;
        Solo = true;

        Debug.Log("Solo Rescue!");

    }
}
