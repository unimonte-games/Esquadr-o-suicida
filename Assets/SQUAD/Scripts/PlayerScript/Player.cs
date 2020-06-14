using System.Collections;
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
    public int BeforeNumbe;
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

    public Transform Rescue_Object;
    public SurpriseAttack SA;

    public GameObject WarningFX;
    public GameObject TargetRacerFX;

    public PlayerMovement playerMovement;
    public PlayerWeapon playerWeapon;
    public Porta_Default PD;
    public PlayerUI PUI;
    public PlayerLevel PL;

    LevelController LC;
    UI Interface;

    public GameObject GC;
    public GameObject[] GroundColor;
    public GameObject ExtraUI;

    public GameObject Life_Hud;

    public Rigidbody rb;
    public CapsuleCollider CapsuleC;
    public GameObject weapons;

    public Animator Anin;
    public GameObject PlayerDead_Tree;
    SoundController SC;

    float TimeToclick = 1;

    public AudioSource[] KeySound;
    public AudioSource LevelUP_Sound;
    public AudioSource Energy_Sound;

    public DUBSystemEd DUB_Ed;
    public DUBSystemNix DUB_Nix;

    private void Start()
    {
        LC = FindObjectOfType<LevelController>();
        PUI = FindObjectOfType<PlayerUI>();
        Interface = FindObjectOfType<UI>();
        PL = FindObjectOfType<PlayerLevel>();
        SC = FindObjectOfType<SoundController>();
        DUB_Ed = FindObjectOfType<DUBSystemEd>();
        DUB_Nix = FindObjectOfType<DUBSystemNix>();

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
            CountToDisable += Time.deltaTime;
            if (CountToDisable >= 3f)
            {

                KeyInterface.SetActive(false);

                KeyInterface_Selection[0].SetActive(false);
                KeyInterface_Selection[1].SetActive(false);
                KeyInterface_Selection[2].SetActive(false);

                SelectCount = 0;
                //BeforeNumber = QtdUI;

                CountToDisable = 0;
                Disabled = false;
                IsKey = false;
                TimeToclick = 1;



            }
        }

        if (IsKey)
        {
            TimeToclick += Time.deltaTime;
        }
        
        if (Input.GetKeyDown(Selecionar_set) && Keys_Quantidade >= 1 && !isDrop && !ObjectInArea) //Passar pro lado
        {
            IsKey = true;
            if (TimeToclick > 0.5f)
            {
                TimeToclick = 0f;
                Debug.Log("SelectCount: " + SelectCount);

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

                KeyInterface_Selection[0].SetActive(false);
                KeyInterface_Selection[1].SetActive(false);
                KeyInterface_Selection[2].SetActive(false);

                KeyInterface_Selection[SelectCount].SetActive(true);
                AtualKey = SelectCount;

                KeySound[2].Play();

                //BeforeNumber = SelectCount;


                if (SelectCount == QtdUI)
                {
                    //BeforeNumber = QtdUI;
                    SelectCount = 0;

                    return;
                }

                SelectCount++;

            }

        }

        if (Input.GetKeyDown(Dropar_set) && Keys_Quantidade >= 1 && Disabled && !isDrop && !ObjectInArea) //Drop
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

    }

    public void SetNewKey()
    {
        KeySound[0].Play();
    }

    public void SetDropKey()
    {

        KeySound[1].Play();

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

            LevelUP_Sound.Play();
            UpdateLevel();
            return;
        }

        PUI.ChangeLevel(PlayerType, Level, L_atual, L_max);
    }

    public void UpdateLevel()
    {
        
        PL.ChangeYourStats(this, playerMovement);
    }

    public void SetEnergy()
    {
        Energy_Sound.Play();
    }

    void CancelFX()
    {
        LevelFX.SetActive(false);
    }

    void PlayerIsDead()
    {
        playerMovement.enabled = false;
        playerWeapon.enabled = false;
        weapons.SetActive(false);

        SC.PlayerDead();
        Anin.SetTrigger("isDie");
        rb.constraints = RigidbodyConstraints.FreezeAll;
        CapsuleC.enabled = false;

        GC.SetActive(false);
        ExtraUI.SetActive(false);
        
        if (PlayerType)
        {
            LC.P1_inRoom = false;
            LC.P1_dead = true;

            DUB_Ed.SetDerrota();

            if (PD.Rescue)
            {
                if (PD.player2 != null)
                {
                    PD.RescueSetRaiz();
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

            Dead.GetComponent<PlayerDead>().DUB_NIX = DUB_Nix;


            Debug.Log("Player1 Morreu.");
        }
        else
        {
            LC.P2_inRoom = false;
            LC.P2_dead = true;

            DUB_Nix.SetDerrota();

            if (PD.Rescue)
            {
                if (PD.player1 != null)
                {
                    PD.RescueSetRaiz();
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
            
            Dead.GetComponent<PlayerDead>().DUB_ED = DUB_Ed;

            Debug.Log("Player2 Morreu.");
        }
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

    public void SetColorBaloon(bool On)
    {

        if (PlayerType)
        {
            PUI.SetColorBaloon(PlayerType, LC.Player1Color, On);
        }
        else
        {
            PUI.SetColorBaloon(PlayerType, LC.Player2Color, On);
        }


    }

    public void SetIconCar (bool On, int Type)
    {
        PUI.SetIconCar(PlayerType, Type, On);
    }

    public void EnabledOrDisabledGroundColor (bool On)
    {
        if (On)
        {
            GC.SetActive(true);
        }
        else
        {
            GC.SetActive(false);
        }
    }

    public void SetPPB (bool On)
    {
        PUI.SetIconPPB(PlayerType, On);
    }

    public void SetColorArch(bool On)
    {

        if (PlayerType)
        {
            PUI.SetColorArchBattle(PlayerType, LC.Player1Color, On);
        }
        else
        {
            PUI.SetColorArchBattle(PlayerType, LC.Player2Color, On);
        }


    }

    public void SetPointsArch(bool On, int SetPoints)
    {
        if (PlayerType)
        {
            PUI.SetPointsArch(PlayerType, SetPoints);
        }
        else
        {
            PUI.SetPointsArch(PlayerType, SetPoints);
        }
    }

    public void SetWinnerArch (int w)
    {
        PUI.SetArchWinner(w);
    }

    public void SetPatins(bool On)
    {
        PUI.SetPatinsRacer(PlayerType, On, false);
       
    }

    public void SetPatinsRacer ()
    {
        PUI.SetPatinsRacer(PlayerType, true, true);
    }

    public void SetPointsPatins(int SetPoints)
    {
        PUI.SetPointsPatinsRacer(PlayerType, SetPoints);
    }

    public void SetWinnerPatins(int w)
    {
        PUI.SetPatinsRacerWinner(w);
    }

    public void SetRacerEffect(bool Atived)
    {
        if (Atived)
        {
            TargetRacerFX.SetActive(true);
        }
        else
        {
            TargetRacerFX.SetActive(false);
        }
       
    }

}

