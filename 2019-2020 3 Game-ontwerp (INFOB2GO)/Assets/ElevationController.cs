using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevationController : MonoBehaviour
{
    public GameObject cameraRotator;
    public float rotationSpeed;

    public float targetElevation;
    public float ownElevation;

    void Update()
    {
        targetElevation = cameraRotator.transform.rotation.eulerAngles.x;
        ownElevation = gameObject.transform.rotation.eulerAngles.x;

        if (targetElevation - 180 > ownElevation)
            ownElevation += 360;

        if (targetElevation + 180 < ownElevation)
            ownElevation -= 360;

        float leftBound = ownElevation - rotationSpeed * Time.deltaTime;
        float rightBound = ownElevation + rotationSpeed * Time.deltaTime;

        transform.Rotate(Mathf.Clamp(targetElevation, leftBound, rightBound) - ownElevation, 0, 0);

        if(gameObject.transform.rotation.eulerAngles.x > 8 && gameObject.transform.rotation.eulerAngles.x < 90)
            transform.rotation = Quaternion.Euler(8, gameObject.transform.rotation.eulerAngles.y, gameObject.transform.rotation.eulerAngles.z);
    }
}