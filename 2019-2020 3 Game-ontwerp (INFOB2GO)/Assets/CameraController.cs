using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float x;
    float y;
    float maxRange = 500f;
    Vector3 rayOrigin;
    public Vector3 aimingPoint;
    public GameObject target;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rayOrigin = new Vector3(0.5f, 0.5f, 0f);
    }

    void LateUpdate()
    {
        x += Input.GetAxis("Mouse X");
        y -= Input.GetAxis("Mouse Y");
        y = Mathf.Clamp(y, -30, 60);

        gameObject.transform.localRotation = Quaternion.Euler(y, x, 0);

        Ray ray = Camera.main.ViewportPointToRay(rayOrigin);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxRange))
        {
            aimingPoint = hit.point;
            target.transform.position = aimingPoint;
            print(aimingPoint);
        }
        else
        {
            aimingPoint = gameObject.transform.forward * maxRange;
        }
    }
}