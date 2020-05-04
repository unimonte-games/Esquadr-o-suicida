using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIHit : MonoBehaviour
{
    public int danoHit;
    public Text hit;
   
    private void Start()
    {
        hit.text = "" + danoHit;
        Invoke("Cancel",1);
        InvokeRepeating("On", 0, 0.1f);
    }

    void On()
    {
        transform.Translate(Vector3.up * 10 * Time.deltaTime);
    }

    void Cancel()
    {
        CancelInvoke("On");
        this.gameObject.SetActive(false);
    }

}
