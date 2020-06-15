using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[AddComponentMenu("PortaScripts/Default")]
public class Porta_Default : MonoBehaviour
{
    public Porta_Default P; //referencia dele mesmo para passar para os inimigos que dropam
    public SpawnController SC_spawn; //referencia para o IA Patrol dos inimigos.
    public RoomController RoomControl; //referencia de missao
    public RoomMusic RM; //referencia da musica
    public BoxCollider triggerPlayers; //BoxCollider do Puzzle
    bool StartingWave; //Colidir pra iniciar a wave
    public Player player1;
    public Player player2;
    public int ReWave_Door;
    public bool ReWave;
    public bool Rescue;
    public GameObject Raiz;
    GameObject SetRaiz;
    public bool Protect;
    public Transform OnPlayer; //referencia do jogador escolhido
    public bool Peace;
    public GameObject[] PeaceList;
    int CountPeaceList;
    public GameObject OnPeace;
    public float TimeToSurviveInPeace;
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
    int ID_Player1Target, Player1_enemyCount, P1_TargetElement, P2_TargetElement, P1_Total, ID_Player2Target, Player2_enemyCount, P2_Total, CountTarget, CountAllEnemy1, CountAllEnemy2;
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

    public GameObject[] M_Level_0;
    public GameObject[] M_Level_1;
    public GameObject[] M_Level_2;
    public GameObject[] M_Level_3;
    public GameObject[] M_Level_4;
    public GameObject[] M_Level_5;

    LevelController LC;
    PlayerUI PUI;
    public DoorEnabled GetDoorEnabled;

    DUBSystemEd DUB_Ed;
    DUBSystemNix DUB_Nix;

    private void Awake()
    {
        PUI = FindObjectOfType<PlayerUI>();
        LC = FindObjectOfType<LevelController>();
        RM = GetComponent<RoomMusic>();
        DUB_Ed = FindObjectOfType<DUBSystemEd>();
        DUB_Nix = FindObjectOfType<DUBSystemNix>();

        StartingWave = false;

        if(LC.Level == 0)
        {
            for (int i = 0; i < 10; i++)
            {
                MonstersPrefab[i] = M_Level_0[i];
            }
            return;
        }

        if (LC.Level == 1)
        {
            for (int i = 0; i < 10; i++)
            {
                MonstersPrefab[i] = M_Level_1[i];
            }
            return;
        }

        if (LC.Level == 2)
        {
            for (int i = 0; i < 10; i++)
            {
                MonstersPrefab[i] = M_Level_2[i];
            }
            return;
        }

        if (LC.Level == 3)
        {
            for (int i = 0; i < 10; i++)
            {
                MonstersPrefab[i] = M_Level_3[i];
            }
            return;
        }

        if (LC.Level == 4)
        {
            for (int i = 0; i < 10; i++)
            {
                MonstersPrefab[i] = M_Level_4[i];
            }
            return;
        }

        if (LC.Level == 5)
        {
            for (int i = 0; i < 10; i++)
            {
                MonstersPrefab[i] = M_Level_5[i];
            }
            return;
        }



    }

