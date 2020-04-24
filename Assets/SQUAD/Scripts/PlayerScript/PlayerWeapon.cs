using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    public int ID_AtualWeapon;

    public GameObject w_Shot;
    public float w_Fire;
    public float w_FrameRate;
    public int w_Mana;
    public int w_Range;


    public int[] weaponID;
    public GameObject[] WeaponPlayer;
    public GameObject[] WeaponToDrop;
    public GameObject[] ShotWeapon;
    public float[] Fire;
    public float[] FrameRate;
    public int[] Mana;
    public int[] Range;
    public int[] Nivel;

    public float Force;
    public KeyCode Gatilho;

    public Transform spawn;
    public Transform spawnToDrop;

    Player P;
    WeaponList WL;

    bool PlayerController;
    float countToShoting;


    private void FixedUpdate()
    {
        countToShoting += 0.1f;
        if (Input.GetKeyDown(Gatilho) && countToShoting >= w_FrameRate)
        {
                countToShoting = 0f;
                GameObject bullet = Instantiate(w_Shot, spawn.transform.position, Quaternion.identity) as GameObject;
                bullet.GetComponent<Destroy>().PlayerDestroy = P.PlayerType;
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * Force);
        }
    }

    public void UpdateGatilhos()
    {
        P = GetComponent<Player>();

        Gatilho = P.Gatilho;

    }

    public void GetWeapon(int ID)
    {
        if (WeaponPlayer[1] == null)
        {
            weaponID[1] = ID;
            WeaponPlayer[1] = WL.wItem[ID];
            WeaponToDrop[1] = WL.wToDrop[ID];
            ShotWeapon[1] = WL.wShoting[ID];
            Fire[1] = WL.wFire[ID];
            FrameRate[1] = WL.wFrameRate[ID];
            Mana[1] = WL.wMana[ID];
            Range[1] = WL.wRange[ID];
            Nivel[1] = WL.wNivel[ID];

            Atual(1);
            return;
        }

        if (WeaponPlayer[2] == null)
        {
            weaponID[2] = ID;
            WeaponPlayer[2] = WL.wItem[ID];
            WeaponToDrop[2] = WL.wToDrop[ID];
            ShotWeapon[2] = WL.wShoting[ID];
            Fire[2] = WL.wFire[ID];
            FrameRate[2] = WL.wFrameRate[ID];
            Mana[2] = WL.wMana[ID];
            Range[2] = WL.wRange[ID];
            Nivel[2] = WL.wNivel[ID];

            Atual(2);
            return;
        }


        if(WeaponPlayer[1] != null && ID_AtualWeapon == 1)
        {
            Instantiate(WeaponToDrop[1], spawnToDrop.position, spawnToDrop.rotation);

            weaponID[1] = ID;
            WeaponPlayer[1] = WL.wItem[ID];
            WeaponToDrop[1] = WL.wToDrop[ID];
            ShotWeapon[1] = WL.wShoting[ID];
            Fire[1] = WL.wFire[ID];
            FrameRate[1] = WL.wFrameRate[ID];
            Mana[1] = WL.wMana[ID];
            Range[1] = WL.wRange[ID];
            Nivel[1] = WL.wNivel[ID];

            Atual(1);
            return;
        }


        if (WeaponPlayer[2] != null && ID_AtualWeapon == 2)
        {
            Instantiate(WeaponToDrop[2], spawnToDrop.position, spawnToDrop.rotation);

            weaponID[2] = ID;
            WeaponPlayer[2] = WL.wItem[ID];
            WeaponToDrop[2] = WL.wToDrop[ID];
            ShotWeapon[2] = WL.wShoting[ID];
            Fire[2] = WL.wFire[ID];
            FrameRate[2] = WL.wFrameRate[ID];
            Mana[2] = WL.wMana[ID];
            Range[2] = WL.wRange[ID];
            Nivel[2] = WL.wNivel[ID];

            Atual(2);
            return;
        }


    }

    void Atual(int W)
    {
        ShotWeapon[W] = w_Shot;
        Fire[W] = w_Fire;
        FrameRate[W] = w_FrameRate;
        Mana[W] = w_Mana;
        Range[W] = w_Range;
       
    }
}
