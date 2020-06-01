using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public int E_ID; //Id do inimigo
    public bool Type; //True = Tech | False = Plant
    public bool DontSlow;

    public float Life_Atual;
    public float L_Max;
    public float Life_min;
    public float Life_max;
    public int Experience;
    public bool isDead;
    public GameObject EE;
    public GameObject EX;

    public Image life_barInterface;
    public GameObject Life_bar;
    public GameObject HitDamage;
    public Transform spawnDamage;

    public GameObject AttackArea;

    public GameObject Body;
    public GameObject BodyEffect;

    public Transform PlayerTarget;
    public bool PlayerInArea;

    public bool Player1_inArea;
    public bool Player2_inArea;

    public bool InTarget;
    public LevelController LC;
    public Porta_Default P_default;
    public GameObject EnergyCoin;

    [Range(30, 100)]
    public int Gold_rare;
    bool Drop;
    int tempRandom;
    int QtdEnergy;
    public Transform RoomSize;
    Vector3 center;
    Vector3 size;

    public EnemyPatrol EP;

    public bool PlantaCanina;
    public GameObject EnergyDamage;

    public bool Cafeteira;
    public bool RoboElite;
    public Enemy7_Attack E7;

    public bool Golem;
    public GameObject[] ItemSecreto;

    public float SizeLife;
    bool S;

    public Animator Anin;
    public Rigidbody rb;
    public int TimeToDestroyThis;

    BoxCollider BC;
    public ImpactEffect IE;
    public bool OnImpact;
    public float ImpactTime;
    public int ImpactID;


    private void Start()
    {
        
        if (InTarget && PlantaCanina)
        {
            InTarget = false;
            OnPatrol();
            Debug.Log("Cancelando ao iniciar o Target");
        }

        LC = FindObjectOfType<LevelController>();

        Life_Atual = Random.Range(Life_min, Life_max);
        L_Max = Life_Atual;

        if (Cafeteira)
        {
            SizeLife = Life_Atual / 2;
        }

        if (OnImpact)
        {
            IE = FindObjectOfType<ImpactEffect>();

        }



        Invoke("StartEnemy", 1);
    }

    void StartEnemy()
    {

        BodyEffect.SetActive(false);
        Body.SetActive(true);
   
    }

    private void Awake()
    {
        EP = GetComponent<EnemyPatrol>();
        rb = GetComponent<Rigidbody>();
        BC = GetComponent<BoxCollider>(); 

        Body.SetActive(false);
        BodyEffect.SetActive(true);

        tempRandom = Random.Range(0, 100);
        if (tempRandom > Gold_rare)
        {
            Drop = true;

            if (Drop)
            {

                if (tempRandom >= 30 && tempRandom <= 60)
                {
                    int quantidadeRandom = Random.Range(1, 2);
                    QtdEnergy = quantidadeRandom;
                    return;
                }

                if (tempRandom >= 61 && tempRandom <= 70)
                {
                    int quantidadeRandom = Random.Range(1, 4);
                    QtdEnergy = quantidadeRandom;
                    return;
                }

                if (tempRandom >= 71 && tempRandom <= 80)
                {
                    int quantidadeRandom = Random.Range(2, 6);
                    QtdEnergy = quantidadeRandom;
                    return;
                }

                if (tempRandom >= 81 && tempRandom <= 90)
                {
                    int quantidadeRandom = Random.Range(3, 7);
                    QtdEnergy = quantidadeRandom;
                    return;
                }

                if (tempRandom >= 91 && tempRandom <= 99)
                {
                    int quantidadeRandom = Random.Range(4, 10);
                    QtdEnergy = quantidadeRandom;
                    return;
                }

                if (tempRandom >= 100)
                {
                    int quantidadeRandom = Random.Range(10, 30);
                    QtdEnergy = quantidadeRandom;

                    Debug.Log("Muita Sorte!");
                    return;
                }


            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hit" && !isDead)
        {
            Hit h = other.GetComponent<Hit>();

            if (Type)
            {
                Life_Atual -= h.Hit_Tech;
                GameObject hit = Instantiate(HitDamage, spawnDamage.position, spawnDamage.rotation) as GameObject;
                hit.GetComponent<EnemyUIHit>().danoHit = h.Hit_Tech;
                hit.transform.parent = transform;

                if (h.isSlow && !DontSlow)
                {
                    EP.SlowInEnemy();
                }

                TakeHit();
                if (!h.DontDestroy)
                {
                    other.gameObject.SetActive(false);
                }

            }
            else
            {
                Life_Atual -= h.Hit_Plant;
                GameObject hit = Instantiate(HitDamage, spawnDamage.position, spawnDamage.rotation) as GameObject;
                hit.GetComponent<EnemyUIHit>().danoHit = h.Hit_Plant;
                hit.transform.parent = transform;


                if (h.isSlow && !DontSlow)
                {
                    EP.SlowInEnemy();
                }

                TakeHit();
                if (!h.DontDestroy)
                {
                    other.gameObject.SetActive(false);
                }
                

            }

            if (Life_Atual <= 0)
            {
                TakeHit();
                if (OnImpact)
                {
                    IE.Impact(ImpactTime, ImpactID);
                }

                isDead = true;

                BC.enabled = false;
                EP.enabled = false;
                EE.SetActive(false);
                EX.SetActive(false);

                AttackArea.SetActive(false);
                rb.constraints = RigidbodyConstraints.FreezeAll;

                if (h.PlayerDestroy)
                {
                    P_default.MonstersDefeat(1, E_ID);
                    P_default.player1.SetLevel(Experience);
                    Dead();
                    return;
                }
                else
                {
                    P_default.MonstersDefeat(2, E_ID);
                    P_default.player2.SetLevel(Experience);
                    Dead();
                    return;
                }

            }

        }


    }

    void TakeHit()
    {
        float Life_Cal = Life_Atual / L_Max;
        life_barInterface.fillAmount = Life_Cal;

        Life_bar.SetActive(true);
        Invoke("CancelInterface", 1);

        if (Cafeteira && Life_Atual <= SizeLife && !S)
        {
            S = true;
            
            EP.CafeteiraChangeSpeed();

            Debug.Log("Cafeteira ao Ataque!");
        }
    }

    public void TakeEnergy(int Add)
    {
        float Life_Cal = Life_Atual / L_Max;
        life_barInterface.fillAmount = Life_Cal;

        Life_bar.SetActive(true);
        Invoke("CancelInterface", 1);

        GameObject hit = Instantiate(EnergyDamage, spawnDamage.position, spawnDamage.rotation) as GameObject;
        hit.GetComponent<EnemyUIHit>().danoHit = Add;
        hit.transform.parent = transform;
    }

    void CancelInterface()
    {
        Life_bar.SetActive(false);
    }

    void Dead()
    {
        A_Die();

        center.x = RoomSize.transform.position.x;
        center.y = RoomSize.transform.position.y;
        center.z = RoomSize.transform.position.z;

        size.x = RoomSize.transform.localScale.x;
        size.z = RoomSize.transform.localScale.z;

        if (Drop)
        {
            for (int i = 0; i < QtdEnergy; i++)
            {
                Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 1, Random.Range(-size.z / 2, size.z / 2));
                GameObject SpawnP = Instantiate(EnergyCoin, pos, Quaternion.identity);

            }
        }

        if (RoboElite)
        {
            Invoke("BombInRobot", 4);
            return;
        }

        if (Golem)
        {
            int Rare = Random.Range(0, 100);
            if (Rare > 95)
            {
                int IS = Random.Range(0, 4);
                Instantiate(ItemSecreto[IS], transform.position, transform.rotation);
                Debug.Log("Item Secreto!");
            }
        }

        this.enabled = false;
        Invoke("DestroyThis", TimeToDestroyThis);
        
    }

    void DestroyThis()
    {
        this.gameObject.SetActive(false);
    }

    public void OnAttack()
    {
        if (PlantaCanina)
        {
            EP.OnAttack = true;
            AttackArea.SetActive(true);
            return;
        }

        if (InTarget)
        {
            Change();

        }

        EP.OnAttack = true;
        EP.moveLocal = PlayerTarget;
        EP.playerTemp = PlayerTarget;
        AttackArea.SetActive(true);
    }

    public void OnPatrol()
    {
        if (InTarget)
        {
            Debug.Log("Player fixo, continuar seguindo.");
            return;
        }

        EP.OnAttack = false;
        AttackArea.SetActive(false);
        EP.ObjectHit();

    }

    public void Change()
    {
        if (LC.SoloPlayer && LC.P1_dead || LC.P2_dead)
        {

            PlayerTarget = P_default.OnPlayer;
            EP.moveLocal = P_default.OnPlayer;
            EP.playerTemp = P_default.OnPlayer;

            Debug.Log("Change Target!");

        }

        if (LC.P1_dead && LC.P2_dead)
        {
            InTarget = false;
            OnPatrol();
        }
    }

    public void A_Attack()
    {
        Anin.SetTrigger("isAttack");
    }

    public void A_AttackExtra()
    {
        Anin.SetTrigger("isAttackExtra");
    }

    public void A_Die()
    {
        Anin.SetTrigger("isDie");
    }

    void BombInRobot()
    {
        E7.Bomb();

        this.enabled = false;
        Invoke("DestroyThis", TimeToDestroyThis);
    }


}

