using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    public int weaponID;
    public int WeaponState;

    public GameObject Shot;
    public int Fire_Plant;
    public int Fire_Tech;
    public float FrameRate;
    public int Mana;
    public float Range;
    public string Name;
    public int Rarity;

    public float Force;

    public KeyCode Gatilho;
    float countToShoting;

    public Transform spawnShot;
    public Player P;
    public Animation Anin;
    public PlayerUI PUI;

    public bool Punch;
    public bool Tech;

    public float Limit;
    public bool DontFire;

    bool FirstSet;
    public AudioSource Gatilho_Sound;

    private void Awake()
    {
        PUI = FindObjectOfType<PlayerUI>();
    }

    private void OnEnable()
    {
        if (FirstSet)
        {
            P.Anin.SetInteger("WeaponState", WeaponState);
            P.Anin.SetBool("Change", true);
            Invoke("SetChange", 0.75f);
        }
    }

    private void Start()
    {
        P.Anin.SetInteger("WeaponState", WeaponState);
        P.Anin.SetBool("Change", true);
        Invoke("SetChange", 0.75f);

        if (!FirstSet)
        {
            Invoke("SetWeapon", 1);
        }
        
        Debug.Log("Set");

    }

    void SetWeapon()
    {
        FirstSet = true;
    }

    void SetChange()
    {
        P.Anin.SetBool("Change", false);
    }

    private void FixedUpdate()
    {

        countToShoting += Time.deltaTime;
        if (Input.GetKeyDown(Gatilho) && countToShoting >= FrameRate && P.ManaBar >= Mana && !DontFire)
        {
            
            countToShoting = 0f;

            Gatilho_Sound.Play();
            Anin.Play();
            GameObject bullet = Instantiate(Shot, spawnShot.transform.position, Quaternion.identity) as GameObject;

            Hit HitEnemy = bullet.GetComponent<Hit>();

            HitEnemy.PlayerDestroy = P.PlayerType;
            HitEnemy.time = Range;
            HitEnemy.Hit_Plant = Fire_Plant;
            HitEnemy.Hit_Tech = Fire_Tech;


            if (Tech)
            {
                Limit--;
                if (Limit <= 0)
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
