using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : WeaponController
{
    public float movementSpeed = 1f;
    public float rotationSpeed = 10f;

    public CameraController cameraController;
    public GameObject TurretProjectileEmitter;
    public GameObject HullProjectileEmitter;
    public GameObject RoofProjectileEmitter;

    private SpawnController spawnController;
    public HealthController healthController;

    public float scale;

    public int scrap;
    public int maxhealth = 1000;
    public int totalscrap;

    private Vector3 scaleChange;
    private Vector3 positionChange;

    public int stage = 1;

    public LayerMask ignoreWeaponMask;

    void Start()
    {
        healthController.health = maxhealth;
        spawnController = FindObjectOfType<SpawnController>();

        scaleChange = new Vector3(scale, scale, scale);
        positionChange = new Vector3(0, scale, 0);

        Vector3[] laserStarts = new Vector3[2] { Vector3.zero, Vector3.zero };
        beamRenderer.SetPositions(laserStarts);
        beamRenderer.startWidth = 0.1f;
        beamRenderer.endWidth = 0.1f;
    }

    protected override void Update()
    {
        base.Update();
        transform.Translate(0, 0, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);
        HandleInput();
    }

    public void HandleInput()
    {
        if (Input.GetMouseButton(0))
        {

            if (stage == 1)
                ShootLaser(TurretProjectileEmitter);

            else if (stage >= 2 && stage <= 3)
            { 
                ShootAutocannon(TurretProjectileEmitter);
            }
            else if (stage == 4)
            {
                ShootGatlingcannon(TurretProjectileEmitter);
            }
            else if (stage >= 5)
            {
                ShootRailgun(TurretProjectileEmitter);
            }
        }

        if (Input.GetMouseButton(1))
        {
            if (stage >= 3 && stage <= 5)
            {
                ShootCanistershot(HullProjectileEmitter);
            }

            if (stage >= 6)
            {
                ShootBouncer(HullProjectileEmitter);
            }
        }

        if (Input.GetKey("space"))
        {
            if (stage == 7)
            {
                ShootMortar(RoofProjectileEmitter,cameraController.aimingPoint);
            }

            if (stage == 8)
            {
                ShootEnergysphere(RoofProjectileEmitter, ignoreWeaponMask);
            }

            if (stage == 9)
            {
                ShootDronebomber(RoofProjectileEmitter, ignoreWeaponMask);
            }

            if (stage == 10)
            {
                ShootSonicweapon(ignoreWeaponMask);
            }
        }
        else
        {
            sonicCharge = 0;
        }

        if (Input.GetKeyDown("r"))
        {
            repair();
        }
    }

    public void GetScrap()
    {
        scrap++;
        totalscrap++;
        if (scrap >= stage)
        {
            scrap = 0;
            transform.localScale += scaleChange;
            transform.position += positionChange;

            if (stage < 10)
            {
                stage++;
                maxhealth += 100;
                healthController.health = maxhealth;
            }
            if (spawnController != null)
            {
                spawnController.Staged(stage);
            }
        }
    }

    public void repair()
    {
        if (scrap > 0 && healthController.health < maxhealth)
        {
            scrap--;
            healthController.health += 250;
            if (healthController.health > maxhealth)
                healthController.health = maxhealth;
        }
    }
}