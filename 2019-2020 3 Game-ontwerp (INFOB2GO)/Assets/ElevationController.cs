using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class ElevationController : MonoBehaviour
{
    public GameObject cameraRotator;
    public GameObject body;

    public float rotationSpeed;
    public float targetElevation;
    public float ownElevation;

    public Vector3 target;
    public Vector3 elevationlocation;
    public Quaternion bodyrotation;
    GameObject direction;

    private void Start()
    {
        //aimingModule = new GameObject();
        //aimingModule.transform.position = gameObject.transform.position;
        direction = new GameObject();
    }

    void Update()
    {
        target = cameraRotator.gameObject.GetComponent<CameraController>().aimingPoint;
        elevationlocation = transform.position;
        bodyrotation = body.transform.rotation;

        target = new Vector3(target.x - elevationlocation.x, target.y - elevationlocation.y, target.z - elevationlocation.z);
        target = Quaternion.Inverse(bodyrotation) * target;
        direction.transform.position = new Vector3(0, 0, 0);
        direction.transform.LookAt(target);
        float rotation = direction.transform.eulerAngles.x;

        //transform.localRotation = Quaternion.Euler(rotation, 0, 0);

        targetElevation = rotation;

        while (targetElevation > 180)
        {
            targetElevation -= 360;
        }

        while (targetElevation < -180)
        {
            targetElevation += 360;
        }

        ownElevation = gameObject.transform.localEulerAngles.x;

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

        gameObject.transform.localRotation = Quaternion.Euler(Mathf.Clamp(targetElevation, upperBound, lowerBound), 0, 0);
    }
}