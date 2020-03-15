using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHighscores : MonoBehaviour
{

    public GameObject highScoreTable;
    private HighScoreTable highScoreTableScript;

    // called when the script starts
    void Awake()
    {
        highScoreTableScript = highScoreTable.GetComponent<HighScoreTable>();
    }

    public void Reset()
    {
        // permanently deletes the high score and high score name PlayerPrefs
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.DeleteKey("High Score" + i);
            PlayerPrefs.DeleteKey("High Score Name" + i);
        }

        // clears and redraws the now empty high score table
        highScoreTableScript.scores.Clear();
        highScoreTableScript.names.Clear();
        highScoreTable.GetComponent<HighScoreTable>().DrawTable();
    }
}
