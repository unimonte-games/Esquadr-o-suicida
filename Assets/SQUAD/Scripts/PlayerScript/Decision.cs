using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Decision : MonoBehaviour
{
    public KeyCode Selecionar;
    public GameObject[] Escolha;
        
    public int Select;
    int count;
    float timeToClick;
    bool DontMove;
    public float timeToEnd;

    PlayerUI PUI;

    private void Awake()
    {
        PUI = FindObjectOfType<PlayerUI>();
    }

    private void OnEnable()
    {
        Select = 0;
        Escolha[Select].SetActive(true);
    }

    private void FixedUpdate()
    {
        if (!DontMove)
        {
            timeToEnd -= Time.deltaTime;
            if (timeToEnd <= 0)
            {
                timeToEnd = 0;
                DontMove = true;
                Invoke("SetSelect", 1);
            }

            timeToClick += Time.deltaTime;
            if (Input.GetKeyDown(Selecionar) && timeToClick >= 0.5f)
            {
                timeToClick = 0f;
                Escolha[Select].SetActive(false);

                Select++;
                if (Select > 2)
                {
                    Select = 0;
                }

                Escolha[Select].SetActive(true);

            }
        }
    }

    void SetSelect()
    {
        PUI.SetRoulleteDecision(Select);
    }

}

