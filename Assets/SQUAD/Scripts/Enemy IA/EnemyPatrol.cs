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

    int SpawnToMove;
    public SpawnController SC_inRoom;

    public Transform moveLocal;

    void Start()
    {
        speed = Random.Range(speed_min, speed_max);
        Debug.Log("Speed: " + speed);

        SpawnToMove = SC_inRoom.Acionados;

        int nextLocal = Random.Range(0, SpawnToMove);
        moveLocal = SC_inRoom.ListSpawn[nextLocal];

        startWaitTime = Random.Range(0, 5);
        waitTime = startWaitTime;
        
    }

    
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveLocal.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, moveLocal.position) < 1f)
        {
            if(waitTime <= 0)
            {
                int nextLocal = Random.Range(0, SpawnToMove);
                moveLocal = SC_inRoom.ListSpawn[nextLocal];

                startWaitTime = Random.Range(0, 5);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    public void ObjectHit()
    {
        Debug.Log("Object");

        int nextLocal = Random.Range(0, SpawnToMove);
        moveLocal = SC_inRoom.ListSpawn[nextLocal];

        startWaitTime = Random.Range(0, 5);
        waitTime = startWaitTime;
    }

    public void ChangeSpeed()
    {
        speed = Random.Range(speed_min, speed_max);
        Debug.Log("Speed: " + speed);
    }
}
