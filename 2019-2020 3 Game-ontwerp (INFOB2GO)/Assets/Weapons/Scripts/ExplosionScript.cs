using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale += new Vector3(+0.2f, +0.2f, +0.2f);
    }
}