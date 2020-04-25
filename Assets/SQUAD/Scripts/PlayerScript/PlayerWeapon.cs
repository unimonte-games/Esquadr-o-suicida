using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    public int ID_AtualWeapon;

    public GameObject[] ItemWeaponList; //Armas atuais
   
    public Transform LocalToSpawn; //Lugar q a arma nasce
    public Transform[] ItemParent;
    public Transform spawnToDrop; //Local que a arma dropa

    Player P;
    WeaponList WL;
    KeyCode Gatilho;

    private void Awake()
    {
        WL = FindObjectOfType<WeaponList>();
    }

   

    public void UpdateGatilhos()
    {
        P = GetComponent<Player>();

        Gatilho = P.Gatilho;

    }

    public void GetWeapon(int ID)
    {
        
        if (ItemWeaponList[1] == null)
        {
            ItemWeaponList[1] = WL.wItem[ID];

            Atual(ID,1);
            return;
        }

        if (ItemWeaponList[2] == null)
        {

            ItemWeaponList[2] = WL.wItem[ID];

            Atual(ID,2);
            return;
        }


        if(ItemWeaponList[1] != null && ID_AtualWeapon == 1)
        {

            ItemWeaponList[1] = WL.wItem[ID];

            Atual(ID,1);
            return;
        }


        if (ItemWeaponList[2] != null && ID_AtualWeapon == 2)
        {
            ItemWeaponList[2] = WL.wItem[ID];

            Atual(ID,2);
            return;
        }


    }

    void Atual(int ID, int Type)
    {

        ID_AtualWeapon = Type;

        GameObject WeaponSet = Instantiate(ItemWeaponList[Type], LocalToSpawn.position, LocalToSpawn.rotation);
        WeaponSet.transform.parent = ItemParent[Type];
        WeaponSet.gameObject.GetComponent<Weapon>().Gatilho = Gatilho;
        WeaponSet.gameObject.GetComponent<Weapon>().P = P;

        Debug.Log("Weapon Update");
       
    }
}
