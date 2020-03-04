using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // these are the buttons on the main menu
    public bool isStart, isHighscore, isSettings, isExit;

    void OnMouseUp()
    {
        if (isStart)
            SceneManager.LoadScene("MyScene");
        if (isHighscore)
            SceneManager.LoadScene("HighScores");
        if (isSettings)
            return;
        if (isExit)
            Application.Quit();
    }
}
