using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float rotationSpeed = 10f;

    public LineRenderer beamRenderer;
    public float laserLength = 20f;
    public float railgunLength = 20f;

    public GameObject autocannonProjectile;
    public GameObject canistershotProjectile;
    public GameObject gatlingProjectile;
    public GameObject bouncerProjectile;

    public GameObject TurretProjectileEmitter;
    public GameObject HullProjectileEmitter;
    public GameObject RoofProjectileEmitter;

    public float scale;

    public int scrap;

    private Vector3 scaleChange;
    private Vector3 positionChange;

    public int stage = 1;

    float turretLastFired = 0;
    float hullLastFired = 0;

    void Start()
    {
        scaleChange = new Vector3(scale, scale, scale);
        positionChange = new Vector3(0, scale, 0);

        Vector3[] laserStarts = new Vector3[2] { Vector3.zero, Vector3.zero };
        beamRenderer.SetPositions(laserStarts);
        beamRenderer.SetWidth(0.1f, 0.1f);
    }

    void Update()
    {
        transform.Translate(0, 0, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);

        turretLastFired += Time.deltaTime;
        hullLastFired += Time.deltaTime;

        if (turretLastFired >= 0.2f)
            beamRenderer.enabled = false;

        HandleInput();
    }

    public void HandleInput()
    {
        if (Input.GetMouseButton(0))
        {
            if (stage == 1)
                ShootLaser();

            if (stage >= 2 && stage <= 3)
                ShootAutocannon();

            if (stage == 4)
                ShootGatlingcannon();

            if (stage >= 5)
            {
                ShootRailgun();
            }
        }


        if (Input.GetMouseButton(1))
        {
            if (stage >= 3 && stage <= 5)
            {
                ShootCanistershot();
            }

            if (stage == 6)
            {
                ShootBouncer();
            }

            if (stage >= 7)
            {
                ShootMortar();
            }
        }

        if (Input.GetKeyDown("space"))
        {
            if (stage == 8)
            {
                ShootEnergysphere();
            }

            if (stage == 9)
            {
                ShootDronebomber();
            }

            if (stage == 10)
            {
                ShootSonicweapon();
            }
        }
    }

    public void GetScrap()
    {
        scrap++;
        if (scrap >= stage)
        {
            scrap = 0;
            transform.localScale += scaleChange;
            transform.position += positionChange;

            if (stage < 10)
                stage++;
        }
    }

    public void ShootLaser()
    {
        beamRenderer.enabled = true;

        Ray ray = new Ray(TurretProjectileEmitter.transform.position, TurretProjectileEmitter.transform.up);
        RaycastHit rayHit;
        Vector3 endPoint = TurretProjectileEmitter.transform.position + (laserLength * TurretProjectileEmitter.transform.up);

        if (Physics.Raycast(ray, out rayHit, laserLength))
        {
            endPoint = rayHit.point;

            GameObject other = rayHit.collider.gameObject;
            EnemyController otherController = other.GetComponent<EnemyController>();

            if (otherController != null)
                otherController.getHit(1);
        }

        beamRenderer.SetPosition(0, TurretProjectileEmitter.transform.position);
        beamRenderer.SetPosition(1, endPoint);
    }

    public void ShootAutocannon()
    {
        if (turretLastFired >= 1 / 5f)
        {
            turretLastFired = 0;

            GameObject turretProjectile = Instantiate(autocannonProjectile, TurretProjectileEmitter.transform.position, TurretProjectileEmitter.transform.rotation) as GameObject;

            turretProjectile.GetComponent<Rigidbody>().AddRelativeForce(0, 5000, 0);
            turretProjectile.GetComponent<ProjectileScript>().setDamage(20);
        }
    }

    public void ShootCanistershot()
    {
        if (hullLastFired >= 1f)
        {
            hullLastFired = 0;

            GameObject[] hullProjectiles = new GameObject[30];
            for (int i = 0; i < 30; i++)
            {
                hullProjectiles[i] = Instantiate(canistershotProjectile, HullProjectileEmitter.transform.position, HullProjectileEmitter.transform.rotation) as GameObject;
                hullProjectiles[i].GetComponent<Rigidbody>().AddRelativeForce(Random.Range(-1000f, 1000f), 2500, Random.Range(-1000f, 0));
                hullProjectiles[i].GetComponent<ProjectileScript>().setDamage(20);
            }
        }
    }

    public void ShootGatlingcannon()
    {
        if (turretLastFired >= 1 / 50f)
        {
            turretLastFired = 0;

            GameObject turretProjectile = Instantiate(gatlingProjectile, TurretProjectileEmitter.transform.position, TurretProjectileEmitter.transform.rotation) as GameObject;

            turretProjectile.GetComponent<Rigidbody>().AddRelativeForce(Random.Range(-100f, 100f), 2500, Random.Range(-100f, 100f));
            turretProjectile.GetComponent<ProjectileScript>().setDamage(5);
        }
    }

    public void ShootRailgun()
    {
        if (turretLastFired >= 2)
        {
            turretLastFired = 0;

            beamRenderer.enabled = true;

            Ray ray = new Ray(TurretProjectileEmitter.transform.position, TurretProjectileEmitter.transform.up);
            RaycastHit[] rayHits;
            Vector3 endPoint = TurretProjectileEmitter.transform.position + (railgunLength * TurretProjectileEmitter.transform.up);

            rayHits = Physics.RaycastAll(ray, laserLength);

            for (int i = 0; i < rayHits.Length; i++)
            {
                RaycastHit rayHit = rayHits[i];

                GameObject other = rayHit.collider.gameObject;
                EnemyController otherController = other.GetComponent<EnemyController>();

                if (otherController != null)
                    otherController.getHit(100);
            }

            beamRenderer.SetPosition(0, TurretProjectileEmitter.transform.position);
            beamRenderer.SetPosition(1, endPoint);
        }
    }

    public void ShootBouncer()
    {
        if (hullLastFired >= 1)
        {
            hullLastFired = 0;

            GameObject hullProjectile = Instantiate(bouncerProjectile, HullProjectileEmitter.transform.position, HullProjectileEmitter.transform.rotation) as GameObject;

            hullProjectile.GetComponent<Rigidbody>().AddRelativeForce(0, 500, 0);
            hullProjectile.GetComponent<BouncerScript>().setDamage(50);
        }
    }

    public void ShootMortar()
    {

    }

    public void ShootEnergysphere()
    {

    }

    public void ShootDronebomber()
    {

    }

    public void ShootSonicweapon()
    {

    }
}