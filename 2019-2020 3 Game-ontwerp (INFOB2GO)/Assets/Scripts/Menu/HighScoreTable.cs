using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{

    public Text highScoreNames;
    public Text highScores;
    public List<string> names = new List<string>();
    public List<string> scores = new List<string>();

    void Start()
    {
        DrawTable();
    }

    public void DrawTable()
    {
        // adds the high scores and the names associated with it to a scores and names list
        for (int i = 0; i < 10; i++)
        {
            names.Add(PlayerPrefs.GetString("High Score Name" + i, "Empty"));
            scores.Add((PlayerPrefs.GetInt("High Score" + i, 0)).ToString());
        }

        // the string of the high scores and names will be added to the high score table which will then be drawn on the screen
        highScoreNames.text = ListToText(names);
        highScores.text = ListToText(scores);
    }

    // the content of the aforementioned lists will be converted to a string
    private string ListToText(List<string> list)
    {
        string text = "";
        foreach (var i in list)
        {
            text += i.ToString() + "\n";
        }

        return text;
    }
}
