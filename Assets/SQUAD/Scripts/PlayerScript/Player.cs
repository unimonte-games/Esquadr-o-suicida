using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool PlayerType; //true = Player1 // false = Player2

    public int Gold; //Ouro do Jogador
    public int Heart = 3; //Vida do jogador em coracoes
    public float LifeBar = 100f; //Vida do jogador em Numero
    public float ManaBar = 100f; //Energia do jogador para usar as armas
    public float DefeseBar = 100f; //Defesa do jogador
   
    public int Keys_Quantidade; //Maximo 2

    //Nao somem com o tempo. 
    //A Boss Final ficará pra smp na cena.
    //A key Door depois de um tempo, cria raizes para voce ativar e passar por uma wave para obter novamente.
    
    public bool KeyFinal; //Serve para abrir a porta do BOSS 
    public int KeysDoor; //Serve para desbloquear Portas 

    //Todos que forem discartados sumiram depois de um tempo.
    public int KeyTheasure; //Serve para abrir qualquer Báu [Qualquer Coisa pode vir] [Apenas 1]
    public int KeyMedicKit; //Serve para Abrir Kits de Medico [Kits Medicos - Vida, defesa, mana ou coracao]
    public int KeyWeaponTech; //Serve para abrir as Caixas Tecnologicas especiais [Weapons Especiais]
    public int KeyEpic; //Serve para para abrir Bau Lendario (ROXO) [Baus Especial - 2 Items]
    public int KeyLegendary; //Serve para o Bau Lendário (DOURADO) [Bau Especial - 3 Items]

}
   


     
    
   

