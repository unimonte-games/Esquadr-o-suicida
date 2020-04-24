using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public int Value;
 
    public bool isBuy;

    bool inUse1;
    bool inUse2;

    KeyCode GetItem;

    Player player;
    PlayerWeapon playerWeapon;

    WeaponList WL;

    private void Awake()
    {
        WL = FindObjectOfType<WeaponList>();
    }

    private void Start()
    {   
        Value = WL.wValue[ID];
    }

    private void FixedUpdate()
    {
        if(inUse1 || inUse2 && Input.GetKeyDown(GetItem))
        {
            if (isBuy && player.Ouro >= Value)
            {
                player.Ouro -= Value;
                playerWeapon.GetWeapon(ID);

                this.gameObject.SetActive(false);
                return;
            }

            playerWeapon.GetWeapon(ID);
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player1" && !inUse1 && !inUse2)
        {
            inUse1 = true;

            GetItem = other.gameObject.GetComponent<Player>().Accept;
            playerWeapon = other.gameObject.GetComponent<PlayerWeapon>();
            player = other.gameObject.GetComponent<Player>();
        }

        if (other.gameObject.name == "Player2" && !inUse1 && !inUse2)
        {
            inUse2 = true;

            GetItem = other.gameObject.GetComponent<Player>().Accept;
            playerWeapon = other.gameObject.GetComponent<PlayerWeapon>();
            player = other.gameObject.GetComponent<Player>();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1" && inUse1 && !inUse2)
        {
            inUse1 = false;
        }

        if (other.gameObject.name == "Player2" && !inUse1 && inUse2)
        {
            inUse2 = false;
        }

    }
}
