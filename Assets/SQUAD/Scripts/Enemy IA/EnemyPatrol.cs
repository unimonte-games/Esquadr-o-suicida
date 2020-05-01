using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public float startWaitTime;

    public Transform moveLocal;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    void Start()
    {
        waitTime = startWaitTime;

        moveLocal.position = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveLocal.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, moveLocal.position) < 0.2f)
        {
            if(waitTime <= 0)
            {
               
                moveLocal.position = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
