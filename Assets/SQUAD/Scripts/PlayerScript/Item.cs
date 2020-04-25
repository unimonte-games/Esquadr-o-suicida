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

    bool Set;

    private void Awake()
    {
        WL = FindObjectOfType<WeaponList>();
    }

    private void FixedUpdate()
    {
        if (!Set)
        {
            if (inUse1 && Input.GetKeyDown(GetItem))
            {
                Set = true;
                if (isBuy && player.Ouro >= Value)
                {
                    player.Ouro -= Value;
                    playerWeapon.GetWeapon(ID);
                    this.gameObject.SetActive(false);


                    Debug.Log("Player 1 comprou um item!");
                    return;
                }


                playerWeapon.GetWeapon(ID);
                this.gameObject.SetActive(false);

                Debug.Log("Player 1 pegou um item!");
                return;
            }

            if (inUse2 && Input.GetKeyDown(GetItem))
            {
                Set = true;
                if (isBuy && player.Ouro >= Value)
                {
                    player.Ouro -= Value;
                    playerWeapon.GetWeapon(ID);

                    Debug.Log("Player 2 comprou um item!");

                    this.gameObject.SetActive(false);
                    return;
                }

                
                playerWeapon.GetWeapon(ID);
                this.gameObject.SetActive(false);

                Debug.Log("Player 2 pegou um item!");
                return;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player1" && !inUse1 && !inUse2)
        {
            
            player = other.gameObject.GetComponent<Player>();
            if (!player.UsingItenDinamic)
            {

                inUse1 = true;

                GetItem = player.Accept;
                playerWeapon = other.gameObject.GetComponent<PlayerWeapon>();
            }
        }

        if (other.gameObject.name == "Player2" && !inUse1 && !inUse2)
        {
            player = other.gameObject.GetComponent<Player>();
            if (!player.UsingItenDinamic)
            {

                inUse2 = true;

                GetItem = player.Accept;
                playerWeapon = other.gameObject.GetComponent<PlayerWeapon>();
            }
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
