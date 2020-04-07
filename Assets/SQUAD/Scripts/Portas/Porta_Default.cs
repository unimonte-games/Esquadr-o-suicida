using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[AddComponentMenu("PortaScripts/Default")]
public class Porta_Default : MonoBehaviour
{
    Porta_Default P; //referencia dele mesmo para passar para os inimigos que dropam
    RoomController RoomControl; //referencia de missao
    BoxCollider triggerPlayers; //BoxCollider do Puzzle
    bool StartingWave; //Colidir pra iniciar a wave
    bool CountPlayerTrigger1, CountPlayerTrigger2;
    Player player1;
    Player player2;
    public int ReWave_Door;
    public bool ReWave;

    
    public bool Normal_Wave; //Selecionar a wave NORMAL
    [Range(1, 10)]
    public int Normal_MonstersNumbers; //Inimigos que vao spawnar

    public bool Multiple_Wave; //Selecionar a wave Multipla
    [Range(1, 3)]
    public int Multiple_Min_MonstersNumbers; //Inimigos que vao spawnar
    [Range(3, 10)]
    public int Multiple_Max_MonstersNumbers; //Inimigos que vao spawnar
    [Range(2, 5)]
    public int Multiple_WaveNumbers; //Quantidade de Vezes que vai vir

    public bool Orda_Wave; //Selecionar a wave ORDA
    [Range(3, 5)]
    public int Orda_Min_MonstersNumbers; //Inimigos que vai vir por bloco
    [Range(5, 12)]
    public int Orda_Max_MonstersNumbers; //Inimigos que vai vir por bloco
    [Range(5, 12)]
    public float Orda_RepeatWave; //Quantas vezes os blocos vao ser spanwnados 
    public float Orda_TimeToSpawn = 3; //Tempo do proximo bloco de inimigos

    public float TimerToSpawn = 2; //Tempo para iniciar a waves
    public float WaveNumbers; //Quantidade de Waves
    public int AtualWave; //WaveAtual do jogador
    public int MonstersNumbers; //Quantidade de Monstros para Spawnar
    public int AtualMonsters; //Quantidade de Monstros que foi Spawnado
    public int MonstersDestroy; //Quantidade de monstros que foram destruidos
    public GameObject[] MonstersPrefab; //Prefab de cada Monstro
    public SpawnController SpawnControl;
    public Transform[] LocalSpawn; //Locais que eles vao spawnar

    void Start()
    {
        P = GetComponent<Porta_Default>();
        RoomControl = GetComponent<RoomController>();
        triggerPlayers = GetComponent<BoxCollider>(); //Pegar o Box desse Portao

        StartingWave = false;
    }

    void GoToSpawn()
    {
        Debug.Log("Iniciando Wave");
        
        
        if (Orda_Wave == false)
        {
            AtualMonsters = 0;
            MonstersDestroy = 0;
        }
       

        if (Normal_Wave)
        {
            MonstersNumbers = Normal_MonstersNumbers;
            WaveNumbers = 1;

            Multiple_Wave = false;
            Orda_Wave = false;

        }

        if (Multiple_Wave)
        {
            int MultipleMonsters_temp = Random.Range(Multiple_Min_MonstersNumbers, Multiple_Max_MonstersNumbers);
            MonstersNumbers = MultipleMonsters_temp;

            WaveNumbers = Multiple_WaveNumbers;

            Normal_Wave = false;
            Orda_Wave = false;

        }


        if (Orda_Wave)
        {

            if (Orda_RepeatWave == AtualWave)
            {
                WaveUpdate();
                return;
            }

            int OrdaMonsters_temp = Random.Range(Orda_Min_MonstersNumbers, Orda_Max_MonstersNumbers);
            MonstersNumbers = OrdaMonsters_temp;

            WaveNumbers = Orda_RepeatWave;

            Normal_Wave = false;
            Multiple_Wave = false;

        }

        for (int i = 0; i < MonstersNumbers; i++)
        {
            int RandomLocalNumber = SpawnControl.Acionados - 1;
            int randomLocal = Random.Range(0, RandomLocalNumber);
            int randomMonster = Random.Range(0, 9);

            GameObject Enemy = Instantiate(MonstersPrefab[randomMonster], SpawnControl.ListSpawn[randomLocal].position, SpawnControl.ListSpawn[randomLocal].rotation);
            Enemy.GetComponent<TestingDestroyEnemy>().P_default = P;

            AtualMonsters++;

           
        }
       

        AtualWave++; //Adiciona um contador ao final de dropar os monstros
       
  
    }

