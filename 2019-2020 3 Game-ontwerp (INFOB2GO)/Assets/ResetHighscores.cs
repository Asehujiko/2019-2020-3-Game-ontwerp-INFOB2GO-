using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHighscores : MonoBehaviour
{

    public GameObject highScoreTable;
    private HighScoreTable highScoreTableScript;

    void Awake()
    {
        highScoreTableScript = highScoreTable.GetComponent<HighScoreTable>();
    }

    public void Reset()
    {
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.DeleteKey("High Score" + i);
            PlayerPrefs.DeleteKey("High Score Name" + i);
        }

        highScoreTableScript.scores.Clear();
        highScoreTableScript.names.Clear();
        highScoreTable.GetComponent<HighScoreTable>().DrawTable();
    }
}
