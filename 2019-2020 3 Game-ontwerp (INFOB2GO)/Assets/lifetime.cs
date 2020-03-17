using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifetime : MonoBehaviour
{
    public float life = 4f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, life);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
