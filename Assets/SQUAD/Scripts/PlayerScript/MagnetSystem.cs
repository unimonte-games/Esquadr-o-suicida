using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetSystem : MonoBehaviour
{
    
    public Transform P;
    public float speed = 5f;

    bool MagnetIsAtived;

    void FixedUpdate()
    {
        if (MagnetIsAtived)
        {
            transform.LookAt(P.position);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);

            if (Vector3.Distance(transform.position, P.position) > 0f)
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1" && !MagnetIsAtived)
        {
            P = other.GetComponent<Transform>();
            MagnetIsAtived = true;
        }

        if (other.gameObject.name == "Player2" && !MagnetIsAtived)
        {
            P = other.GetComponent<Transform>();
            MagnetIsAtived = true;
        }
    }
}