    private void Start()
    {
        P = this;
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
                    if(LC.P1_inRoom)
                    {
                        ID_Player1Target = Random.Range(0, 9);
                        P1_TargetElement = ID_Player1Target;
                        int ID_Icon1 = MonstersPrefab[ID_Player1Target].GetComponent<EnemyStats>().E_ID;
                        ID_Player1Target = ID_Icon1;

                        P1_Total = Random.Range(3, 10);

                        PUI.SetTargetWave(true, true, ID_Icon1, 0, P1_Total,0);
                        Debug.Log("Target Solo Player 1");
                    }

                    if (LC.P2_inRoom)
                    {
                        ID_Player2Target = Random.Range(0, 9);
                        P2_TargetElement = ID_Player2Target;
                        int ID_Icon2 = MonstersPrefab[ID_Player2Target].GetComponent<EnemyStats>().E_ID;
                        ID_Player2Target = ID_Icon2;

                        P2_Total = Random.Range(3, 10);

                        PUI.SetTargetWave(true, false, 0, ID_Icon2,0,P2_Total);
                        Debug.Log("Target Solo Player 2");
                    }
                }
                else
                {
                    ID_Player1Target = Random.Range(0, 9);
                    ID_Player2Target = Random.Range(0, 9);

                    P1_TargetElement = ID_Player1Target;
                    P2_TargetElement = ID_Player2Target;

                    int ID_Icon1 = MonstersPrefab[ID_Player1Target].GetComponent<EnemyStats>().E_ID;
                    int ID_Icon2 = MonstersPrefab[ID_Player2Target].GetComponent<EnemyStats>().E_ID;

                    ID_Player1Target = ID_Icon1;
                    ID_Player2Target = ID_Icon2;

                    P1_Total = Random.Range(3, 10);
                    P2_Total = Random.Range(3, 10);

                    PUI.SetTargetWave(false, true, ID_Icon1, ID_Icon2, P1_Total,P2_Total);
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
            int randomMonster = Random.Range(0, 9);

            if (AllTargetEnemy)
            {
                randomMonster = EnemyIDforTarget;
            }

            GameObject Enemy = Instantiate(MonstersPrefab[randomMonster], SpawnControl.ListSpawn[randomLocal].position, SpawnControl.ListSpawn[randomLocal].rotation);
            Enemy.GetComponent<EnemyStats>().P_default = P;
            Enemy.GetComponent<EnemyPatrol>().SC_inRoom = SC_spawn;
            Enemy.transform.parent = parentSpawn;

            if (Target_Wave)
            {
                TargetAllEnemy1[CountAllEnemy1] = Enemy;
                CountAllEnemy1++; 
            }

            if (Protect)
            {
               EnemyStats enemyRef = Enemy.GetComponent<EnemyStats>();

                enemyRef.PlayerTarget = OnPlayer;
                
                enemyRef.LC = LC;
                enemyRef.InTarget = true;

                EnemyPatrol enemyPatrol = Enemy.GetComponent<EnemyPatrol>();
                enemyPatrol.OnAttack = true;
                enemyPatrol.moveLocal = OnPlayer;
                enemyPatrol.playerTemp = OnPlayer;
            }

            if (Peace)
            {
                if (CountPeaceList <= 250)
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

                    if (Protect)
                    {
                        Protect = false;
                        CancelInvoke("OrdaRepeatWave");

                        Debug.Log("Protect Terminou!");
                    }
                    RoomControl.ReWaveContest(ReWave_Door); //Wave Surprise vai encerrar - Surprise
                    return;
                }

                

                Debug.Log("Complete Waves");
                CancelInvoke("OrdaRepeatWave");

                PUI.Mission_SetWave(true);
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
                PUI.SetTargetPoints(true, Player1_enemyCount);
                if(Player1_enemyCount >= P1_Total)
                {
                    Debug.Log("P1 Finalizou!");
                    PUI.SetTargetwinner(true);
                    Player1_Finish = true;
                    TargetFinished();
                }
            }

