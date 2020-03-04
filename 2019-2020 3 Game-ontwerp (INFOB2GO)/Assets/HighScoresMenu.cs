using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoresMenu : MonoBehaviour
{

    public bool isMainMenu;

    void OnMouseUp()
    {
        if (isMainMenu)
            SceneManager.LoadScene("MainMenu");
    }
}
