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
    
    public int SelectCount = 0;
    public int BeforeNumber = 3;
    public bool SelectKey;
    public bool DropKey;
    public Transform DropKeySpawn;

    KeyCode Selecionar_set;
    KeyCode Dropar_set;
    public int AtualKey;

    float CountToDisable;
    bool Disabled;
    bool isDrop;

    public GameObject[] ListReOrganize;
    public Sprite[] ListReOrganizeUI;
    int CountRe = 0;



    private void Start()
    {
        if (PlayerType)
        {
            Selecionar_set = KeyCode.Q;
            Dropar_set = KeyCode.E;
        }
        else
        {
            Selecionar_set = KeyCode.Alpha1;
            Dropar_set = KeyCode.Alpha2;
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
                
                KeyInterface_Selection[SelectCount].SetActive(false);


                SelectCount = 0;
                BeforeNumber = Keys_Quantidade;

                CountToDisable = 0;
                Disabled = false;
                
            }
        }

        if (Input.GetKeyDown(Selecionar_set) && Keys_Quantidade >= 1 && !isDrop) //Passar pro lado
        {
           

            CountToDisable = 0;
            Disabled = true;

            KeyInterface.SetActive(true);
            BeforeNumber = SelectCount;

            if (SelectCount >= Keys_Quantidade)
            {
                SelectCount = 0;
                KeyInterface_Selection[BeforeNumber].SetActive(false);
                return;
                
            }

            KeyInterface_Selection[BeforeNumber].SetActive(false);
            KeyInterface_Selection[SelectCount].SetActive(true);
            
            SelectCount++;
            

        }

        if (Input.GetKeyDown(Dropar_set) && Keys_Quantidade >= 1 && Disabled && SelectCount > 0 && !isDrop) //Passar pro lado
        {
            isDrop = true;

            DropKey DKScript;

            GameObject DK = Instantiate(Key[AtualKey], DropKeySpawn.position, DropKeySpawn.rotation);
            DKScript = DK.GetComponent<DropKey>();

            DKScript.BoxDisabled();
            KeyID[DKScript.ID]--;
            
            Key[AtualKey] = null;
            KeyUI[SelectCount].sprite = null;

            Keys_Quantidade--;

            for (int i = 0; i <= Keys_Quantidade; i++)
            {
                ListReOrganize[i] = null;
            }

            for (int i = 1; i < Keys_Quantidade; i++)
            {
                ListReOrganizeUI[i] = null;

            }

            SetDropKey();
        }


    }

    void SetDropKey()
    {
        
        KeyInterface.SetActive(false);

        KeyInterface_Selection[SelectCount].SetActive(false);
        KeyInterface_Selection[BeforeNumber].SetActive(false);

        SelectCount = 0;
        BeforeNumber = Keys_Quantidade;

        CountToDisable = 0;
        Disabled = false;
        

        for (int i = 0; i <= Keys_Quantidade; i++)
        {
            if (Key[i] != null)
            {
                ListReOrganize[CountRe] = Key[i];
                CountRe++;     
            }   
        }
       
        CountRe = 0;

        for (int i = 0; i <= Keys_Quantidade; i++)
        {
            Key[i] = ListReOrganize[i];    
        }

        for (int i = 1; i < Keys_Quantidade; i++)
        {
            KeyUI[i].sprite = ListReOrganizeUI[i];

        }


        Invoke("CancelDrop", 1f);
    }

    void CancelDrop()
    {
        isDrop = false;
    }


}
   


     
    
   

