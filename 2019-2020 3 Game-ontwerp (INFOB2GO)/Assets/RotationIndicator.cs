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

        Reletive.transform.position = new Vector3(Screen.width / 2 - reletiveRotation * 10, Screen.height - 50, 0);

        float absoluteRotation = Camera.transform.eulerAngles.y;
        if (absoluteRotation < -180)
        {
            absoluteRotation += 360;
        }
        if (absoluteRotation > 180)
        {
            absoluteRotation -= 360;
        }

        Absolute.transform.position = new Vector3(Screen.width / 2 - absoluteRotation * 10, 50, 0);
    }
}
