using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitMeniu : MonoBehaviour
{
    public void LoadGameScene()
    {
        Debug.Log("Iseinu");
        SceneManager.LoadScene("Meniu", LoadSceneMode.Single);
    }
   
}
