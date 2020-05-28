﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public bool PlayerType; //true = Player1 // false = Player2

    public bool ObjectInArea;
    public GameObject Object;
    public Transform ObjSpawn;
    public GetObject Gobj;
    bool GetObj;

    public int Gold; //Ouro do Jogador
    public float LifeBar;//Vida do jogador em Numero
    public float LifeBar_max = 10;
    float LifeSize; //1/4 da vida
    public float Size;
    public float ManaBar; //Energia do jogador para usar as armas
    public float ManaBar_max;
    public float TimeToIncrement; //add mana
    public float ValueToIncrement;

    public float Level;
    public float L_atual;
    public float L_max;
    public GameObject LevelFX;
    
    public bool UsingItenDinamic; //Se está usando algum item dinamico

    public int Keys_Quantidade; //Maximo 3

    //Nao somem com o tempo. 
    //A Boss Final ficará pra smp na cena.
    //A key Door depois de um tempo, cria raizes para voce ativar e passar por uma wave para obter novamente.

    public GameObject[] KeyList; //Prefab
    public GameObject[] Key; //Atual Keys
    public int[] KeyID; //Quantidade das Chaves
    public GameObject KeyInterface;
    public GameObject[] KeyInterface_Selection;
    public SpriteRenderer[] KeyUI;
    public Sprite[] KeyUIList;

    public int SelectCount;
    public int BeforeNumber;
    public bool SelectKey;
    public bool DropKey;
    public Transform DropKeySpawn;

    public KeyCode Selecionar_set;
    public KeyCode Dropar_set;
    public KeyCode Accept;

    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Right;
    public KeyCode Left;

    public KeyCode Gatilho;
    public KeyCode MapaGatilho;
    public KeyCode Esquiva;
    public KeyCode Turn;

    public int AtualKey;
    public bool IsKey;

    float CountToDisable;
    bool Disabled;
    bool isDrop;

    public GameObject[] ListReOrganize;
    public Sprite[] ListReOrganizeUI;
    int CountRe = 0;
    public int QtdUI;

    public bool Controller1;
    public bool Controller2;

    public GameObject Rescue_Object;
    public SurpriseAttack SA;

    public GameObject WarningFX;

    public PlayerMovement playerMovement;
    public PlayerWeapon playerWeapon;
    public Porta_Default PD;
    public PlayerUI PUI;
    public PlayerLevel PL;

    LevelController LC;
    UI Interface;

    public GameObject[] GroundColor;

    public SpriteRenderer BaloonSprite;
    public Sprite[] BaloonColor;

    public GameObject Life_Hud; 

    public GameObject PlayerDead_Tree;
    SoundController SC;


    private void Start()
    {
        LC = FindObjectOfType<LevelController>();
        PUI = FindObjectOfType<PlayerUI>();
        Interface = FindObjectOfType<UI>();
        PL = FindObjectOfType<PlayerLevel>();
        SC = FindObjectOfType<SoundController>();

        UpdateLevel();

        PUI.ChangeMana(PlayerType, ManaBar, ManaBar_max);
        PUI.ChangeGold(PlayerType, Gold);
        PUI.ChangeLife(PlayerType, LifeBar, LifeBar_max, LifeSize);

        

        if (PlayerType)
        {
            LC.P1_inRoom = true;
            LC.UpdatePlayers();
            UpdateController();

            Interface.P1 = MapaGatilho;
            SetColorGround();


        }
        else
        {
            LC.P2_inRoom = true;
            LC.UpdatePlayers();
            UpdateController();

            Interface.P2 = MapaGatilho;
            SetColorGround();


        }

        InvokeRepeating("SetMana", 1, TimeToIncrement);
    }

    public void UpdateController()
    {
        if (PlayerType)
        {
            if (!Controller1) //PC
            {
                Selecionar_set = KeyCode.Alpha1;
                Dropar_set = KeyCode.Alpha2;
                Accept = KeyCode.Alpha3;

                Up = KeyCode.W;
                Down = KeyCode.S;
                Right = KeyCode.D;
                Left = KeyCode.A;

                Gatilho = KeyCode.Space;
                MapaGatilho = KeyCode.Escape;
                Esquiva = KeyCode.E;
                Turn = KeyCode.Q;

            }
            else //Controle
            {
                Selecionar_set = KeyCode.Joystick1Button4;
                Dropar_set = KeyCode.Joystick1Button5;
                Accept = KeyCode.Joystick1Button0;

                Up = KeyCode.Joystick1Button10;
                Down = KeyCode.Joystick1Button10;
                Right = KeyCode.Joystick1Button11;
                Left = KeyCode.Joystick1Button11;
            }

        }
        else
        {

            if (!Controller2)// PC
            {
                Selecionar_set = KeyCode.PageUp;
                Dropar_set = KeyCode.PageDown;
                Accept = KeyCode.Home;

                Up = KeyCode.UpArrow;
                Down = KeyCode.DownArrow;
                Right = KeyCode.RightArrow;
                Left = KeyCode.LeftArrow;

                Gatilho = KeyCode.K;
                MapaGatilho = KeyCode.O;
                Esquiva = KeyCode.L;
                Turn = KeyCode.J;



            }
            else //Controle
            {
                Selecionar_set = KeyCode.Joystick2Button4;
                Dropar_set = KeyCode.Joystick2Button5;
                Accept = KeyCode.Joystick2Button0;

                Up = KeyCode.Joystick2Button10;
                Down = KeyCode.Joystick2Button10;
                Right = KeyCode.Joystick2Button11;
                Left = KeyCode.Joystick2Button11;
            }
        }

        playerMovement.UpdateMoviment();
        playerWeapon.UpdateGatilhos();
    }

    private void FixedUpdate()
    {
        
        
        if (Disabled)
        {
            CountToDisable += 0.01f;
            if (CountToDisable >= 2f)
            {

                KeyInterface.SetActive(false);

                for (int i = 0; i <= QtdUI; i++)
                {
                    KeyInterface_Selection[i].SetActive(false);
                }

                SelectCount = 0;
                BeforeNumber = QtdUI;

                CountToDisable = 0;
                Disabled = false;
                IsKey = false;


            }
        }

        if (Input.GetKeyDown(Selecionar_set) && Keys_Quantidade >= 1 && !isDrop && !ObjectInArea) //Passar pro lado
        {
            IsKey = true;

            if (Keys_Quantidade == 1)
            {
                QtdUI = 0;
            }

            if (Keys_Quantidade == 2)
            {
                QtdUI = 1;
            }

            if (Keys_Quantidade == 3)
            {
                QtdUI = 2;
            }

            CountToDisable = 0;
            Disabled = true;

            KeyInterface.SetActive(true);

            KeyInterface_Selection[BeforeNumber].SetActive(false);
            KeyInterface_Selection[SelectCount].SetActive(true);
            AtualKey = SelectCount;

            BeforeNumber = SelectCount;

            if (SelectCount == QtdUI)
            {
                BeforeNumber = QtdUI;
                SelectCount = 0;
                return;
            }

            SelectCount++;

        }

        if (Input.GetKeyDown(Dropar_set) && Keys_Quantidade >= 1 && Disabled && !isDrop && !ObjectInArea) //Passar pro lado
        {
            isDrop = true;

            DropKey DKScript;

            GameObject DK = Instantiate(Key[AtualKey], DropKeySpawn.position, DropKeySpawn.rotation);
            DKScript = DK.GetComponent<DropKey>();

            DKScript.BoxDisabled();
            KeyID[DKScript.ID]--;
            
            Key[AtualKey] = null;
            KeyUI[AtualKey].sprite = null;

            Keys_Quantidade--;

            for (int i = 0; i <= 2; i++)
            {
                ListReOrganize[i] = null;
                ListReOrganizeUI[i] = null;
            }

            SetDropKey();
           
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button7) && PlayerType && !Controller1) //Ativando Controle 1
        {
            Controller1 = true;
            UpdateController();
            Debug.Log("Controle 1 Ativado");
        }

        if (Input.GetKeyDown(KeyCode.Joystick2Button7) && !PlayerType && !Controller2) //Ativando Controle 2
        {
            Controller2 = true;
            UpdateController();
            Debug.Log("Controle 2 Ativado");
        }

        if (Input.GetKeyDown(KeyCode.Q) && PlayerType && Controller1) //Ativando Teclado 1
        {
            Controller1 = false;
            UpdateController();
            Debug.Log("Controle 1 Ativado");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && !PlayerType && Controller2) //Ativando Teclado 2
        {
            Controller2 = false;
            UpdateController();
            Debug.Log("Controle 2 Ativado");
        }

        if (Input.GetKeyDown(Selecionar_set) && ObjectInArea && !GetObj)
        {
            Gobj.Get();
            UsingItenDinamic = true;
            playerWeapon.enabled = false;
            GetObj = true;

            playerWeapon.DisabledItem();
            Debug.Log("Pegou Objeto");
        }

        if (Input.GetKeyDown(Dropar_set) && ObjectInArea && GetObj)
        {

            Object.transform.parent = null;
            Gobj.Drop();

            ObjectInArea = false;

            UsingItenDinamic = false;
            playerWeapon.enabled = true;
            GetObj = false;

            playerWeapon.EnabledItem();
            Debug.Log("Soltou Objeto");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && PlayerType)
        {
            Invoke("PlayerIsDead", 3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && !PlayerType)
        {
            Invoke("PlayerIsDead", 3);
        }

        

    }

    public void SetDropKey()
    {
        CountToDisable = 0;
        Disabled = false;

        KeyInterface.SetActive(false);


        for (int i = 0; i <= 2; i++)
        {
            KeyInterface_Selection[i].SetActive(false);      
        }

        SelectCount = 0;
        

        for (int i = 0; i <= 2; i++)
        {
            if (Key[i] != null)
            {
                ListReOrganize[CountRe] = Key[i];
                ListReOrganizeUI[CountRe] = KeyUI[i].sprite;
                CountRe++;     
            }
  
        }
       
        CountRe = 0;

        for (int i = 0; i <= 2; i++)
        {
            Key[i] = ListReOrganize[i];
            KeyUI[i].sprite = ListReOrganizeUI[i];
        }

        Invoke("CancelDrop", 1f);
    }

    void CancelDrop()
    {
        isDrop = false;
    }

    public void SetWarning()
    {
        float cal =  LifeBar_max / Size;
        LifeSize = cal;
    }

    public void SetDamage()
    {
        if (LifeBar <= 0)
        {
            LifeBar = 0f;
            PlayerIsDead();
        }

        if(LifeBar <= LifeSize)
        {
            WarningFX.SetActive(true);
        }
        else
        {
            WarningFX.SetActive(false);
        }

        PUI.ChangeLife(PlayerType, LifeBar, LifeBar_max, LifeSize);
    }

    public void SetMana()
    {
        ManaBar += ValueToIncrement;
        if(ManaBar >= ManaBar_max)
        {
            ManaBar = ManaBar_max;
        }

        PUI.ChangeMana(PlayerType, ManaBar, ManaBar_max);
    }

    public void SetGold()
    {
        PUI.ChangeGold(PlayerType,Gold);
    }

    public void SetLevel(float AddExperience)
    {
        L_atual += AddExperience;
        if(L_atual >= L_max)
        {
            L_atual -= L_max;
            Level++;

            LevelFX.SetActive(true);
            Invoke("CancelFX", 3);

            UpdateLevel();
            return;
        }

        PUI.ChangeLevel(PlayerType, Level, L_atual, L_max);
    }

    public void UpdateLevel()
    {
        PL.ChangeYourStats(this, playerMovement);
    }

    void CancelFX()
    {
        LevelFX.SetActive(false);
    }

    void PlayerIsDead()
    {
        SC.PlayerDead();

        if (PlayerType)
        {
            LC.P1_inRoom = false;
            LC.P1_dead = true;

            if (PD.Rescue)
            {
                if (PD.player2 != null)
                {
                    PD.player2.SA.SetSoloPlayer(PD.player2.Gatilho);
                }
            }

            if (PD.Protect)
            {
                if (PD.player2 != null)
                {
                    PD.OnPlayer = PD.player2.transform;
                }
            }

            if (PD.Target_Wave)
            {
                PD.TargetFinished();
            }

            GameObject Dead = Instantiate(PlayerDead_Tree, transform.position, transform.rotation) as GameObject;
            Dead.GetComponent<PlayerDead>().P1_dead = true;

            Debug.Log("Player1 Morreu.");
        }
        else
        {
            LC.P2_inRoom = false;
            LC.P2_dead = true;

            if (PD.Rescue)
            {
                if (PD.player1 != null)
                {
                    PD.player1.SA.SetSoloPlayer(PD.player1.Gatilho);
                }
            }

            if (PD.Protect)
            {
                if (PD.player1 != null)
                {
                    PD.OnPlayer = PD.player1.transform;
                }
            }

            if (PD.Target_Wave)
            {
                PD.TargetFinished();
            }

            GameObject Dead = Instantiate(PlayerDead_Tree, transform.position, transform.rotation) as GameObject;
            Dead.GetComponent<PlayerDead>().P2_dead = true;

            Debug.Log("Player2 Morreu.");
        }

        
        this.gameObject.SetActive(false);
        LC.UpdatePlayers();  
    }

    public void Revive()
    {
        LifeBar = LifeBar_max / 2;
        ManaBar = ManaBar_max;
        
        UpdateLevel();
    }

    public void SetPositionZero()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    public void SetColorGround()
    {
        if (PlayerType)
        {
            GroundColor[LC.Player1Color].SetActive(true);
            PUI.SetColorInterface(PlayerType, LC.Player1Color);
        }
        else
        {
            GroundColor[LC.Player2Color].SetActive(true);
            PUI.SetColorInterface(PlayerType, LC.Player2Color);
        }
    }
}

