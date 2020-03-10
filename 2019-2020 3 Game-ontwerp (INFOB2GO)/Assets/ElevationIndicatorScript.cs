using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevationIndicatorScript : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Reletive;
    public GameObject Absolute;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float absoluteRotation = Camera.transform.eulerAngles.x;
        if (absoluteRotation < -180)
        {
            absoluteRotation += 360;
        }
        if (absoluteRotation > 180)
        {
            absoluteRotation -= 360;
        }

        Absolute.transform.position = new Vector3(Screen.width/2, Screen.height/2 + absoluteRotation * 10, 0);

        float reletiveRotation = Camera.transform.localEulerAngles.x;
        if (reletiveRotation < -180)
        {
            reletiveRotation += 360;
        }
        if (reletiveRotation > 180)
        {
            reletiveRotation -= 360;
        }
        Reletive.transform.position = new Vector3(Screen.width/2, Screen.height/2 + reletiveRotation * 10, 0);
    }
}
