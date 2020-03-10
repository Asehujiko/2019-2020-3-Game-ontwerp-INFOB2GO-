using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject cameraRotator;
    public float rotationSpeed;

    public float targetRotation;
    public float ownRotation;

    void Update()
    {
        targetRotation = cameraRotator.transform.rotation.eulerAngles.y;
        ownRotation = gameObject.transform.rotation.eulerAngles.y;

        if (targetRotation - 180 > ownRotation)
            ownRotation += 360;

        if (targetRotation + 180 < ownRotation)
            ownRotation -= 360;

        float leftBound = ownRotation - rotationSpeed * Time.deltaTime;
        float rightBound = ownRotation + rotationSpeed * Time.deltaTime;

        transform.Rotate(0, Mathf.Clamp(targetRotation, leftBound, rightBound) - ownRotation, 0);
    }
}