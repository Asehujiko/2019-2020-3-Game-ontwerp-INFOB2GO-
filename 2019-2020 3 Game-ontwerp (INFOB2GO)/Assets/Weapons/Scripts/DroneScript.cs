using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneScript : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject BombEmitter;
    public GameObject dronemineProjectile;
    public LayerMask ignorelayer;

    public float movementSpeed;
    public float height;
    public int damage;

    float droneLastFired = 0;

    void Start()
    {
        Destroy(gameObject, 10);
    }

    void Update()
    {
        droneLastFired += Time.deltaTime;

        transform.Translate(0, 0, movementSpeed * Time.deltaTime);
        if(transform.position.y < height)
            transform.Translate(0, movementSpeed * Time.deltaTime, 0);

        if (droneLastFired >= 1)
        {
            droneLastFired = 0;
            GameObject bombProjectile = Instantiate(dronemineProjectile, BombEmitter.transform.position, BombEmitter.transform.rotation) as GameObject;
            bombProjectile.GetComponent<MineScript>().setDamage(500);
            bombProjectile.GetComponent<MineScript>().ignorelayer = ignorelayer;
        }
    }

    public void setDamage(int i)
    {
        damage = i;
    }

    void OnCollisionEnter(Collision collision)
    {
        Collider[] others = Physics.OverlapSphere(this.transform.position, 5);
        for (int i = 0; i < others.Length; i++)
        {
            HealthController otherController = others[i].gameObject.transform.root.GetComponent<HealthController>();

            if (otherController != null)
                otherController.getHit(damage);
        }

        GameObject explosion = Instantiate(Explosion, transform.position, transform.rotation) as GameObject;
        Destroy(gameObject);
    }
}