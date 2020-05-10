using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Outline O;

    public Text FirePlant;
    public Text TechPlant;
    public Text Mana;
    public Text Frame;
    public Text Range;
    public Text gold;

    public GameObject OnGold;
    
    bool Set;

    private void Awake()
    {
        WL = FindObjectOfType<WeaponList>(); 
    }

    private void Start()
    {
        FirePlant.text = "" + WL.Weapon[ID].GetComponent<Weapon>().Fire_Plant;
        TechPlant.text = "" + WL.Weapon[ID].GetComponent<Weapon>().Fire_Tech;
        Mana.text = "" + WL.Weapon[ID].GetComponent<Weapon>().Mana;
        Frame.text = "" + WL.Weapon[ID].GetComponent<Weapon>().FrameRate;
        Range.text = "" + WL.Weapon[ID].GetComponent<Weapon>().Range;

        if (isBuy)
        {
            gold.text = "" + Value;
            OnGold.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (!Set)
        {
            if (inUse1 && Input.GetKeyDown(GetItem))
            {
                Set = true;
                if (isBuy && player.Gold >= Value)
                {
                    player.Gold -= Value;
                    player.SetGold();
                    playerWeapon.GetWeapon(ID);
                    O.DisabledLine();
                    this.gameObject.SetActive(false);


                    Debug.Log("Player 1 comprou um item!");
                    return;
                }

                playerWeapon.GetWeapon(ID);
                O.DisabledLine();
                this.gameObject.SetActive(false);

                Debug.Log("Player 1 pegou um item!");
                return;
            }

            if (inUse2 && Input.GetKeyDown(GetItem))
            {
                Set = true;
                if (isBuy && player.Gold >= Value)
                {
                    player.Gold -= Value;
                    player.SetGold();
                    playerWeapon.GetWeapon(ID);

                    Debug.Log("Player 2 comprou um item!");

                    O.DisabledLine();
                    this.gameObject.SetActive(false);
                    return;
                }

                playerWeapon.GetWeapon(ID);
                O.DisabledLine();
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
