using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevationController : MonoBehaviour
{
    public GameObject cameraRotator;
    public GameObject aimingModule;

    public float rotationSpeed;
    public float targetElevation;
    public float ownElevation;

    public Vector3 targetLocation;

    void Update()
    {
        targetLocation = cameraRotator.gameObject.GetComponent<CameraController>().aimingPoint;

        //print(targetLocation);

        aimingModule.transform.Rotate(0, 0, 0, Space.World);
        aimingModule.transform.LookAt(targetLocation);

        targetElevation = aimingModule.transform.rotation.eulerAngles.x;

        ownElevation = gameObject.transform.rotation.eulerAngles.x;

        if (targetElevation < 135 && targetElevation > 8)
            targetElevation = 8;

        if (targetElevation > 225 && targetElevation < 330)
            targetElevation = 330;

        if (targetElevation - 180 > ownElevation)
            ownElevation += 360;

        if (targetElevation + 180 < ownElevation)
            ownElevation -= 360;

        float upperBound = ownElevation - rotationSpeed * Time.deltaTime;
        float lowerBound = ownElevation + rotationSpeed * Time.deltaTime;

        //transform.Rotate(Mathf.Clamp(targetElevation, upperBound, lowerBound) - ownElevation, 0, 0, Space.Self);

        gameObject.transform.localRotation = Quaternion.Euler(Mathf.Clamp(targetElevation, upperBound, lowerBound), 0, 0);
    }
}