using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int weaponID;

    public GameObject Shot;
    public int Fire_Plant;
    public int Fire_Tech;
    public float FrameRate;
    public int Mana;
    public float Range;

    public float Force;

    public KeyCode Gatilho;
    float countToShoting;

    public Transform spawnShot;
    public Player P;
    public PlayerUI PUI;

    public bool Punch;
    public bool Tech;
    public float Limit;
    public bool DontFire;

    private void Awake()
    {
        PUI = FindObjectOfType<PlayerUI>();
    }

    private void FixedUpdate()
    {
        countToShoting += 0.1f;
        if (Input.GetKeyDown(Gatilho) && countToShoting >= FrameRate && P.ManaBar >= Mana && !DontFire)
        {
            countToShoting = 0f;
            GameObject bullet = Instantiate(Shot, spawnShot.transform.position, Quaternion.identity) as GameObject;
            Hit HitEnemy = bullet.GetComponent<Hit>();


            HitEnemy.PlayerDestroy = P.PlayerType;
            HitEnemy.time = Range;
            HitEnemy.Hit_Plant = Fire_Plant;
            HitEnemy.Hit_Tech = Fire_Tech;

            if (Tech)
            {
                Limit--;
                if(Limit <= 0)
                {
                    DontFire = true;
                    Debug.Log("Arma Tecnologica acabou!");
                }
            }
            else
            {
                P.ManaBar -= Mana;
            }
            

            PUI.ChangeMana(P.PlayerType, P.ManaBar, P.ManaBar_max);

            if (Punch)
            {
                return;
            }

            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * Force);


        }

    }

}
