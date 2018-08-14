using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool GameIsOver;          //verhindert ein loop bei gameover ... also verhindert gameoverspam

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    private void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update () {                            //endgame

        if (GameIsOver)                          //verhindert ein loop bei gameover ... also verhindert gameoverspam
            return;

	}

    void EndGame()                              //verhindert ein loop bei gameover ... also verhindert gameoverspam
    {
        GameIsOver = true;

        gameOverUI.SetActive(true);

    }

    public void WinLevel()                      //unlock new levels
    {
        //Debug.Log("Level Won!");
        GameIsOver = true;                      //camera dont moving
        completeLevelUI.SetActive(true);        //end level 


    }

}


