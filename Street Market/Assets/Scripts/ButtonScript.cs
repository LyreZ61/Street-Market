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
    
    public void HausBauen()
    {
        GameObject.Find("BauOrt").SetActive(true);
        GameObject[] BauSelect = GameObject.FindGameObjectsWithTag("BauObjekt");
        int heyy = BauSelect.Length;
        foreach (GameObject BauOrte in BauSelect)
        {
            BauOrte.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
            Debug.Log("Die Länge von dem Array beträgt: " + BauSelect.Length.ToString());
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
