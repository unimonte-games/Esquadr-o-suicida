using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform spawn;
    public GameObject shotingPrefab;
    float countToShoting;
    public float frameRate;
    public float Force;

    public KeyCode Gatilho;

    Player P;
    bool PlayerController;

    private void FixedUpdate()
    {
        countToShoting += 0.1f;
        if (Input.GetKeyDown(Gatilho) && countToShoting >= frameRate)
        {
                countToShoting = 0f;
                GameObject bullet = Instantiate(shotingPrefab, spawn.transform.position, Quaternion.identity) as GameObject;
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * Force);
        }
    }

    public void UpdateGatilhos()
    {
        P = GetComponent<Player>();

        Gatilho = P.Gatilho;

    }
}
