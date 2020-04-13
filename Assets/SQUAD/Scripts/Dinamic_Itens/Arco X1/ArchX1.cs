using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchX1 : MonoBehaviour
{
    public int PlayerArch;
    public KeyCode Gatilho;
    
    public GameObject Shot;
    public Transform SpawnShot;

    public ArchController AC;
  
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(Gatilho))
        {
            GameObject Shoting = Instantiate(Shot, SpawnShot.position, SpawnShot.rotation);
            
            ArchShot temp = Shoting.GetComponent<ArchShot>();
            temp.ID = PlayerArch;
            temp.AC = AC;
             
        }
    }


}
