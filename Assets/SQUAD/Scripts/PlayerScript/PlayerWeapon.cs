using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    public int ID_AtualWeapon;
    int MaxItens;

    public GameObject[] ItemWeaponList; //Armas atuais
    public int[] ID_Weapons;
   
    public Transform LocalToSpawn; //Lugar q a arma nasce
    public GameObject[] ItemParent;
    public Transform spawnToDrop; //Local que a arma dropa
    public Transform Discart;

    Player P;
    WeaponList WL;
    KeyCode Gatilho;
    KeyCode Switch;

    bool isDrop;

    private void Awake()
    {
        WL = FindObjectOfType<WeaponList>();
        Discart = WL.transform;
    }

    private void Start()
    {
        CheckMax();
    }

    private void FixedUpdate()
    {

        if (Input.GetKeyDown(Switch))
        {
            if (MaxItens > 2)
            {
                MaxItens = 2;
            }

            for (int i = 0; i <= MaxItens; i++)
            {
                ItemParent[i].gameObject.SetActive(false);
            }

            ID_AtualWeapon++;
            if(ID_AtualWeapon > 2)
            {
                ID_AtualWeapon = 1;
            }

            ItemParent[ID_AtualWeapon].gameObject.SetActive(true);
        }
    }

    public void UpdateGatilhos()
    {
        P = GetComponent<Player>();

        Gatilho = P.Gatilho;
        Switch = P.Dropar_set;

    }

    public void GetWeapon(int ID)
    {
        
        if (ItemWeaponList[1] == null)
        {
            ItemWeaponList[1] = WL.Weapon[ID];
            ID_Weapons[1] = ID;

            Debug.Log("Item 1");
            Atual(ID,1);
            return;
        }

        if (ItemWeaponList[2] == null)
        {

            ItemWeaponList[2] = WL.Weapon[ID];
            ID_Weapons[2] = ID;

            Debug.Log("Item 2");
            Atual(ID,2);
            return;
        }


        if(ItemWeaponList[1] != null && ID_AtualWeapon == 1 && !isDrop)
        {
            isDrop = true;
            if (isDrop)
            {
                int Id = ID_Weapons[1];
                Instantiate(WL.wItem[Id], spawnToDrop.position, spawnToDrop.rotation);

                ItemWeaponList[1].transform.parent = Discart;
                ItemWeaponList[1].SetActive(false);

                Debug.Log("Drop Item");
                isDrop = false;
            }
            
            ItemWeaponList[1] = WL.Weapon[ID];
            ID_Weapons[1] = ID;

            Debug.Log("Item 1, Switch");
            Atual(ID,1);
            return;
        }


        if (ItemWeaponList[2] != null && ID_AtualWeapon == 2 && !isDrop)
        {
            isDrop = true;
            if (isDrop)
            {
                int Id = ID_Weapons[2];
                Instantiate(WL.wItem[Id], spawnToDrop.position, spawnToDrop.rotation);

                ItemWeaponList[2].transform.parent = Discart;
                ItemWeaponList[2].SetActive(false);

                Debug.Log("Drop Item");
                isDrop = false;
            }

            ItemWeaponList[2] = WL.Weapon[ID];
            ID_Weapons[2] = ID;

            Debug.Log("Item 2, Switch");
            Atual(ID,2);
            return;
        }


    }

    void Atual(int ID, int Type)
    {
        
        ID_AtualWeapon = Type;
       
        GameObject WeaponSet = Instantiate(ItemWeaponList[Type], LocalToSpawn.position, LocalToSpawn.rotation);
        WeaponSet.transform.parent = ItemParent[Type].transform;
        WeaponSet.gameObject.GetComponent<Weapon>().Gatilho = Gatilho;
        WeaponSet.gameObject.GetComponent<Weapon>().P = P;

        ItemWeaponList[Type] = WeaponSet;

        for (int i = 0; i < 3; i++)
        {
            ItemParent[i].gameObject.SetActive(false);
        }

        ItemParent[Type].SetActive(true);
        CheckMax();
        
        Debug.Log("Weapon Update");
        return;
       
    }

    void CheckMax()
    {
        if (ItemWeaponList[1] == null && ItemWeaponList[2] != null)
        {
            MaxItens = 1;
        }

        if (ItemWeaponList[1] != null && ItemWeaponList[2] == null)
        {
            MaxItens = 1;
        }

        if (ItemWeaponList[1] != null && ItemWeaponList[2] != null)
        {
            MaxItens = 2;
        }

        if (ItemWeaponList[1] == null && ItemWeaponList[2] == null)
        {
            MaxItens = 0;
            ID_AtualWeapon = 0;
            ItemParent[0].SetActive(true);
        }

    }

    public void DisabledItem()
    {

        for (int i = 0; i < 3; i++)
        {
            ItemParent[i].gameObject.SetActive(false);
        }

    }

    public void EnabledItem()
    {
        ItemParent[ID_AtualWeapon].gameObject.SetActive(true);
    }

}
