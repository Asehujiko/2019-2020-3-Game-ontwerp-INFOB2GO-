using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevationController : MonoBehaviour
{
    public GameObject cameraRotator;
    public GameObject body;
    public GameObject turret;
    private GameObject aimingModule;

    public float rotationSpeed;
    public float targetElevation;
    public float ownElevation;

    public Vector3 targetLocation;
    public float rotation;
    public float elevation;

    private void Start()
    {
        aimingModule = new GameObject();
        aimingModule.transform.position = gameObject.transform.position;
    }

    void Update()
    {
        aimingModule.transform.position = gameObject.transform.position;
        targetLocation = cameraRotator.gameObject.GetComponent<CameraController>().aimingPoint;

        //print(targetLocation);

        aimingModule.transform.Rotate(0, 0, 0, Space.World);
        aimingModule.transform.LookAt(targetLocation);

        rotation = Mathf.Cos((turret.transform.localEulerAngles.y / 180) * Mathf.PI);
        elevation = body.transform.localEulerAngles.x;
        if (elevation > 180)
        {
            elevation -= 360;
        }

        targetElevation = aimingModule.transform.eulerAngles.x - elevation * rotation;

        while (targetElevation > 180)
        {
            targetElevation -= 360;
        }

        while (targetElevation < -180)
        {
            targetElevation += 360;
        }

        ownElevation = gameObject.transform.localEulerAngles.x;

        if (targetElevation < 135 && targetElevation > 45)
            targetElevation = 45;

        if (targetElevation > 225 && targetElevation < 330)
            targetElevation = 330;

        if (targetElevation - 180 > ownElevation)
            ownElevation += 360;

        if (targetElevation + 180 < ownElevation)
            ownElevation -= 360;

        float upperBound = ownElevation - rotationSpeed * Time.deltaTime;
        float lowerBound = ownElevation + rotationSpeed * Time.deltaTime;

        gameObject.transform.localRotation = Quaternion.Euler(Mathf.Clamp(targetElevation, upperBound, lowerBound), 0, 0);
    }
}