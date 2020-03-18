using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : WeaponController
{
    public float movementSpeed = 1f;
    public float rotationSpeed = 10f;

    public CameraController cameraController;
    public GameObject LaserEmitter;
    public GameObject AutoCannonEmitter;
    public GameObject GatlingGunEmitter;
    public GameObject RailGunEmitter;
    public GameObject HullProjectileEmitter;
    public GameObject MortierEmitter;
    public GameObject EnergySphereEmitter;
    public GameObject LauncherEmitter;

    public GameObject SmallTurret;
    public GameObject LargeTurret;
    public GameObject SmallChassis;
    public GameObject LargeChassis;
    public GameObject HullMount;
    public GameObject CanisterShot;
    public GameObject PhysicsShot;

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
        healthController.maxheath = maxhealth;
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
                ShootLaser(LaserEmitter);

            else if (stage >= 2 && stage <= 3)
            { 
                ShootAutocannon(AutoCannonEmitter);
                if(turretLastFired == 0)
                {
                    audioSource.PlayOneShot(autoCannonShot);
                }
            }
            else if (stage == 4)
            {
                ShootGatlingcannon(GatlingGunEmitter);
                if (turretLastFired == 0)
                {
                    audioSource.PlayOneShot(gatlingShot);
                }
            }
            else if (stage >= 5)
            {
                ShootRailgun(RailGunEmitter);
                if (turretLastFired == 0)
                {
                    audioSource.PlayOneShot(railgunShot);
                }
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
                audioSource.clip = mortierShot;
                audioSource.Play();
                ShootMortar(MortierEmitter,cameraController.aimingPoint);
            }

            if (stage == 8)
            {
                audioSource.clip = energyShot;
                audioSource.Play();
                ShootEnergysphere(EnergySphereEmitter, ignoreWeaponMask);
            }

            if (stage == 9)
            {
                ShootDronebomber(LauncherEmitter, ignoreWeaponMask);
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
                healthController.maxheath = maxhealth;
                healthController.health = maxhealth;
            }
            if (spawnController != null)
            {
                spawnController.Staged(stage);
            }
            switch(stage)
            {
                case 2:
                    LaserEmitter.transform.parent.GetComponent<MeshRenderer>().enabled = false;
                    AutoCannonEmitter.transform.parent.GetComponent<MeshRenderer>().enabled = true;
                    break;
                case 3:
                    SmallChassis.GetComponent<MeshRenderer>().enabled = false;
                    LargeChassis.GetComponent<MeshRenderer>().enabled = true;
                    HullMount.GetComponent<MeshRenderer>().enabled = true;
                    CanisterShot.GetComponent<MeshRenderer>().enabled = true;
                    break;
                case 4:
                    AutoCannonEmitter.transform.parent.GetComponent<MeshRenderer>().enabled = false;
                    GatlingGunEmitter.transform.parent.GetComponent<MeshRenderer>().enabled = true;
                    break;
                case 5:
                    GatlingGunEmitter.transform.parent.GetComponent<MeshRenderer>().enabled = false;
                    RailGunEmitter.transform.parent.GetComponent<MeshRenderer>().enabled = true;
                    break;
                case 6:
                    CanisterShot.GetComponent<MeshRenderer>().enabled = false;
                    PhysicsShot.GetComponent<MeshRenderer>().enabled = true;
                    break;
                case 7:
                    SmallTurret.GetComponent<MeshRenderer>().enabled = false;
                    LargeTurret.GetComponent<MeshRenderer>().enabled = true;
                    MortierEmitter.transform.parent.GetComponent<MeshRenderer>().enabled = true;
                    break;
                case 8:
                    MortierEmitter.transform.parent.GetComponent<MeshRenderer>().enabled = false;
                    EnergySphereEmitter.transform.parent.GetComponent<MeshRenderer>().enabled = true;
                    break;
                case 9:
                    EnergySphereEmitter.transform.parent.GetComponent<MeshRenderer>().enabled = false;
                    LauncherEmitter.transform.parent.GetComponent<MeshRenderer>().enabled = true;
                    break;
                case 10:
                    LauncherEmitter.transform.parent.GetComponent<MeshRenderer>().enabled = false;
                    RailGunEmitter.transform.parent.GetComponent<MeshRenderer>().enabled = false;
                    PhysicsShot.GetComponent<MeshRenderer>().enabled = false;
                    HullMount.GetComponent<MeshRenderer>().enabled = false;
                    break;
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