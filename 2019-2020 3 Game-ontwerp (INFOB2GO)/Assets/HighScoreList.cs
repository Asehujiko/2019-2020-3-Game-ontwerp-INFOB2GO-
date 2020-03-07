using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreList : MonoBehaviour
{

    private GUIStyle textStyle = new GUIStyle();

    // Start is called before the first frame update
    void Start()
    {
        textStyle.fontSize = 45;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        GUI.contentColor = Color.black;
        for (int i = 0; i < 10; i++)
        {
            GUI.Label(new Rect(160, 220 + i * 55, 100, 20), ((i + 1) + " "), textStyle);
            GUI.Label(new Rect(230, 220 + i * 55, 100, 20), ("Name: " + PlayerPrefs.GetString("High Score Name" + i, "Empty")), textStyle);
            GUI.Label(new Rect(800, 220 + i * 55, 100, 20), ("Score: " + (PlayerPrefs.GetInt("High Score" + i, 0))), textStyle);
        }
    }
}
