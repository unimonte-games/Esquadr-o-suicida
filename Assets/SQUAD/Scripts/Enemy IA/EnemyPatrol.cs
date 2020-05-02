using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public float startWaitTime;
    public float DistanceToPlayer;

    int SpawnToMove;
    public SpawnController SC_inRoom;

    public Transform moveLocal;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    void Start()
    {

        SpawnToMove = SC_inRoom.Acionados;

        int nextLocal = Random.Range(0, SpawnToMove);
        moveLocal = SC_inRoom.ListSpawn[nextLocal];

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

        waitTime = startWaitTime;
    }
}
