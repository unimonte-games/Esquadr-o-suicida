using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
   
    public int gold;
    [Range(1,5)]
    public int Min;
    [Range(1, 25)]
    public int Max;

    Player P;
    public MagnetSystem MS;

    private void Start()
    {
        gold = Random.Range(Min, Max);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player1")
        {
            P = other.GetComponent<Player>();

            P.Ouro += gold;
            MS.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }

        if (other.gameObject.name == "Player2")
        {
            P = other.GetComponent<Player>();

            P.Ouro += gold;
            MS.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
