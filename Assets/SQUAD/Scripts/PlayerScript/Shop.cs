using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    WeaponList WL;
    public Transform[] Spawn;
    public int randomItem_min;
    public int randomItem_max;


    void Start()
    {
        WL = FindObjectOfType<WeaponList>();

        for (int i = 0; i < 3; i++)
        {
            int randomItem = Random.Range(randomItem_min, randomItem_max);
            Debug.Log("Item: " + randomItem + " no Shop");
            GameObject Item = Instantiate(WL.wItem[randomItem], Spawn[i].position, Spawn[i].rotation);
            Item.GetComponent<Item>().isBuy = true;
            Item.transform.parent = Spawn[i];
        }
    }
}