    public void WaveUpdate()
    {
        if (AtualMonsters == MonstersDestroy)
        {
            if (AtualWave == WaveNumbers)
            {

                AtualWave = 0;
                WaveNumbers = 0;
                AtualMonsters = 0;
                MonstersDestroy = 0;
                MonstersNumbers = 0;

                Debug.Log("Complete Waves");
                CancelInvoke();

                if (ReWave)
                {
                    RoomControl.ReWaveContest(ReWave_Door);
                    return;
                }

                RoomControl.CompleteRoom(0);
                return;
            }

            Invoke("GoToSpawn", TimerToSpawn);
           
        }
    }

    public void MonstersDefeat()
    {
        MonstersDestroy++;
        WaveUpdate();
    }

    void OrdaRepeatWave()
    {
        GoToSpawn();
    }

    public void PlayerPunition(int Type, int TypeDoor)
    {
        ReWave = true;
        ReWave_Door = TypeDoor;

        if (Type >= 0 && Type <= 4)//Nada
        {
            Debug.Log("Nada Acontece");
            RoomControl.ReWaveContest(ReWave_Door);
        }

        if (Type >= 5 && Type <= 7)//Perder Ouro
        {
            Debug.Log("Perderam Vida");
            RoomControl.ReWaveContest(ReWave_Door);
        }

        if (Type >= 8 && Type <= 10)//Perder Defesa
        {
            Debug.Log("Perderam Defesa");
            RoomControl.ReWaveContest(ReWave_Door);
        }

        if (Type >= 11 && Type <= 13)//Perder Vida
        {

            Debug.Log("Perderam Ouro");
            RoomControl.ReWaveContest(ReWave_Door);
        }

        if (Type >= 14 && Type <= 18) //Wave Surpresa
        {
           
            Debug.Log("Suprise Wave");
            AtualMonsters = 0;
            MonstersDestroy = 0;
            WaveNumbers = 1;

            int RandomReWaveMonsters = Random.Range(3, 7);
            MonstersNumbers = RandomReWaveMonsters;

            for (int i = 0; i < MonstersNumbers; i++)
            {
                int randomLocal = Random.Range(0, 9);
                int randomMonster = Random.Range(0, 9);

                GameObject Enemy = Instantiate(MonstersPrefab[randomMonster], LocalSpawn[randomLocal].transform.position, LocalSpawn[randomLocal].transform.rotation);
                Enemy.GetComponent<TestingDestroyEnemy>().P_default = P;

                AtualMonsters++;

            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            if (StartingWave == false)
            {
                StartingWave = true;

                if (Orda_Wave)
                {
                    InvokeRepeating("OrdaRepeatWave", Orda_TimeToSpawn, Orda_RepeatWave);
                    
                }
                else
                {
                   
                    Invoke("GoToSpawn", TimerToSpawn);
                    
                }
               
                
            }
        }

        if(other.gameObject.name == "Player1")
        {
            CountPlayerTrigger1 = true;
            player1 = other.GetComponent<Player>();

            if (CountPlayerTrigger1 && CountPlayerTrigger2)
            {
                triggerPlayers.enabled = false;

            }

        }


        if (other.gameObject.name == "Player2")
        {
            CountPlayerTrigger2 = true;
            player2 = other.GetComponent<Player>();

            if (CountPlayerTrigger1 && CountPlayerTrigger2)
            {
                triggerPlayers.enabled = false;

            }

        }
    }


}
