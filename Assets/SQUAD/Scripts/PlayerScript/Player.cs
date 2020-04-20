using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public bool PlayerType; //true = Player1 // false = Player2
    public bool PlayerDead;

    public bool ObjectInArea;
    public GameObject Object;
    public Transform ObjSpawn;
    public GetObject Gobj;

    public int Ouro; //Ouro do Jogador
    public int Heart = 3; //Vida do jogador em coracoes
    public float LifeBar = 100f; //Vida do jogador em Numero
    public float ManaBar = 100f; //Energia do jogador para usar as armas
    public float DefeseBar = 100f; //Defesa do jogador

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

    KeyCode Selecionar_set;
    public KeyCode Dropar_set;
    public KeyCode Accept;

    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Right;
    public KeyCode Left;

    public KeyCode Gatilho;

    public int AtualKey;

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

    public PlayerMovement playerMovement;
    public PlayerWeapon playerWeapon;

    LevelController LC;
   
    private void Start()
    {
        LC = FindObjectOfType<LevelController>();
        if (PlayerType)
        {
            LC.P1_inRoom = true;
            LC.UpdatePlayers();
        }

        if (!PlayerType)
        {
            LC.P2_inRoom = true;
            LC.UpdatePlayers();
        }

        UpdateController();
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

                Gatilho = KeyCode.RightShift;

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
                
            }
        }

        if (Input.GetKeyDown(Selecionar_set) && Keys_Quantidade >= 1 && !isDrop && !ObjectInArea) //Passar pro lado
        {

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

        if (Input.GetKeyDown(Selecionar_set) && ObjectInArea)
        {
            Gobj.Get();
            UsingItenDinamic = true;
            playerWeapon.enabled = false;

            Debug.Log("Pegou Objeto");
        }

        if (Input.GetKeyDown(Dropar_set) && ObjectInArea)
        {
            GameObject temp = GameObject.Find("Objetos");
            Object.transform.parent = temp.transform;
            
            ObjectInArea = false;

            UsingItenDinamic = false;
            playerWeapon.enabled = true;

            Debug.Log("Soltou Objeto");
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


   





}
   


     
    
   

