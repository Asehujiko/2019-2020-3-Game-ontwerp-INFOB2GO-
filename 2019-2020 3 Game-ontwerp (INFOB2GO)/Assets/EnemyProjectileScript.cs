using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{
    public GameObject Explosion;
    public int damage;

    void Start()
    {
        Destroy(gameObject, 2);
    }

    public void setDamage(int i)
    {
        damage = i;
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        PlayerController otherController = other.GetComponent<PlayerController>();

        if (otherController != null)
            otherController.getHit(damage);

        GameObject explosion = Instantiate(Explosion, transform.position, transform.rotation) as GameObject;
        Destroy(gameObject);
    }
}