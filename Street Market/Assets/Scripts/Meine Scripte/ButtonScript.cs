using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

    private float currentSpeed = 1f;


    public void MoveToScene(int SceneZahl)
    {
        SceneManager.LoadScene(SceneZahl);
        Time.timeScale = 1;
    }

    public void GoToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Pause(bool pas)
    {
        if (pas)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = currentSpeed;
        }
    }

    public void Speed()
    {
        if (currentSpeed == 1f)
        {
            currentSpeed = 2f;
        }
        else
        {
            currentSpeed = 1f;
        }
        Time.timeScale = currentSpeed;
    }

    

    public void QutiGame()
    {
        Application.Quit();
    }
}
