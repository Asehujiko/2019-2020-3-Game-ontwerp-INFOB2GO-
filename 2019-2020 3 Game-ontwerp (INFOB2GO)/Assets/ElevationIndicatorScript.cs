using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevationIndicatorScript : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Relative;
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

        Absolute.transform.localPosition = new Vector3(-200, absoluteRotation * 5, 0);

        float reletiveRotation = Camera.transform.localEulerAngles.x;
        if (reletiveRotation < -180)
        {
            reletiveRotation += 360;
        }
        if (reletiveRotation > 180)
        {
            reletiveRotation -= 360;
        }
        Relative.transform.localPosition = new Vector3(200, reletiveRotation * 5, 0);
    }
}
