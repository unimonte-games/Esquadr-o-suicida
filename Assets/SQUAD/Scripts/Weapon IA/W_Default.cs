using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_Default : MonoBehaviour
{
    public int weaponID;

    public GameObject Shot;
    public int Fire_Plant;
    public int Fire_Tech;
    public float FrameRate;
    public int Mana;
    public float Range;
    public int Nivel;
    public string Name;

    public float Force;

    public KeyCode Gatilho;
    float countToShoting;

    public Transform spawnShot;
    public Player P;

    void Start()
    {
        Gatilho = P.Gatilho;
    }
    private void FixedUpdate()
    {
        countToShoting += 0.1f;
        if (Input.GetKeyDown(Gatilho) && countToShoting >= FrameRate)
        {
            countToShoting = 0f;
            GameObject bullet = Instantiate(Shot, spawnShot.transform.position, Quaternion.identity) as GameObject;
            Hit HitEnemy = bullet.GetComponent<Hit>();

            HitEnemy.PlayerDestroy = P.PlayerType;
            HitEnemy.time = Range;
            HitEnemy.Hit_Plant = Fire_Plant;
            HitEnemy.Hit_Tech = Fire_Tech;
            P.ManaBar -= Mana;

            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * Force);
        }

    }
}
