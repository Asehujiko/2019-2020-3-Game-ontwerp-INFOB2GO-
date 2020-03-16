using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    //weapon lengt
    public LineRenderer beamRenderer;
    public float laserLength = 20f;
    public float railgunLength = 20f;

    //weapon projectiles
    public GameObject autocannonProjectile;
    public GameObject canistershotProjectile;
    public GameObject gatlingProjectile;
    public GameObject bouncerProjectile;
    public GameObject outboundMortarProjectile;
    public GameObject inboundMortarProjectile;
    public GameObject energysphereProjectile;
    public GameObject dronebomberProjectile;

    //public GameObject TurretProjectileEmitter;
    //public GameObject HullProjectileEmitter;
    //public GameObject RoofProjectileEmitter;

    protected float turretLastFired = 0;
    protected float hullLastFired = 0;
    protected float roofLastFired = 0;
    protected float sonicCharge = 0;

    protected virtual void Update()
    {
        turretLastFired += Time.deltaTime;
        hullLastFired += Time.deltaTime;
        roofLastFired += Time.deltaTime;

        if (turretLastFired >= 0.2f)
            beamRenderer.enabled = false;
    }

    protected void ShootLaser(GameObject direction)
    {
        beamRenderer.enabled = true;

        Ray ray = new Ray(direction.transform.position, direction.transform.up);
        RaycastHit rayHit;
        Vector3 endPoint = direction.transform.position + (laserLength * direction.transform.up);

        if (Physics.Raycast(ray, out rayHit, laserLength))
        {
            endPoint = rayHit.point;

            GameObject other = rayHit.collider.transform.root.gameObject;
            HealthController otherController = other.GetComponent<HealthController>();

            if (otherController != null)
                otherController.getHit(1);
        }

        beamRenderer.SetPosition(0, direction.transform.position);
        beamRenderer.SetPosition(1, endPoint);
    }

    protected void ShootAutocannon(GameObject direction)
    {
        if (turretLastFired >= 1 / 5f)
        {
            turretLastFired = 0;

            GameObject turretProjectile = Instantiate(autocannonProjectile, direction.transform.position, direction.transform.rotation) as GameObject;

            turretProjectile.GetComponent<Rigidbody>().AddRelativeForce(0, 5000, 0);
            turretProjectile.GetComponent<ProjectileScript>().setDamage(20);
        }
    }

    protected void ShootCanistershot(GameObject direction)
    {
        if (hullLastFired >= 1f)
        {
            hullLastFired = 0;

            GameObject[] hullProjectiles = new GameObject[30];
            for (int i = 0; i < 30; i++)
            {
                hullProjectiles[i] = Instantiate(canistershotProjectile, direction.transform.position, direction.transform.rotation) as GameObject;
                hullProjectiles[i].GetComponent<Rigidbody>().AddRelativeForce(Random.Range(-1000f, 1000f), 2500, Random.Range(-1000f, 0));
                hullProjectiles[i].GetComponent<ProjectileScript>().setDamage(20);
            }
        }
    }

    protected void ShootGatlingcannon(GameObject direction)
    {
        if (turretLastFired >= 1 / 50f)
        {
            turretLastFired = 0;

            GameObject turretProjectile = Instantiate(gatlingProjectile, direction.transform.position, direction.transform.rotation) as GameObject;

            turretProjectile.GetComponent<Rigidbody>().AddRelativeForce(Random.Range(-100f, 100f), 2500, Random.Range(-100f, 100f));
            turretProjectile.GetComponent<ProjectileScript>().setDamage(5);
        }
    }

    protected void ShootRailgun(GameObject direction)
    {
        if (turretLastFired >= 2)
        {
            turretLastFired = 0;

            beamRenderer.enabled = true;

            Ray ray = new Ray(direction.transform.position, direction.transform.up);
            RaycastHit[] rayHits;
            Vector3 endPoint = direction.transform.position + (railgunLength * direction.transform.up);

            rayHits = Physics.RaycastAll(ray, laserLength);

            for (int i = 0; i < rayHits.Length; i++)
            {
                RaycastHit rayHit = rayHits[i];

                GameObject other = rayHit.collider.transform.root.gameObject;
                HealthController otherController = other.GetComponent<HealthController>();

                if (otherController != null)
                    otherController.getHit(100);
            }

            beamRenderer.SetPosition(0, direction.transform.position);
            beamRenderer.SetPosition(1, endPoint);
        }
    }

    protected void ShootBouncer(GameObject direction)
    {
        if (hullLastFired >= 1)
        {
            hullLastFired = 0;

            GameObject hullProjectile = Instantiate(bouncerProjectile, direction.transform.position, direction.transform.rotation) as GameObject;

            hullProjectile.GetComponent<Rigidbody>().AddRelativeForce(0, 500, 0);
            hullProjectile.GetComponent<BouncerScript>().setDamage(50);
        }
    }

    protected void ShootMortar(GameObject direction, Vector3 targetlocation)
    {
        if (roofLastFired >= 1)
        {
            roofLastFired = 0;

            GameObject roofProjectile1 = Instantiate(outboundMortarProjectile, direction.transform.position, direction.transform.rotation) as GameObject;
            roofProjectile1.GetComponent<Rigidbody>().AddRelativeForce(0, 1000, 0);
            Destroy(roofProjectile1, 1);

            GameObject roofProjectile2 = Instantiate(inboundMortarProjectile, targetlocation + new Vector3(0, 20, 0), direction.transform.rotation) as GameObject;
            roofProjectile2.GetComponent<Rigidbody>().AddRelativeForce(0, -250, 0);
            roofProjectile2.GetComponent<GrenadeScript>().setDamage(100);
        }
    }

    protected void ShootEnergysphere(GameObject direction)
    {
        if (roofLastFired >= 1)
        {
            roofLastFired = 0;

            GameObject roofProjectile = Instantiate(energysphereProjectile, direction.transform.position, direction.transform.rotation) as GameObject;
            roofProjectile.GetComponent<FloaterScript>().setDamage(1);
        }
    }

    protected void ShootDronebomber(GameObject direction)
    {
        if (roofLastFired >= 1)
        {
            roofLastFired = 0;
            GameObject roofProjectile = Instantiate(dronebomberProjectile, direction.transform.position, direction.transform.rotation) as GameObject;
            roofProjectile.GetComponent<DroneScript>().setDamage(100);
        }
    }

    protected void ShootSonicweapon()
    {
        sonicCharge += Time.deltaTime;
        if (sonicCharge >= 3)
        {
            Collider[] others = Physics.OverlapSphere(this.transform.position, 100);
            for (int i = 0; i < others.Length; i++)
            {
                HealthController otherController = others[i].GetComponent<HealthController>();

                if (otherController != null)
                    otherController.die();
            }
        }
    }
}
