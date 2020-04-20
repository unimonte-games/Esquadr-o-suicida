using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseAttack : MonoBehaviour
{
    public bool Player1;
    public bool Player2;
    public int LifeMax = 25;

    public bool Solo;
    public KeyCode PlayerSolo;

    public Porta_Default PD;
    LevelController LC;

    float tempFrame;

    private void Awake()
    {
        LC = FindObjectOfType<LevelController>();
    }

    private void FixedUpdate()
    {
        tempFrame += 0.1f;
        if (Solo && Input.GetKeyDown(PlayerSolo) && tempFrame > 1f)
        {
            tempFrame = 0f;

            LifeMax -= 1;
            if (LifeMax <= 0)
            {
                PD.RescueComplete();

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hit")
        {
            other.gameObject.SetActive(false);

            LifeMax -= 1;
            if(LifeMax <= 0)
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
