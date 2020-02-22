using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float x;
    float y;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        x += Input.GetAxis("Mouse X");
        y -= Input.GetAxis("Mouse Y");
        y = Mathf.Clamp(y, -30, 60);

        gameObject.transform.rotation = Quaternion.Euler(y, x, 0);
    }
}