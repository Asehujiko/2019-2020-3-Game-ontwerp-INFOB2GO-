using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScrap : MonoBehaviour
{
    [Header("scaleChange")]
    public float scale;
    [Header("limit")]
    public int limit;


    private Vector3 scaleChange;
    private Vector3 positionChange;

    public int scrap;
    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(scale, scale, scale);
        positionChange = new Vector3(0, scale, 0);
        scrap = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(scrap == limit)
        {
            scrap = 0;
            GameObject player = GameObject.FindWithTag("Player");
            player.transform.localScale += scaleChange;
            player.transform.position += positionChange;
        }
    }
}
