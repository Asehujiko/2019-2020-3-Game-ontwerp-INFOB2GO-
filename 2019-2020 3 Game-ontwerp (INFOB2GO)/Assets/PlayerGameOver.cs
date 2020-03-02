using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        GameObject GameOverObject = GameObject.FindWithTag("GameOver");
        GameOverObject.GetComponent<PlayerHighScore>().enabled = true;
    }
}
