using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerScript : MonoBehaviour
{
    public GameObject Explosion;
    public int damage;

    void Start()
    {
        Destroy(gameObject, 10);
    }

    public void setDamage(int i)
    {
        damage = i;
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        EnemyController otherController = other.GetComponent<EnemyController>();

        if (otherController != null)
        {
            otherController.getHit(damage);
            GameObject explosion = Instantiate(Explosion, transform.position, transform.rotation) as GameObject;
        }

    }
}
