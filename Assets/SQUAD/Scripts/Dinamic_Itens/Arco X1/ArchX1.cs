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
  
    private void FixedUpdate()
    {
        countToShoting += 0.1f;
        if (Input.GetKeyDown(Gatilho) && countToShoting >= frameRate)
        {
            countToShoting = 0f;
            GameObject bullet = Instantiate(Shot, SpawnShot.transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * Force);

            ArchShot temp = bullet.GetComponent<ArchShot>();
            temp.ID = PlayerArch;
            temp.AC = AC;
             
        }
    }


}
