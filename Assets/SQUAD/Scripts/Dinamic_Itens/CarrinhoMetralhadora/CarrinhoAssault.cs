using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrinhoAssault : MonoBehaviour
{
    public KeyCode Assault_Gatilho;
    public KeyCode Assault_Up;
    public KeyCode Assault_Down;
    public KeyCode Assault_Left;
    public KeyCode Assault_Right;

    public Transform spawn;
    public GameObject shotingPrefab;
    float countToShoting;
    public float frameRate;
    public float Force;
    public CarrinhoMetralhadora CM;

    public bool PlayerThis;

    private void FixedUpdate()
    {
        if (CM.P1ready && CM.P2ready)
        {

            countToShoting += 0.1f;
            if (Input.GetKeyDown(Assault_Gatilho) && countToShoting >= frameRate)
            {
                countToShoting = 0f;
                GameObject bullet = Instantiate(shotingPrefab, spawn.transform.position, Quaternion.identity) as GameObject;
                bullet.GetComponent<Hit>().PlayerDestroy = PlayerThis;
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * Force);

            }


        }
    }
}
