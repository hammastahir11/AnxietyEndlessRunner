using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void RestartThisGame()
    {

        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

        
    }

    public void Exit()
    {
        Application.Quit();
    }
}
