using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCheck : MonoBehaviour
{
    public MapSystem MP;

    bool isCheck;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isCheck)
            {
                isCheck = true;
                MP.EndCheck();

                this.gameObject.SetActive(false);


            }
        }
    }
}
