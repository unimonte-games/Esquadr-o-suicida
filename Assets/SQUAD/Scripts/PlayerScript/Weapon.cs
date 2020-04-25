using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int weaponID;

    public GameObject Shot;
    public int Fire;
    public float FrameRate;
    public int Mana;
    public float Range;
    public int Nivel;

    public float Force;

    public KeyCode Gatilho;
    float countToShoting;

    public Transform spawnShot;
    public Player P;

    private void FixedUpdate()
    {
        countToShoting += 0.1f;
        if (Input.GetKeyDown(Gatilho) && countToShoting >= FrameRate)
        {
            countToShoting = 0f;
            GameObject bullet = Instantiate(Shot, spawnShot.transform.position, Quaternion.identity) as GameObject;
            Destroy HitEnemy = bullet.GetComponent<Destroy>();

            HitEnemy.PlayerDestroy = P.PlayerType;
            HitEnemy.time = Range;
            HitEnemy.Hit = Fire;
            P.ManaBar -= Mana;

            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * Force);
        }

    }

}
