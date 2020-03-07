using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHighScore : MonoBehaviour
{
    private int ListLength = 10;
    private List<int> HighScoreList = new List<int>();
    private List<string> HighScoreNameList = new List<string>();

    private PlayerScrap GetScrap;
    private int scrap;
    private string PlayerName = "Tank";

    // Start is called before the first frame update
    void Start()
    {
        GetScrap = FindObjectOfType<PlayerScrap>();
        scrap = GetScrap.TotalScrap;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
    }

    void OnGUI()
    {
        PlayerName = GUI.TextField(new Rect(10, 10, 200, 20), PlayerName, 12);

        if (GUI.Button(new Rect(10, 30, 200, 60), "Save High Score"))
        {
            GetHighScore();
            SaveHighScore(PlayerName, scrap);
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void GetHighScore()
    {
        for(int i = 0; i < ListLength; i++)
        {
            HighScoreList.Add(PlayerPrefs.GetInt("High Score" + i, 0));
            HighScoreNameList.Add(PlayerPrefs.GetString("High Score Name" + i, "Empty"));
        }
    }

    private void SaveHighScore(string PlayerName, int score)
    {
        bool inserted = false;
        for(int i = 0; i < ListLength; i++)
        {
            if(HighScoreList[i] < score && !inserted)
            {
                HighScoreList.Insert(i, score);
                HighScoreNameList.Insert(i, PlayerName);
                inserted = true;
            }
            PlayerPrefs.SetInt("High Score" + i, HighScoreList[i]);
            PlayerPrefs.SetString("High Score Name" + i, HighScoreNameList[i]);
        }
        PlayerPrefs.Save();
    }
}
