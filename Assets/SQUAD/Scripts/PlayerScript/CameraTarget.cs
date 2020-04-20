using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraTarget : MonoBehaviour
{
    public List<Transform> targets;

    public Vector3 offset;
    public float smoothTime = 0.5f;

    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;

    private Vector3 velocity;
    private Camera cam;

    LevelController LC;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        LC = FindObjectOfType<LevelController>();
    }

    public void UpdateCamera()
    {
        
        if (LC.SoloPlayer)
        {
            if (LC.P1_inRoom)
            {
                GameObject player1Camera = GameObject.Find("Player1");

                targets[0] = player1Camera.transform;
                targets[1] = player1Camera.transform;
                targets[2] = player1Camera.transform;

            }

            if (LC.P2_inRoom)
            {
                GameObject player2Camera = GameObject.Find("Player2");
                targets[1] = player2Camera.transform;

                targets[0] = player2Camera.transform;
                targets[1] = player2Camera.transform;
                targets[2] = player2Camera.transform;
            }
        }
        else
        {
            GameObject player3Camera = GameObject.Find("Player1");
            targets[0] = player3Camera.transform;

            GameObject player4Camera = GameObject.Find("Player2");
            targets[1] = player4Camera.transform;
            targets[2] = player4Camera.transform; //Extra


        }
        
    }


    private void LateUpdate()
    {
        if (targets.Count == 0)
            return;

        Move();
        Zoom();
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }

}