            if (PlayerToDestroy == 2 && EnemyID == ID_Player2Target && !Player2_Finish)//Player2
            {
                Player2_enemyCount++;
                PUI.SetTargetPoints(false, Player2_enemyCount);
                if (Player2_enemyCount >= P2_Total)
                {
                    Debug.Log("P2 Finalizou!");
                    PUI.SetTargetwinner(false);
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

        RM.VolumeOff();

        if (player1 != null)
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

            return;
        }

        if (Type >= 6 && Type <= 10) //Wave Surpresa
        {
            Debug.Log("Suprise Wave");
            PUI.Mission_SetSurprise(false);

            Normal_Wave = false;
            Orda_Wave = false;
            Multiple_Wave = true;

            PUI.SetSurprise();
            Invoke("GoToSpawn", TimerToSpawn);
            Invoke("ReMusic", 3);
            return;
        }

        if (Type >= 11 && Type <= 15)//Rescue
        {
            Debug.Log("Rescue!");
            PUI.Mission_SetSurprise(false);

            Rescue = true;

            if (LC.SoloPlayer)
            {
                if (LC.P1_inRoom)
                {
                    player1.playerMovement.ToMove = true;
                    player1.playerWeapon.enabled = false;

                    GameObject R = Instantiate(Raiz, player1.Rescue_Object.position, player1.Rescue_Object.rotation) as GameObject;
                    player1.SA = R.GetComponent<SurpriseAttack>();

                    
                    SetRaiz = R;

                    player1.SA.Player1 = true;
                    player1.SA.PD = P;
                    
                    player1.SA.SetSoloPlayer(player1.Gatilho);
                    R.transform.parent = player1.Rescue_Object;
                    Debug.Log("Player 1 foi sequestrado!");

                }

                if (LC.P2_inRoom)
                {
                    player2.playerMovement.ToMove = true;
                    player2.playerWeapon.enabled = false;

                    GameObject R = Instantiate(Raiz, player2.Rescue_Object.position, player2.Rescue_Object.rotation) as GameObject;
                    player2.SA = R.GetComponent<SurpriseAttack>();
                    SetRaiz = R;

                    player2.SA.Player2 = true;
                    player2.SA.PD = P;
                    
                    player2.SA.SetSoloPlayer(player2.Gatilho);

                    R.transform.parent = player2.Rescue_Object;
                    Debug.Log("Player 2 foi sequestrado!");
                }

            }
            else
            {

                int SelectPlayer = Random.Range(1, 100);
                if (SelectPlayer <= 50)
                {
                    player1.playerMovement.ToMove = true;
                    player1.playerWeapon.enabled = false;

                    GameObject R = Instantiate(Raiz, player1.Rescue_Object.position, player1.Rescue_Object.rotation) as GameObject;
                    
                    player1.SA = R.GetComponent<SurpriseAttack>();
                    player2.SA = R.GetComponent<SurpriseAttack>();
                    SetRaiz = R;

                    player1.SA.Player1 = true;
                    player1.SA.PD = P;

                    R.transform.parent = player1.Rescue_Object;
                    Debug.Log("Player 1 foi sequestrado!");

                    DUB_Ed.SetSequestro();
                }
                if (SelectPlayer >= 51)
                {
                    player2.playerMovement.ToMove = true;
                    player2.playerWeapon.enabled = false;

                    GameObject R = Instantiate(Raiz, player2.Rescue_Object.position, player2.Rescue_Object.rotation) as GameObject;
                    
                    player1.SA = R.GetComponent<SurpriseAttack>();
                    player2.SA = R.GetComponent<SurpriseAttack>();
                    SetRaiz = R;

                    player2.SA.Player2 = true;
                    player2.SA.PD = P;

                    R.transform.parent = player2.Rescue_Object;
                    Debug.Log("Player 2 foi sequestrado!");

                    DUB_Nix.SetSequestro();
                }
            }

            Normal_Wave = false;
            Orda_Wave = false;
            Multiple_Wave = true;

            PUI.SetRescue();
            Invoke("GoToSpawn", TimerToSpawn);
            Invoke("ReMusic", 3);
            return;

        }

        if (Type >= 16 && Type <= 20)//Protect/Target
        {
            Debug.Log("Protect! Target Wave.");
            PUI.Mission_SetSurprise(false);

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

                    PUI.SetProtect(1,LC.Player1Color);
                }

                if (LC.P2_inRoom)
                {
                    OnPlayer = player2.transform;
                    Debug.Log("Player 2 é o Alvo!");

                    PUI.SetProtect(2, LC.Player2Color);
                }
            }
            else
            {
                int SelectPlayer = Random.Range(1, 100);
                if (SelectPlayer <= 50)
                {
                    OnPlayer = player1.transform;
                    Debug.Log("Player 1 é o Alvo!");

                    PUI.SetProtect(1, LC.Player1Color);
                }
                if (SelectPlayer >= 51)
                {
                    OnPlayer = player2.transform;
                    Debug.Log("Player 2 é o Alvo!");

                    PUI.SetProtect(2, LC.Player2Color);
                }
            }

