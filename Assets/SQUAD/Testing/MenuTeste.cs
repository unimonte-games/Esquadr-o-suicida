using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTeste : MonoBehaviour
{
   public void Moviment()
    {
        SceneManager.LoadScene(1);
    }

    public void Normal()
    {
        SceneManager.LoadScene(2);
    }

    public void Multiple()
    {
        SceneManager.LoadScene(3);
    }

    public void Orda()
    {
        SceneManager.LoadScene(4);
    }


}
