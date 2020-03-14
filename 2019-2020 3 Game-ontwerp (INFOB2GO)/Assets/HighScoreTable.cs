using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{

    public Text highScoreNames;
    public Text highScores;
    private List<string> names = new List<string>();
    private List<string> scores = new List<string>();

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            names.Add(PlayerPrefs.GetString("High Score Name" + i, "Empty"));
            scores.Add((PlayerPrefs.GetInt("High Score" + i, 0)).ToString());
        }
        
        highScoreNames.text = ListToText(names);
        highScores.text = ListToText(scores);
    }

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