            InvokeRepeating("OrdaRepeatWave", Orda_TimeToSpawn, Orda_RepeatWave);
            Invoke("ReMusic", 3);
            return;
        }

        if (Type >= 21 && Type <= 25)//Peace 
        {
            Debug.Log("Peace Wave!");
            PUI.Mission_SetSurprise(false);

            Peace = true;

            Normal_Wave = false;
            Multiple_Wave = false;
            Orda_Wave = true;

            TimeToSurviveInPeace = 30f;
            OnPeace.GetComponent<PeaceCounter>().PD = P;

            PUI.SetOnPeace();
            InvokeRepeating("OrdaRepeatWave", Orda_TimeToSpawn, Orda_RepeatWave);
            Invoke("ReMusic", 3);
            return;
        }

        if (Type >= 26 && Type <= 30)//Roulete
        {
            Debug.Log("All Enemys!");
            PUI.Mission_SetSurprise(false);

            AllTargetEnemy = true;

            Normal_Wave = false;
            Orda_Wave = false;
            Multiple_Wave = true;

            int EnemyChoice = Random.Range(0, 9);
            int SetEnemyIcon = MonstersPrefab[EnemyChoice].GetComponent<EnemyStats>().E_ID;

            PUI.SetRoulette(SetEnemyIcon);
            EnemyIDforTarget = EnemyChoice;
            Invoke("GoToSpawn", TimerToSpawn);

            Invoke("ReMusic", 3);
            return;

        }

    }

    void ReMusic()
    {
        RM.StartMusicInRoom();
    }

    void PeaceOtherSpawn()
    {
        if (CountPeaceList >= 20)// << é preciso mudar esse valor alguma hora
        {
            Debug.Log("Esse é o maximo!");
            return;
        }

        TimeToSurviveInPeace += 3;

        Debug.Log("Droparam +2!");
        for (int i = 0; i <= 1; i++)//Dropam +2 a cada morte
        {
            int RandomLocalNumber = SpawnControl.Acionados - 1;
            int randomLocal = Random.Range(0, RandomLocalNumber);
            int randomMonster = Random.Range(0, 12);

            GameObject Enemy = Instantiate(MonstersPrefab[randomMonster], SpawnControl.ListSpawn[randomLocal].position, SpawnControl.ListSpawn[randomLocal].rotation);
            Enemy.GetComponent<EnemyStats>().P_default = P;
            Enemy.GetComponent<EnemyPatrol>().SC_inRoom = SC_spawn;
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

        GameObject Enemy1 = Instantiate(MonstersPrefab[P1_TargetElement], SpawnControl.ListSpawn[randomLocal].position, SpawnControl.ListSpawn[randomLocal].rotation);
        Enemy1.GetComponent<EnemyStats>().P_default = P;
        Enemy1.GetComponent<EnemyPatrol>().SC_inRoom = SC_spawn;
        Enemy1.transform.parent = parentSpawn;

        TargetAllEnemy2[CountAllEnemy2] = Enemy1;
        CountAllEnemy2++;

        randomLocal = Random.Range(0, RandomLocalNumber);

        GameObject Enemy2 = Instantiate(MonstersPrefab[P2_TargetElement], SpawnControl.ListSpawn[randomLocal].position, SpawnControl.ListSpawn[randomLocal].rotation);
        Enemy2.GetComponent<EnemyStats>().P_default = P;
        Enemy2.GetComponent<EnemyPatrol>().SC_inRoom = SC_spawn;
        Enemy2.transform.parent = parentSpawn;

        TargetAllEnemy2[CountAllEnemy2] = Enemy2;
        CountAllEnemy2++;



    }

    public void TargetFinished()
    {

       if(Player1_Finish && Player2_Finish)
        {
            Debug.Log("Target concluido!");
            TargetFinish = true;
            CancelInvoke("OrdaRepeatWave");
            CancelInvoke("GoToSpawn");
            TargetDestroyAllEnemies();
            return;
        }

        if (LC.SoloPlayer)
        {
            if (Player1_Finish && !LC.P1_dead)
            {
                Debug.Log("P1 - Target concluido sozinho!");
                TargetFinish = true;
                CancelInvoke("OrdaRepeatWave");
                CancelInvoke("GoToSpawn");
                TargetDestroyAllEnemies();
                return;
            }

            if (Player2_Finish && !LC.P2_dead)
            {
                Debug.Log("P2 - Target concluido sozinho!");
                TargetFinish = true;
                CancelInvoke("OrdaRepeatWave");
                CancelInvoke("GoToSpawn");
                TargetDestroyAllEnemies();
                return;
            }
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
        PUI.Mission_SetWave(true);

        RoomControl.CompleteRoom(0);

    }

    public void RescueComplete()
    {
        Rescue = false;

        if(player1 != null)
        {
            player1.playerMovement.ToMove = false;
            player1.playerWeapon.enabled = true;
            RescueSetRaiz();
        }

        if(player2 != null)
        {
            player2.playerMovement.ToMove = false;
            player2.playerWeapon.enabled = true;
            RescueSetRaiz();
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

    public void RescueSetRaiz()
    {
        SetRaiz.transform.parent = null;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player" && !StartingWave)
        {

            StartingWave = true;
            if (Orda_Wave)
            {
                Debug.Log("Musica Começou");
                RM.StartMusicInRoom();

                Invoke("SetMissions", 2);
                InvokeRepeating("OrdaRepeatWave", Orda_TimeToSpawn, Orda_RepeatWave);

            }
            else
            {
                RM.StartMusicInRoom();
                

                Invoke("SetMissions", 2);
                Invoke("GoToSpawn", TimerToSpawn);
            }

            triggerPlayers.enabled = false;

            if (LC.P1_inRoom)
            {
                Invoke("DUB_ed_Start", 5);
            }


            if (LC.P2_inRoom)
            {
                Invoke("DUB_nix_Start", 1);
            }

        }
    }

    void DUB_ed_Start()
    {
        DUB_Ed.SetInicio();
    }

    void DUB_nix_Start()
    {
        DUB_Nix.SetInicio();
    }

    void SetMissions()
    {
        PUI.Mission_SetDoor(false);
        PUI.Mission_SetWave(false);

    }

    public void SetDoorComplete()
    {
        GetDoorEnabled.SetCompleteDoor();
    }

}
