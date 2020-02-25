using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScrap : MonoBehaviour
{

    PlayerScrap scrap;

    // Start is called before the first frame update
    void Start()
    {
        scrap = FindObjectOfType<PlayerScrap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Hull")
        {
            scrap.scrap += 1;

            Destroy(gameObject);
        }
    }
}
