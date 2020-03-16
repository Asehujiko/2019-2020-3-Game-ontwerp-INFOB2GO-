using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    public GameObject Explosion;
    public int damage;

    void Start()
    {
        Destroy(gameObject, 5);
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