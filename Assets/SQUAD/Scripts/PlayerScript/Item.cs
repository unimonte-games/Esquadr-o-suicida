using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    public int ID;
    public int Value;
 
    public bool isBuy;
    public bool isTech;

    bool inUse1;
    bool inUse2;

    KeyCode GetItem;

    Player player;
    PlayerWeapon playerWeapon;

    WeaponList WL;
    public Outline O;

    public TextMeshProUGUI FirePlant;
    public TextMeshProUGUI TechPlant;
    public TextMeshProUGUI Mana;
    public TextMeshProUGUI Frame;
    public TextMeshProUGUI Range;
    public GameObject GoldSet;
    public TextMeshProUGUI gold;
    public GameObject LimitSet;
    public TextMeshProUGUI Limit;
    public TextMeshProUGUI[] NameList;
    public GameObject[] NameListSet;

    SphereCollider S;

    Vector3 Body;

    bool Set;
    private void Awake()
    {
        WL = FindObjectOfType<WeaponList>();
        S = GetComponent<SphereCollider>();
    }

    private void OnEnable()
    {
        S.enabled = false;
        Invoke("SetBox", 3);
    }

    void SetBox()
    {
        S.enabled = true;
    }

    private void Start()
    {
        transform.localRotation = new Quaternion(0, 0, 0, 0);

        Weapon W = WL.Weapon[ID].GetComponent<Weapon>();

        FirePlant.text = "" + W.Fire_Plant;
        TechPlant.text = "" + W.Fire_Tech;
        Mana.text = "" + W.Mana;
        Frame.text = "" + W.FrameRate;
        Range.text = "" + W.Range;

        NameListSet[W.Rarity].SetActive(true);
        NameList[W.Rarity].text = "" + W.Name;

        if (isBuy)
        {
            gold.text = "" + Value;
            GoldSet.gameObject.SetActive(true);
        }

        if (isTech)
        {
            Limit.text = "" + W.Limit;
            LimitSet.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {

        if (inUse1 && Input.GetKeyDown(GetItem) && !Set)
        {
            Debug.Log("Weapon");
            Set = true;
            if (!isBuy)
            {
                playerWeapon.GetWeapon(ID);
                O.DisabledLine();
                this.gameObject.SetActive(false);

                Debug.Log("Player 1 pegou um item!");
                return;
            }

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
            else
            {
                Debug.Log("P1 - Energia Insuficiente!");
            }

        }

        if (inUse2 && Input.GetKeyDown(GetItem) && !Set)
        {
            Set = true;
            if (!isBuy)
            {
                playerWeapon.GetWeapon(ID);
                O.DisabledLine();
                this.gameObject.SetActive(false);

                Debug.Log("Player 2 pegou um item!");
                return;
            }

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
            else
            {
                Debug.Log("P2 - Energia Insuficiente!");
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
