using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropKey : MonoBehaviour
{
    public int ID;
    public BoxCollider BC;
    public GameObject DefeseAtived;
    DropKey DK;

    private void Start()
    {
        DK = GetComponent<DropKey>();
    }

    public void BoxDisabled()
    {
        BC.enabled = false;
        Invoke("BoxEnabled", 2f);
    }

    public void BoxEnabled()
    {
        BC.enabled = true;
        StartCoroutine("DropHability");
    }

    IEnumerator DropHability()
    {
        Debug.Log("Discarte.");
        yield return new WaitForSeconds(3);
        BC.enabled = false;

        DefeseAtived.GetComponent<DropKeyHabiity>().DK = DK;
        DefeseAtived.SetActive(true);
       
    }

}
