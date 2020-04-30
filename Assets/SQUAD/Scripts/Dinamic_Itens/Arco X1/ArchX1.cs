using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchX1 : MonoBehaviour
{
    public int PlayerArch;
    public KeyCode Gatilho;
    float countToShoting;
    public float frameRate;

    public GameObject Shot;
    public Transform SpawnShot;
    public float Force = 1200;
    public ArchController AC;

    public Porta_Default P;

    private void FixedUpdate()
    {
        countToShoting += 0.1f;
        if (Input.GetKeyDown(Gatilho) && countToShoting >= frameRate)
        {
            countToShoting = 0f;
            GameObject bullet = Instantiate(Shot, SpawnShot.transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * Force);

            if(PlayerArch == 1)
            {
                bullet.GetComponent<Hit>().PlayerDestroy = true;
            }

            if (PlayerArch == 2)
            {
                bullet.GetComponent<Hit>().PlayerDestroy = false;
            }
            
            ArchShot temp = bullet.GetComponent<ArchShot>();
            temp.ID = PlayerArch;
            temp.AC = AC;
            temp.PD = P;

            
             
        }
    }


}
