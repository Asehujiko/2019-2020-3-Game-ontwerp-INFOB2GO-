using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public GameObject Explosion;

    void Start()
    {
        Destroy(gameObject, 2);
    }

    void OnCollisionEnter()
    {
        GameObject explosion = Instantiate(Explosion, transform.position, transform.rotation) as GameObject;
        Destroy(gameObject);
    }
}
