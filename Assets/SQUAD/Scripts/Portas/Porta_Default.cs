using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[AddComponentMenu("PortaScripts/Default")]
public class Porta_Default : MonoBehaviour
{
    public Porta_Default P; //referencia dele mesmo para passar para os inimigos que dropam
    public RoomController RoomControl; //referencia de missao
    public BoxCollider triggerPlayers; //BoxCollider do Puzzle
    bool StartingWave; //Colidir pra iniciar a wave
    bool CountPlayerTrigger1, CountPlayerTrigger2;
    Player player1;
    Player player2;
    public int ReWave_Door;
    public bool ReWave;
    bool Rescue;

    
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
            Multiple_Wave = false;
            Orda_Wave = false;

            MonstersNumbers = Normal_MonstersNumbers;
            WaveNumbers = 1;
        }

        if (Multiple_Wave)
        {
            Normal_Wave = false;
            Orda_Wave = false;

            int MultipleMonsters_temp = Random.Range(Multiple_Min_MonstersNumbers, Multiple_Max_MonstersNumbers);
            MonstersNumbers = MultipleMonsters_temp;

            if (ReWave)//Se for uma wave Surpresa - Surprise, Rescue
            {
                AtualMonsters = 0;
                MonstersDestroy = 0;
                AtualWave = 0;
                WaveNumbers = Random.Range(1, 3);
            }
            else
            {
                WaveNumbers = Multiple_WaveNumbers;
            }

        }


        if (Orda_Wave)
        {
            Normal_Wave = false;
            Multiple_Wave = false;

            if (Orda_RepeatWave == AtualWave)
            {
                WaveUpdate();
                return;
            }

            int OrdaMonsters_temp = Random.Range(Orda_Min_MonstersNumbers, Orda_Max_MonstersNumbers);
            MonstersNumbers = OrdaMonsters_temp;

            WaveNumbers = Orda_RepeatWave;

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
                    if (Rescue)
                    {
                        return;
                    }
                    RoomControl.ReWaveContest(ReWave_Door); //Wave Surprise vai encerrar - Surprise
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

        if (Type >= 0 && Type <= 5)//Nada
        {
            Debug.Log("Nada Acontece");
            RoomControl.ReWaveContest(ReWave_Door);
        }

        if (Type >= 6 && Type <= 10) //Wave Surpresa
        {

            Debug.Log("Suprise Wave");

            Normal_Wave = false;
            Orda_Wave = false;
            Multiple_Wave = true;

            Invoke("GoToSpawn", TimerToSpawn);
        }

        if (Type >= 11 && Type <= 15)//Rescue
        {
            Debug.Log("Rescue!");
            Rescue = true;

            int SelectPlayer = Random.Range(1, 10);
            if(SelectPlayer <= 5)
            {
                player1.FPSWalkScript.ToMove = true;
                player1.SA.Player1 = true;
                player1.SA.PD = P;

                player1.Rescue_Object.SetActive(true);
                Debug.Log("Player 1 foi sequestrado!");
            }
            if(SelectPlayer >= 6)
            {
                player2.FPSWalkScript.ToMove = true;
                player2.SA.Player2 = true;
                player2.SA.PD = P;
                
                player2.Rescue_Object.SetActive(true);
                Debug.Log("Player 2 foi sequestrado!");
            }

            Normal_Wave = false;
            Orda_Wave = false;
            Multiple_Wave = true;

            Invoke("GoToSpawn", TimerToSpawn);

        }

        if (Type >= 16 && Type <= 20)//Perder Defesa
        {
            Debug.Log("Perderam Defesa");
            RoomControl.ReWaveContest(ReWave_Door);
        }

        if (Type >= 21 && Type <= 25)//Perder Vida
        {

            Debug.Log("Perderam Ouro");
            RoomControl.ReWaveContest(ReWave_Door);
        }


    }

    public void RescueComplete()
    {
        Rescue = false;
        player1.FPSWalkScript.ToMove = false;
        player2.FPSWalkScript.ToMove = false;

        player1.Rescue_Object.SetActive(false);
        player2.Rescue_Object.SetActive(false);

        RoomControl.ReWaveContest(ReWave_Door);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") //Iniciar a wave após o primeiro jogador colidir
        {

            if (!StartingWave)
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
       
        if(other.gameObject.name == "Player1") //Pegar a referencia do jogador 1 e aguardar os dois estarem em cena para tirar o box
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
