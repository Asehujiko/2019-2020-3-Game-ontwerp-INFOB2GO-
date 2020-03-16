﻿using System.Collections;
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

    public float scale;

    public int scrap;
    public int health = 100;
    public int maxhealth = 100;

    private Vector3 scaleChange;
    private Vector3 positionChange;

    public int stage = 1;

    void Start()
    {
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

            if (stage >= 2 && stage <= 3)
                ShootAutocannon(TurretProjectileEmitter);

            if (stage == 4)
                ShootGatlingcannon(TurretProjectileEmitter);

            if (stage >= 5)
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
                ShootEnergysphere(RoofProjectileEmitter);
            }

            if (stage == 9)
            {
                ShootDronebomber(RoofProjectileEmitter);
            }

            if (stage == 10)
            {
                ShootSonicweapon();
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
        if (scrap >= stage)
        {
            scrap = 0;
            transform.localScale += scaleChange;
            transform.position += positionChange;

            if (stage < 10)
                stage++;
        }
    }

    public void getHit(int damage)
    {
        health-= damage;
        if(health <= 0)
        {
            if (stage > 1)
            {
                stage--;
                transform.localScale -= scaleChange;
                transform.position -= positionChange;
                health = maxhealth;
            }
            else
                die();
        }
    }

    public void die()
    {
        print("ded");
        //terug naar het hoofdmenu en zo
    }

    public void repair()
    {
        if (scrap > 0 && health < maxhealth)
        {
            scrap--;
            health += 25;
            if (health > maxhealth)
                health = maxhealth;
        }
    }
}