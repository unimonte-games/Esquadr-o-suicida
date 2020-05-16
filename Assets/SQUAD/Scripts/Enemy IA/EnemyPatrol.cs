using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public bool OnAttack;
    bool InArea;

    public int speed_min;
    public int speed_max;

    public int speed;
    public float waitTime;
    public float startWaitTime;
    public float W_min;
    public float W_max;

    public float DistanceToPlayer;

    public int Dis_Min;
    public int Dis_Max;

    public float speedTurn;
    bool InLocal;
    bool ToMove;

    public int timeToTurn;

    int SpawnToMove;
    public SpawnController SC_inRoom;

    public Transform moveLocal;
    public Transform playerTemp;

    public GameObject Body;

    EnemyStats ES;
    int tempSpeed;
    bool InSlow;


    public Animator Anin;

    private void Awake()
    {
        ES = GetComponent<EnemyStats>();
        
    }

    void Start()
    {
        Anin.SetBool("isIddle", false);
        Anin.SetBool("isWalk", true);

        speed = Random.Range(speed_min, speed_max);
        SpawnToMove = SC_inRoom.Acionados;

        int nextLocal = Random.Range(0, SpawnToMove);
        moveLocal = SC_inRoom.ListSpawn[nextLocal];

        startWaitTime = Random.Range(0, 5);
        waitTime = startWaitTime;

    }

    void FixedUpdate()
    {
        if (!InLocal)
        {
            Vector3 dirFromMeToTarget = moveLocal.position - transform.position;
            dirFromMeToTarget.y = 0f;

            Quaternion lookRotation = Quaternion.LookRotation(dirFromMeToTarget);

            Body.transform.rotation = Quaternion.Lerp(Body.transform.rotation, lookRotation, Time.deltaTime * (speedTurn / 360.0f));
        }

        if (!ToMove)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, moveLocal.position, speed * Time.deltaTime);

        }

        if (Vector3.Distance(transform.position, moveLocal.position) < 2f && !OnAttack)
        {
            if (waitTime <= 0)
            {
                int nextLocal = Random.Range(0, SpawnToMove);
                moveLocal = SC_inRoom.ListSpawn[nextLocal];

                startWaitTime = Random.Range(W_min, W_max);

                if (ES.PlantaCanina)
                {
                    startWaitTime = 1f;
                }
 
                waitTime = startWaitTime;
                InLocal = false;

                ToMove = true;

                Anin.SetBool("isIddle", true);
                Anin.SetBool("isWalk", false);

                Invoke("WaitToRotation", timeToTurn);

            }
            else
            {
                InLocal = true;
                waitTime -= Time.deltaTime;
            }
        }

        if (Vector3.Distance(transform.position, moveLocal.position) < DistanceToPlayer && OnAttack && !InArea)
        {
            InArea = true;
            ToMove = true;

            Anin.SetBool("isIddle", true);
            Anin.SetBool("isWalk", false);

        }

        if (Vector3.Distance(transform.position, moveLocal.position) > DistanceToPlayer && OnAttack)
        {
            InArea = false;
            ToMove = false;

            Anin.SetBool("isIddle", false);
            Anin.SetBool("isWalk", true);
            Body.transform.LookAt(moveLocal);

            DistanceToPlayer = Random.Range(Dis_Min, Dis_Max);

        }


    }

    void WaitToRotation()
    {
        
        ToMove = false;

        Anin.SetBool("isIddle", false);
        Anin.SetBool("isWalk", true);
    }

    void WaitToRotationInObj()
    {
        
        ToMove = false;

        Anin.SetBool("isIddle", false);
        Anin.SetBool("isWalk", true);

        Body.transform.LookAt(moveLocal);
    }

    public void ObjectHit()
    {
        if (!OnAttack)
        {
            int nextLocal = Random.Range(0, SpawnToMove);
            moveLocal = SC_inRoom.ListSpawn[nextLocal];

            startWaitTime = Random.Range(W_min, W_max);
            waitTime = startWaitTime;

            ToMove = true;

            Anin.SetBool("isIddle", true);
            Anin.SetBool("isWalk", false);

            Invoke("WaitToRotationInObj", 2f);
        }
        else
        {
            ES.AttackArea.SetActive(false);

            int nextLocal = Random.Range(0, SpawnToMove);
            moveLocal = SC_inRoom.ListSpawn[nextLocal];

            if (ES.PlantaCanina)
            {
                startWaitTime = 1f;
                waitTime = startWaitTime;

                ToMove = true;

                Anin.SetBool("isIddle", true);
                Anin.SetBool("isWalk", false);

                Invoke("WaitToRotationInObj", 2f);
                return; 
            }

            startWaitTime = Random.Range(2, 5);
            waitTime = startWaitTime;

            ToMove = true;

            Anin.SetBool("isIddle", true);
            Anin.SetBool("isWalk", false);

            StartCoroutine("ReLocal");
        }
    }

    IEnumerator ReLocal()
    {
        if (OnAttack)
        {

            ToMove = true;

            Anin.SetBool("isIddle", true);
            Anin.SetBool("isWalk", false);

            yield return new WaitForSeconds(1f);

            ToMove = false;

            Anin.SetBool("isIddle", false);
            Anin.SetBool("isWalk", true);

            ES.AttackArea.SetActive(true);
            moveLocal = playerTemp;
            Body.transform.LookAt(moveLocal);

            if (ES.InTarget)
            {
                ES.Change();
            }

            Debug.Log("Continuando a busca...");
        }
        else
        {
            Debug.Log("Muito Longe...");
            ObjectHit();
        }
    }

    public void EnemyHit(int timeToRotation)
    {
        if (!OnAttack)
        {
            ToMove = true;
            Anin.SetBool("isIddle", true);
            Anin.SetBool("isWalk", false);

            int nextLocal = Random.Range(0, SpawnToMove);
            moveLocal = SC_inRoom.ListSpawn[nextLocal];

            startWaitTime = Random.Range(W_min, W_max);
            waitTime = startWaitTime;

            Invoke("WaitToRotationInObj", timeToRotation);
        }
    }

    public void CafeteiraChangeSpeed()
    {
        speed = Random.Range(5, 6);
    }

    public void SlowInEnemy()
    {
        if (!InSlow)
        {
            InSlow = true;
            tempSpeed = speed;
            speed -= 2;
            if(speed <= 0)
            {
                speed = 1;
            }
            Invoke("CancelSlow", 3);
        }
        

    }

    void CancelSlow()
    {
        speed = tempSpeed;
        InSlow = false;
    }

}
