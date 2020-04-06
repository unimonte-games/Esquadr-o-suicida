using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public bool PlayerType; //true = Player1 // false = Player2

    public int Gold; //Ouro do Jogador
    public int Heart = 3; //Vida do jogador em coracoes
    public float LifeBar = 100f; //Vida do jogador em Numero
    public float ManaBar = 100f; //Energia do jogador para usar as armas
    public float DefeseBar = 100f; //Defesa do jogador

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
    KeyCode Dropar_set;
    public KeyCode Accept;

    public int AtualKey;

    float CountToDisable;
    bool Disabled;
    bool isDrop;

    public GameObject[] ListReOrganize;
    public Sprite[] ListReOrganizeUI;
    int CountRe = 0;
    public int QtdUI;



    private void Start()
    {
        if (PlayerType)
        {
            Selecionar_set = KeyCode.Q;
            Dropar_set = KeyCode.E;
            Accept = KeyCode.Space;
        }
        else
        {
            Selecionar_set = KeyCode.Alpha1;
            Dropar_set = KeyCode.Alpha2;
            Accept = KeyCode.Alpha3;
        }
    }


    private void Update()
    {

        if (Disabled)
        {
            CountToDisable += 0.1f;
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

        if (Input.GetKeyDown(Selecionar_set) && Keys_Quantidade >= 1 && !isDrop) //Passar pro lado
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

        if (Input.GetKeyDown(Dropar_set) && Keys_Quantidade >= 1 && Disabled && !isDrop) //Passar pro lado
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
   


     
    
   

