using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : WeaponController
{
    //standerd variables
    public int weapontype = 0;
    public GameObject weaponEmitter;
    public GameObject morterEmitter;

    //player info
    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        if (player != null)
        {
            weapontype = Random.Range(player.stage - 2, player.stage + 3);
        }
        Mathf.Clamp(weapontype, 1, 10);
    }

    public void Shoot(Vector3 targetlocation)
    {
        switch (weapontype)
        {
            case 1:
                ShootLaser(weaponEmitter);
                break;
            case 2:
                ShootAutocannon(weaponEmitter);
                break;
            case 3:
                ShootCanistershot(weaponEmitter);
                break;
            case 4:
                ShootGatlingcannon(weaponEmitter);
                break;
            case 5:
                ShootRailgun(weaponEmitter);
                break;
            case 6:
                ShootBouncer(weaponEmitter);
                break;
            case 7:
                ShootMortar(morterEmitter,targetlocation);
                break;
            case 8:
                ShootEnergysphere(weaponEmitter);
                break;
            case 9:
                ShootLaser(weaponEmitter);
                break;
            case 10:
                ShootGatlingcannon(weaponEmitter);
                break;
        }
    }
}
