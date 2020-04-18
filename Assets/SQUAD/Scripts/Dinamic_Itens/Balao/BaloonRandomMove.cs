using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonRandomMove : MonoBehaviour
{
    public SpawnController SC;
    public Transform[] ListToMove;

    public Transform Atual;

    public bool Using;
    bool change;
    int changeTime;

    public float speed;

    private void FixedUpdate()
    {
        if (Using)
        {
            if (!change)
            {
                change = true;
                Invoke("ChangeDirection", changeTime);
            }

            transform.LookAt(Atual.position);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);

            if (Vector3.Distance(transform.position, Atual.position) > 1f)
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }

            if (Vector3.Distance(transform.position, Atual.position) <= 1f)
            {
                Debug.Log("Chegou perto, troca");
                CancelInvoke("ChangeDirection");
                ChangeDirection();
            }
        }
    }

    void ChangeDirection()
    {
        changeTime = Random.Range(5, 12);
        int NumberToList = Random.Range(0, SC.Acionados);
        Atual = ListToMove[NumberToList];

        change = false;
    }

    public void StartBaloon()
    {
        for (int i = 0; i <= SC.Acionados; i++)
        {
            ListToMove[i] = SC.ListSpawn[i];
        }

        ChangeDirection();
        
        Debug.Log("Lista Organizada");
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            Debug.Log("Objeto!");
            CancelInvoke("ChangeDirection");
            ChangeDirection();
        }
    }

}
