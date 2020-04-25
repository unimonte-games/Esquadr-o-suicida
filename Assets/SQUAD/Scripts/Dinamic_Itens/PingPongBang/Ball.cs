using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public PingPongBang PPB;
    public KeyCode p1;
    public KeyCode p2;
    public Transform P1_ref;
    public Transform P2_ref;
    public Transform Atual;
    bool P1_area;
    bool P2_area;
    public float speed = 5;
    public int MaxCount;

    public bool PlayerDestroy;
  

    private void Start()
    {
        Invoke("CancelThis", MaxCount);

        P1_ref.GetComponent<Player>().playerWeapon.DisabledItem();
        P2_ref.GetComponent<Player>().playerWeapon.DisabledItem();

        P1_ref.GetComponent<Player>().UsingItenDinamic = true;
        P2_ref.GetComponent<Player>().UsingItenDinamic = true;
    }

    void FixedUpdate()
    {

        if (Input.GetKeyDown(p1) && P1_area)
        {
            PlayerDestroy = true;

            Atual = P2_ref;    
        }

        if (Input.GetKeyDown(p2) && P2_area)
        {
            PlayerDestroy = false;

            Atual = P1_ref;
        }

        transform.LookAt(Atual.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        if (Vector3.Distance(transform.position, Atual.position) > 1f)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }

    }

    public void CancelThis()
    {
        
        P1_ref.GetComponent<Player>().UsingItenDinamic = false;
        P2_ref.GetComponent<Player>().UsingItenDinamic = false;

        P1_ref.GetComponent<Player>().playerWeapon.EnabledItem();
        P2_ref.GetComponent<Player>().playerWeapon.EnabledItem();

        PPB.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1" && !P1_area) //para pegar
        {
            P1_area = true;
            return;
        }

        if (other.gameObject.name == "Player2" && !P2_area)
        {
            P2_area = true;
            return;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1")
        {
            P1_area = false;
            return;
        }

        if (other.gameObject.name == "Player2")
        {
            P2_area = false;
            return;
        }
    }
}
