﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObject : MonoBehaviour
{
    public Player P;
    GetObject Gobj;
    bool InArea;
    SphereCollider SC;

    private void Start()
    {
        SC = GetComponent<SphereCollider>();
        Gobj = GetComponent<GetObject>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player1" && !InArea)
        {
            InArea = true;
            P = other.GetComponent<Player>();
            
            P.Object = this.gameObject;
            P.ObjectInArea = true;
            P.Gobj = Gobj;
            return;
        }

        if (other.gameObject.name == "Player2" && !InArea)
        {
            InArea = true;
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
            InArea = false;
            P.ObjectInArea = false;
            P.Object = null;
            return;
        }

        if (other.gameObject.name == "Player2")
        {
            InArea = false;
            P.ObjectInArea = false;
            P.Object = null;
            return;
        }
    }

    public void Get ()
    {
        this.gameObject.transform.position = P.ObjSpawn.position;
        this.gameObject.transform.parent = P.ObjSpawn;

        SC.enabled = false;
    }

    public void Drop()
    {
        SC.enabled = true;
    }

    
}
