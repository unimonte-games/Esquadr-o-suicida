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
    public Player player1;
    public Player player2;
    public int ReWave_Door;
    public bool ReWave;
    public bool Rescue;
    public bool Protect;
    public Transform OnPlayer; //referencia do jogador escolhido
    public bool Peace;
    public GameObject[] PeaceList;
    int CountPeaceList;
    public GameObject OnPeace;
    bool AllTargetEnemy;
    int EnemyIDforTarget;

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

    public bool Target_Wave;
    [Range(1, 3)]
    public int Target_Min_MonstersNumbers; //Inimigos que vai vir por bloco
    [Range(2, 6)]
    public int Target_Max_MonstersNumbers; //Inimigos que vai vir por bloco
    [Range(2, 12)]
    public float target_RepeatWave; //Quantas vezes os blocos vao ser spanwnados 
    public float Target_TimeToSpawn = 7; //Tempo do proximo bloco de inimigos
    int ID_Player1Target, Player1_enemyCount, P1_Total, ID_Player2Target, Player2_enemyCount, P2_Total, CountTarget, CountAllEnemy1, CountAllEnemy2;
    bool TargetFinish, ChoiceEnemys, Player1_Finish, Player2_Finish;
    public GameObject[] TargetAllEnemy1, TargetAllEnemy2;

    public float TimerToSpawn = 2; //Tempo para iniciar a waves
    public float WaveNumbers; //Quantidade de Waves
    public float AtualWave; //WaveAtual do jogador
    public int MonstersNumbers; //Quantidade de Monstros para Spawnar
    public int AtualMonsters; //Quantidade de Monstros que foi Spawnado
    public int MonstersDestroy; //Quantidade de monstros que foram destruidos
    public GameObject[] MonstersPrefab; //Prefab de cada Monstro
    public SpawnController SpawnControl;
    public Transform parentSpawn; //Lugar que vao dropar

    LevelController LC;

    void Start()
    {
        LC = FindObjectOfType<LevelController>();
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
            Target_Wave = false;

            MonstersNumbers = Normal_MonstersNumbers;
            WaveNumbers = 1;
        }

        if (Multiple_Wave)
        {
            Normal_Wave = false;
            Orda_Wave = false;
            Target_Wave = false;

            int MultipleMonsters_temp = Random.Range(Multiple_Min_MonstersNumbers, Multiple_Max_MonstersNumbers);
            MonstersNumbers = MultipleMonsters_temp;


            WaveNumbers = Multiple_WaveNumbers;

        }

        if (Orda_Wave)
        {
            Normal_Wave = false;
            Multiple_Wave = false;
            Target_Wave = false;

            if (Orda_RepeatWave == AtualWave)
            {
                WaveUpdate();
                return;
            }


            int OrdaMonsters_temp = Random.Range(Orda_Min_MonstersNumbers, Orda_Max_MonstersNumbers);
            MonstersNumbers = OrdaMonsters_temp;

            WaveNumbers = Orda_RepeatWave;
        }

        if (Target_Wave)
        {
            Normal_Wave = false;
            Multiple_Wave = false;
            Orda_Wave = false;

            if (!ChoiceEnemys)
            {
                ChoiceEnemys = true;

                if (LC.SoloPlayer)
                {
                    if(player1 != null)
                    {
                        ID_Player1Target = Random.Range(0, 12);
                        P1_Total = Random.Range(1, 7);
                    }

                    if (player2 != null)
                    {
                        ID_Player2Target = Random.Range(0, 12);
                        P2_Total = Random.Range(1, 7);
                    }
                }
                else
                {
                    ID_Player1Target = Random.Range(0, 12);
                    ID_Player2Target = Random.Range(0, 12);

                    P1_Total = Random.Range(1, 7);
                    P2_Total = Random.Range(1, 7);
                }
               
            }
  
            if (target_RepeatWave == AtualWave)
            {
                WaveUpdate();
                return;
            }

            int targetMonsters_temp = Random.Range(Target_Min_MonstersNumbers, Target_Max_MonstersNumbers);
            MonstersNumbers = targetMonsters_temp;

            WaveNumbers = target_RepeatWave;

            CountTarget++;
            if(CountTarget >= 1)
            {
                CountTarget = 0;
                TargetSetEnemy();
            }

        }

        for (int i = 0; i < MonstersNumbers; i++)
        {
            int RandomLocalNumber = SpawnControl.Acionados - 1;
            int randomLocal = Random.Range(0, RandomLocalNumber);
            int randomMonster = Random.Range(0, 12);

            if (AllTargetEnemy)
            {
                randomMonster = EnemyIDforTarget;
            }

            GameObject Enemy = Instantiate(MonstersPrefab[randomMonster], SpawnControl.ListSpawn[randomLocal].position, SpawnControl.ListSpawn[randomLocal].rotation);
            Enemy.GetComponent<TestingDestroyEnemy>().P_default = P;
            Enemy.transform.parent = parentSpawn;

            if (Target_Wave)
            {
                TargetAllEnemy1[CountAllEnemy1] = Enemy;
                CountAllEnemy1++; 
            }

            if (Protect)
            {

               TestingDestroyEnemy enemyRef = Enemy.GetComponent<TestingDestroyEnemy>();

                enemyRef.PlayerTarget = OnPlayer;
                enemyRef.LC = LC;
                enemyRef.InTarget = true;
            }

            if (Peace)
            {
                if (CountPeaceList <= 250)// << é preciso mudar esse valor alguma hora
                {
                    PeaceList[CountPeaceList] = Enemy;
                    CountPeaceList++;
                }

            }


            AtualMonsters++;

        }

        AtualWave++; //Adiciona um contador ao final de dropar os monstros


    }

    public void WaveUpdate()
    {
        if (AtualMonsters == MonstersDestroy)
        {
            if (Target_Wave)
            {
                if (!TargetFinish)
                {
                    AtualWave = 0; //Vai sempre reiniciar
                    Invoke("GoToSpawn", TimerToSpawn);
                    return;
                }
                else
                {
                    return;
                }


            }

            if (AtualWave == WaveNumbers)
            {
                AtualWave = 0;
                WaveNumbers = 0;
                AtualMonsters = 0;
                MonstersDestroy = 0;
                MonstersNumbers = 0;

                if (ReWave)
                {
                    if (Rescue)
                    {
                        return;
                    }
                    RoomControl.ReWaveContest(ReWave_Door); //Wave Surprise vai encerrar - Surprise
                    return;
                }

                Debug.Log("Complete Waves");
                CancelInvoke("OrdaRepeatWave");

                RoomControl.CompleteRoom(0);
                return;
            }

            Invoke("GoToSpawn", TimerToSpawn);

        }
    }

    public void MonstersDefeat(int PlayerToDestroy, int EnemyID)
    {
        if (Peace)
        {
            PeaceOtherSpawn();
        }

        if (Target_Wave)
        {
            if (PlayerToDestroy == 1 && EnemyID == ID_Player1Target && !Player1_Finish)//Player1
            {
                Player1_enemyCount++;
                if(Player1_enemyCount >= P1_Total)
                {
                    Debug.Log("P1 Finalizou!");
                    Player1_Finish = true;
                    TargetFinished();
                }
            }

            if (PlayerToDestroy == 2 && EnemyID == ID_Player2Target && !Player2_Finish)//Player2
            {
                Player2_enemyCount++;
                if (Player2_enemyCount >= P2_Total)
                {
                    Debug.Log("P2 Finalizou!");
                    Player2_Finish = true;
                    TargetFinished();
                }
            }
        }

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

        if(player1 != null)
        {
            player1.PD = this;
        }

        if (player2 != null)
        {
            player2.PD = this;
        }

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

            if (LC.SoloPlayer)
            {
                if (LC.P1_inRoom)
                {
                    player1.playerMovement.ToMove = true;
                    player1.SA.Player1 = true;
                    player1.SA.PD = P;
                    player1.playerWeapon.enabled = false;
                    player1.SA.SetSoloPlayer(player1.Gatilho);

                    player1.Rescue_Object.SetActive(true);
                    Debug.Log("Player 1 foi sequestrado!");

                }

                if (LC.P2_inRoom)
                {
                    player2.playerMovement.ToMove = true;
                    player2.SA.Player2 = true;
                    player2.SA.PD = P;
                    player2.playerWeapon.enabled = false;
                    player2.SA.SetSoloPlayer(player2.Gatilho);

                    player2.Rescue_Object.SetActive(true);
                    Debug.Log("Player 2 foi sequestrado!");
                }

            }
            else
            {

                int SelectPlayer = Random.Range(1, 10);
                if (SelectPlayer <= 5)
                {
                    player1.playerMovement.ToMove = true;
                    player1.SA.Player1 = true;
                    player1.SA.PD = P;
                    player1.playerWeapon.enabled = false;

                    player1.Rescue_Object.SetActive(true);
                    Debug.Log("Player 1 foi sequestrado!");
                }
                if (SelectPlayer >= 6)
                {
                    player2.playerMovement.ToMove = true;
                    player2.SA.Player2 = true;
                    player2.SA.PD = P;
                    player2.playerWeapon.enabled = false;

                    player2.Rescue_Object.SetActive(true);
                    Debug.Log("Player 2 foi sequestrado!");
                }
            }

            Normal_Wave = false;
            Orda_Wave = false;
            Multiple_Wave = true;

            Invoke("GoToSpawn", TimerToSpawn);

        }

        if (Type >= 16 && Type <= 20)//Protect/Target
        {
            Debug.Log("Protect! Target Wave.");
            Protect = true;

            Normal_Wave = false;
            Multiple_Wave = false;
            Orda_Wave = true;

            if (LC.SoloPlayer)
            {
                if (LC.P1_inRoom)
                {
                    OnPlayer = player1.transform;
                    Debug.Log("Player 1 é o Alvo!");
                }

                if (LC.P2_inRoom)
                {
                    OnPlayer = player2.transform;
                    Debug.Log("Player 2 é o Alvo!");
                }
            }
            else
            {
                int SelectPlayer = Random.Range(1, 10);
                if (SelectPlayer <= 5)
                {
                    OnPlayer = player1.transform;
                    Debug.Log("Player 1 é o Alvo!");
                }
                if (SelectPlayer >= 6)
                {
                    OnPlayer = player2.transform;
                    Debug.Log("Player 2 é o Alvo!");
                }
            }

           

            InvokeRepeating("OrdaRepeatWave", Orda_TimeToSpawn, Orda_RepeatWave);
        }

        if (Type >= 21 && Type <= 25)//Peace 
        {
            Debug.Log("Peace Wave!");
            Peace = true;

            Normal_Wave = false;
            Multiple_Wave = false;
            Orda_Wave = true;

            OnPeace.GetComponent<PeaceCounter>().PD = P;
            OnPeace.SetActive(true);

            InvokeRepeating("OrdaRepeatWave", Orda_TimeToSpawn, Orda_RepeatWave);
        }

        if (Type >= 26 && Type <= 30)//All Enemys
        {
            Debug.Log("All Enemys!");
            AllTargetEnemy = true;

            Normal_Wave = false;
            Orda_Wave = false;
            Multiple_Wave = true;

            EnemyIDforTarget = Random.Range(0, 12);

            Invoke("GoToSpawn", TimerToSpawn);
        }


    }

    void PeaceOtherSpawn()
    {
        if (CountPeaceList >= 250)// << é preciso mudar esse valor alguma hora
        {
            return;
        }
        Debug.Log("Droparam +2!");
        for (int i = 0; i <= 1; i++)//Dropam +2 a cada morte
        {
            int RandomLocalNumber = SpawnControl.Acionados - 1;
            int randomLocal = Random.Range(0, RandomLocalNumber);
            int randomMonster = Random.Range(0, 12);

            GameObject Enemy = Instantiate(MonstersPrefab[randomMonster], SpawnControl.ListSpawn[randomLocal].position, SpawnControl.ListSpawn[randomLocal].rotation);
            Enemy.GetComponent<TestingDestroyEnemy>().P_default = P;
            Enemy.transform.parent = parentSpawn;

            PeaceList[CountPeaceList] = Enemy;
            CountPeaceList++;

            AtualMonsters++;
        }
    }

    public void PeaceDestroyAllEnemys()
    {
        Peace = false;

        for (int i = 0; i <= CountPeaceList; i++)
        {
            if (PeaceList[i] != null)
            {
                PeaceList[i].SetActive(false);
                PeaceList[i] = null;
            }
        }

        OnPeace.SetActive(false);
        CancelInvoke("OrdaRepeatWave");
        CancelInvoke("GoToSpawn");

        RoomControl.ReWaveContest(ReWave_Door);
        Debug.Log("Todos da Peace List foram destruidos!");
    }

    void TargetSetEnemy()
    {
        Debug.Log("Dropando Enemys");
        int RandomLocalNumber = SpawnControl.Acionados - 1;
        int randomLocal = Random.Range(0, RandomLocalNumber);

        GameObject Enemy1 = Instantiate(MonstersPrefab[ID_Player1Target], SpawnControl.ListSpawn[randomLocal].position, SpawnControl.ListSpawn[randomLocal].rotation);
        Enemy1.GetComponent<TestingDestroyEnemy>().P_default = P;
        Enemy1.transform.parent = parentSpawn;

        TargetAllEnemy2[CountAllEnemy2] = Enemy1;
        CountAllEnemy2++;

        randomLocal = Random.Range(0, RandomLocalNumber);

        GameObject Enemy2 = Instantiate(MonstersPrefab[ID_Player2Target], SpawnControl.ListSpawn[randomLocal].position, SpawnControl.ListSpawn[randomLocal].rotation);
        Enemy2.GetComponent<TestingDestroyEnemy>().P_default = P;
        Enemy2.transform.parent = parentSpawn;

        TargetAllEnemy2[CountAllEnemy2] = Enemy2;
        CountAllEnemy2++;



    }

    void TargetFinished()
    {

       if(Player1_Finish && Player2_Finish)
        {
            Debug.Log("Target concluido!");
            TargetFinish = true;
            TargetDestroyAllEnemies();
            return;
        }

        if (LC.SoloPlayer && Player1_Finish || Player2_Finish)
        {
            Debug.Log("Target concluido!");
            TargetFinish = true;
            TargetDestroyAllEnemies();
        }
    }

    void TargetDestroyAllEnemies()
    {
        for (int i = 0; i <= CountAllEnemy1; i++)
        {
            if (TargetAllEnemy1[i] != null)
            {
                TargetAllEnemy1[i].SetActive(false);
                TargetAllEnemy1[i] = null;
            }
        }


        for (int i = 0; i <= CountAllEnemy2; i++)
        {
            if (TargetAllEnemy2[i] != null)
            {
                TargetAllEnemy2[i].SetActive(false);
                TargetAllEnemy2[i] = null;
            }
        }

        AtualWave = 0;
        WaveNumbers = 0;
        AtualMonsters = 0;
        MonstersDestroy = 0;
        MonstersNumbers = 0;

        Debug.Log("Complete Waves");
        CancelInvoke("OrdaRepeatWave");
        CancelInvoke("GoToSpawn");

        RoomControl.CompleteRoom(0);

    }

    public void RescueComplete()
    {
        Rescue = false;

        if(player1 != null)
        {
            player1.playerMovement.ToMove = false;
            player1.playerWeapon.enabled = true;
            player1.Rescue_Object.SetActive(false);
        }

        if(player2 != null)
        {
            player2.playerMovement.ToMove = false;
            player2.playerWeapon.enabled = true;
            player2.Rescue_Object.SetActive(false);
        }
        
        AtualWave = 0;
        WaveNumbers = 0;
        AtualMonsters = 0;
        MonstersDestroy = 0;
        MonstersNumbers = 0;

        
        CancelInvoke("OrdaRepeatWave");
        CancelInvoke("GoToSpawn");

        RoomControl.ReWaveContest(ReWave_Door);
        Debug.Log("Rescue Complete!");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //Iniciar a wave após o primeiro jogador colidir
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

        if (other.gameObject.name == "Player1") //Pegar a referencia do jogador 1 e aguardar os dois estarem em cena para tirar o box
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
