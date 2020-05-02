using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public int speed_min;
    public int speed_max;

    public int speed;
    public float waitTime;
    public float startWaitTime;
    public float DistanceToPlayer;

    public float speedTurn;
    bool InLocal;
    bool ToMove;
    
    public int timeToTurn;

    int SpawnToMove;
    public SpawnController SC_inRoom;

    public Transform moveLocal;

    EnemyStats ES;

    private void Awake()
    {
        ES = GetComponent<EnemyStats>();
    }

    void Start()
    {
        speed = Random.Range(speed_min, speed_max);
        SpawnToMove = SC_inRoom.Acionados;

        int nextLocal = Random.Range(0, SpawnToMove);
        moveLocal = SC_inRoom.ListSpawn[nextLocal];

        startWaitTime = Random.Range(0, 5);
        waitTime = startWaitTime;

    }

    void FixedUpdate()
    {
        if (ES.Patrol)
        {
            if (!InLocal)
            {
                Vector3 dirFromMeToTarget = moveLocal.position - transform.position;
                dirFromMeToTarget.y = 0f;

                Quaternion lookRotation = Quaternion.LookRotation(dirFromMeToTarget);

                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * (speedTurn / 360.0f));
            }

            if (!ToMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, moveLocal.position, speed * Time.deltaTime);
            }

            if (Vector3.Distance(transform.position, moveLocal.position) < 1f)
            {
                if (waitTime <= 0)
                {
                    int nextLocal = Random.Range(0, SpawnToMove);
                    moveLocal = SC_inRoom.ListSpawn[nextLocal];

                    startWaitTime = Random.Range(0, 5);
                    waitTime = startWaitTime;
                    InLocal = false;

                    ToMove = true;
                    Invoke("WaitToRotation", timeToTurn);
                }
                else
                {
                    InLocal = true;
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }

    void WaitToRotation()
    {
        ToMove = false;
    }

    void WaitToRotationInObj()
    {
        ToMove = false;
        transform.LookAt(moveLocal);
    }

    public void ObjectHit()
    {
        int nextLocal = Random.Range(0, SpawnToMove);
        moveLocal = SC_inRoom.ListSpawn[nextLocal];

        startWaitTime = Random.Range(2, 5);
        waitTime = startWaitTime;

        ToMove = true;
        Invoke("WaitToRotationInObj", 2f);
    }

    public void EnemyHit(int timeToRotation)
    {
        ToMove = true;

        int nextLocal = Random.Range(0, SpawnToMove);
        moveLocal = SC_inRoom.ListSpawn[nextLocal];

        startWaitTime = Random.Range(2, 5);
        waitTime = startWaitTime;

       
        Invoke("WaitToRotationInObj", timeToRotation);
    }

    public void ChangeSpeed()
    {
        speed = Random.Range(speed_min, speed_max);
        Debug.Log("Speed: " + speed);
    }

}
