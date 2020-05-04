using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public int E_ID; //Id do inimigo
    public bool Type; //True = Tech | False = Plant

    public float Life_Atual;
    public float L_Max;
    public int Life_min;
    public int Life_max;

    public Image life_barInterface;
    public GameObject Life_bar;
    public GameObject HitDamage;
    public Transform spawnDamage;

    public GameObject AttackArea;

    public Transform PlayerTarget;
    public bool PlayerInArea;

    public bool Player1_inArea;
    public bool Player2_inArea;


    public bool InTarget;
    public LevelController LC;
    public Porta_Default P_default;
    public GameObject EnergyCoin;
    bool ChangeTarget;

    bool Drop;
    int tempRandom;
    int QtdEnergy;
    public Transform RoomSize;
    Vector3 center;
    Vector3 size;

    public EnemyPatrol EP;
    
    public float SizeLife;

    private void Start()
    {
        Life_Atual = Random.Range(Life_min, Life_max);
        L_Max = Life_Atual;
    }

    private void FixedUpdate()
    {
        if (InTarget)
        {
            if (LC.SoloPlayer && LC.P1_dead || LC.P2_dead && !ChangeTarget)
            {
                PlayerTarget = P_default.OnPlayer;
                ChangeTarget = true;
            }
        }
    }

    private void Awake()
    {
        SizeLife = Life_Atual / 2;
        EP = GetComponent<EnemyPatrol>();

        tempRandom = Random.Range(0, 100);
        if (tempRandom > 80)
        {
            Drop = true;

            center.x = RoomSize.transform.position.x;
            center.y = RoomSize.transform.position.y;
            center.z = RoomSize.transform.position.z;

            size.x = RoomSize.transform.localScale.x;
            size.z = RoomSize.transform.localScale.z;


            if (Drop)
            {
                if (tempRandom >= 80 && tempRandom <= 85)
                {
                    int quantidadeRandom = Random.Range(1, 2);
                    QtdEnergy = quantidadeRandom;
                    return;
                }

                if (tempRandom >= 86 && tempRandom <= 90)
                {
                    int quantidadeRandom = Random.Range(1, 3);
                    QtdEnergy = quantidadeRandom;
                    return;
                }

                if (tempRandom >= 91 && tempRandom <= 95)
                {
                    int quantidadeRandom = Random.Range(1, 4);
                    QtdEnergy = quantidadeRandom;
                    return;
                }

                if (tempRandom >= 96 && tempRandom <= 100)
                {
                    int quantidadeRandom = Random.Range(1, 5);
                    QtdEnergy = quantidadeRandom;
                    return;
                }


            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Hit")
        {
            Hit h = other.GetComponent<Hit>();

            if (Type)
            {
                Life_Atual -= h.Hit_Tech;
                GameObject hit = Instantiate(HitDamage, spawnDamage.position, spawnDamage.rotation) as GameObject;
                hit.GetComponent<EnemyUIHit>().danoHit = h.Hit_Tech;
                hit.transform.parent = transform;
                
                TakeHit();
                other.gameObject.SetActive(false);

            }
            else
            {
                Life_Atual -= h.Hit_Plant;
                GameObject hit = Instantiate(HitDamage, spawnDamage.position, spawnDamage.rotation) as GameObject;
                hit.GetComponent<EnemyUIHit>().danoHit = h.Hit_Plant;
                hit.transform.parent = transform;

                TakeHit();
                other.gameObject.SetActive(false);

            }

            if (Life_Atual <= 0)
            {
                

                if (h.PlayerDestroy)
                {
                    P_default.MonstersDefeat(1, E_ID);
                    Dead();
                    return;
                }
                else
                {
                    P_default.MonstersDefeat(2, E_ID);
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

        if (Life_Atual == SizeLife)
        {
            EP.ChangeSpeed();
        }
        
    }

    void CancelInterface()
    {
        Life_bar.SetActive(false);
    }

    void Dead()
    {
        if (Drop)
        {
            for (int i = 0; i < QtdEnergy; i++)
            {
                Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), -4, Random.Range(-size.z / 2, size.z / 2));
                GameObject SpawnP = Instantiate(EnergyCoin, pos, Quaternion.identity);

            }
        }

        Debug.Log("Derrotado");
        this.gameObject.SetActive(false);
    }

    public void OnAttack()
    {
        EP.OnAttack = true;
        EP.moveLocal = PlayerTarget;
        EP.playerTemp = PlayerTarget;
        AttackArea.SetActive(true);
        
    }

    public void OnPatrol()
    {
        EP.OnAttack = false;
        AttackArea.SetActive(false);
        EP.ObjectHit();
        
    }
}
