using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTeste : MonoBehaviour
{

   public void GoToScene (int valueToScene)
    {
        SceneManager.LoadScene(valueToScene);
    }

    


}
