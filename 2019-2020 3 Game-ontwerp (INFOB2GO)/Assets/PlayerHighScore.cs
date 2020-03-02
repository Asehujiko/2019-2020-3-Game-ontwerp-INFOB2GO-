using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHighScore : MonoBehaviour
{
    private int ListLenght = 10;
    private List<int> HighScoreList = new List<int>();
    private List<string> HighScoreNameList = new List<string>();

    private PlayerScrap GetScrap;
    private int scrap;
    private string PlayerName = "tank";

    // Start is called before the first frame update
    void Start()
    {
        GetScrap = FindObjectOfType<PlayerScrap>();
        scrap = GetScrap.TotalScrap;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        PlayerName = GUI.TextField(new Rect(10, 10, 200, 20), PlayerName, 12);

        if (GUI.Button(new Rect(10, 30, 200, 60), "Save High Score"))
        {
            GetHighScore();
            SaveHighScore(PlayerName, scrap);
        }
    }

    private void GetHighScore()
    {
        for(int i = 0; i < ListLenght; i++)
        {
            HighScoreList.Add(PlayerPrefs.GetInt("High Score" + i, 0));
            HighScoreNameList.Add(PlayerPrefs.GetString("High Score Name" + i, "-"));
        }
    }

    private void SaveHighScore(string PlayerName, int score)
    {
        bool inserted = false;
        for(int i = 0; i < ListLenght; i++)
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
