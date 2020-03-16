using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool PlayerType; //true = Player1 // false = Player2
   
    public int Heart = 3; //Vida do jogador em coracoes
    public float LifeBar = 100f; //Vida do jogador em Numero
    public float ManaBar = 100f; //Energia do jogador para usar as armas
    public float DefeseBar = 100f; //Defesa do jogador

     
    void Start()
    {
        
    }

   
   
}
