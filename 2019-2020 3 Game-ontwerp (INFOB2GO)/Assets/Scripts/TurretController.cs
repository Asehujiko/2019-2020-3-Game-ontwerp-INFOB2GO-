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
    public Vector3 target;
    public Vector3 pretarget;
    public Vector3 turretloction;
    public Quaternion bodyrotation;
    GameObject direction;

    private void Start()
    {
        direction = new GameObject();
    }

    void Update()
    {
        PlayerController player = body.GetComponent<PlayerController>();
        if (player.dead)
        {
            return;
        }
        target = cameraRotator.gameObject.GetComponent<CameraController>().aimingPoint;
        turretloction = transform.position;
        bodyrotation = body.transform.rotation;

        target = new Vector3(target.x - turretloction.x, target.y - turretloction.y, target.z - turretloction.z);
        pretarget = target;
        target = Quaternion.Inverse(bodyrotation) * target;

        direction.transform.position = new Vector3(0, 0, 0);
        direction.transform.LookAt(target);
        float rotation = direction.transform.eulerAngles.y;

        targetRotation = rotation;

        while (targetRotation > 180)
        {
            targetRotation -= 360;
        }

        while (targetRotation < -180)
        {
            targetRotation += 360;
        }

        ownRotation = transform.localEulerAngles.y;

        if (targetRotation - 180 > ownRotation)
            ownRotation += 360;

        if (targetRotation + 180 < ownRotation)
            ownRotation -= 360;

        float leftBound = ownRotation - rotationSpeed * Time.deltaTime;
        float rightBound = ownRotation + rotationSpeed * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(0, Mathf.Clamp(targetRotation, leftBound, rightBound), 0);
    }
}