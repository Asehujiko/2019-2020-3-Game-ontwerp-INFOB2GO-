using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Camera;
    public GameObject Reletive;
    public GameObject Absolute;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float reletiveRotation = Camera.transform.localEulerAngles.y;
        if (reletiveRotation < -180)
        {
            reletiveRotation += 360;
        }
        if (reletiveRotation > 180)
        {
            reletiveRotation -= 360;
        }

        Reletive.transform.localPosition = new Vector3(-reletiveRotation * 5, Screen.height/2 - 30, 0);

        float absoluteRotation = Camera.transform.eulerAngles.y;
        if (absoluteRotation < -180)
        {
            absoluteRotation += 360;
        }
        if (absoluteRotation > 180)
        {
            absoluteRotation -= 360;
        }

        Absolute.transform.localPosition = new Vector3(-absoluteRotation * 5, -Screen.height/2 +30, 0);
    }
}
