using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject cameraRotator;
    public float rotationSpeed;

    private float targetRotation;
    public float ownRotation;
    public GameObject body;
    private GameObject rotation;

    private void Start()
    {
        rotation = new GameObject();
    }

    void Update()
    {
        ownRotation = gameObject.transform.rotation.eulerAngles.y;

        float rotation = Mathf.Cos(((ownRotation - 90) / 180) * Mathf.PI);
        float elevation = body.transform.localEulerAngles.x;
        float rotation2 = Mathf.Cos(((ownRotation) / 180) * Mathf.PI);
        float elevation2 = body.transform.localEulerAngles.z;
        if (elevation > 180)
        {
            elevation -= 360;
        }
        if (elevation2 > 180)
        {
            elevation2 -= 360;
        }

        targetRotation = cameraRotator.transform.rotation.eulerAngles.y - elevation * rotation;
        //targetRotation = cameraRotator.transform.rotation.eulerAngles.y;

        if (targetRotation - 180 > ownRotation)
            ownRotation += 360;

        if (targetRotation + 180 < ownRotation)
            ownRotation -= 360;

        float flattarget = cameraRotator.transform.rotation.eulerAngles.y;
        if (flattarget > 180)
        {
            flattarget -= 360;
        }
        if (flattarget < -180)
        {
            flattarget += 360;
        }

        float leftBound = ownRotation - rotationSpeed * Time.deltaTime;
        float rightBound = ownRotation + rotationSpeed * Time.deltaTime;

        this.rotation.transform.localRotation = Quaternion.Euler(0, flattarget, 0);
        transform.Rotate(0, Mathf.Clamp(targetRotation, leftBound, rightBound) - ownRotation, 0);
    }

    public float FlatRotation
    {
        get { return rotation.transform.localEulerAngles.y; }
    }
}