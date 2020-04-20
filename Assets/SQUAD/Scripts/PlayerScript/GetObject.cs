using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObject : MonoBehaviour
{
    public Player P;
    GetObject Gobj;

    private void Start()
    {
        Gobj = GetComponent<GetObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1")
        {
            P = other.GetComponent<Player>();

            P.Object = this.gameObject;
            P.ObjectInArea = true;
            P.Gobj = Gobj;
            return;
        }

        if (other.gameObject.name == "Player2")
        {
            P = other.GetComponent<Player>();

            P.Object = this.gameObject;
            P.ObjectInArea = true;
            P.Gobj = Gobj;
            return;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.name == "Player1")
        {  
            P.ObjectInArea = false;
            P.Object = null;
            return;
        }

        if (other.gameObject.name == "Player2")
        {
            P.ObjectInArea = false;
            P.Object = null;
            return;
        }
    }

    public void Get ()
    {
        this.gameObject.transform.position = P.ObjSpawn.position;
        this.gameObject.transform.parent = P.ObjSpawn;
    }
}
