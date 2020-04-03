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

    public bool KeyFinal; //Serve para abrir a porta do BOSS 
    public int KeysDoor; //Serve para desbloquear Portas 

    //Todos que forem discartados sumiram depois de um tempo.
    public int KeyTreasure; //Serve para abrir qualquer Báu [Qualquer Coisa pode vir] [Apenas 1]
    public int KeyMedicKit; //Serve para Abrir Kits de Medico [Kits Medicos - Vida, defesa, mana ou coracao]
    public int KeyWeaponTech; //Serve para abrir as Caixas Tecnologicas especiais [Weapons Especiais]
    public int KeyEpic; //Serve para para abrir Bau Lendario (ROXO) [Baus Especial - 2 Items]
    public int KeyLegendary; //Serve para o Bau Lendário (DOURADO) [Bau Especial - 3 Items]

    public GameObject[] KeyList; //Prefab
    public GameObject[] Key; //Atual Keys
    public GameObject KeyInterface;
    public GameObject[] KeyInterface_Selection;
    public SpriteRenderer[] KeyUI;
    public Sprite[] KeyUIList;
    
    public int SelectCount = 0;
    public int BeforeNumber = 3;
    public bool SelectKey;
    public bool DropKey;
    public GameObject DKC_Prefab;
    public DropKey DKController;
    public Transform DropKeySpawn;

    KeyCode Selecionar_set;
    KeyCode Dropar_set;
    public int AtualKey;

    float CountToDisable;
    bool Disabled;

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
                DKC_Prefab.SetActive(false);
            }
        }

        if (Input.GetKeyDown(Selecionar_set) && Keys_Quantidade >= 1) //Passar pro lado
        {
            DKC_Prefab.SetActive(true);

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

            SelectCount++;
            KeyInterface_Selection[SelectCount].SetActive(true);
            KeyInterface_Selection[BeforeNumber].SetActive(false);

            AtualKey = SelectCount - 1;



        }

        if (Input.GetKeyDown(Dropar_set) && Keys_Quantidade >= 1 && Disabled && SelectCount > 0) //Passar pro lado
        {
            
            for (int i = 0; i <= 3; i++)
            {
                if(DKController.C_check[i] != null)
                {
                    DropKeySpawn = DKController.C_check[i].transform;
                    i = 4;
 
                    Instantiate(Key[AtualKey], DropKeySpawn.position, DropKeySpawn.rotation);

                }
            }
        }


    }


}
   


     
    
   

