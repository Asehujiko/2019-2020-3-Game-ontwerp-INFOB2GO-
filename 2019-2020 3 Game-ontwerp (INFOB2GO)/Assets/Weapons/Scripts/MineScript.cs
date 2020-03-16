using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    public GameObject Explosion;

    public int damage;

    bool exploded = false;

    void Start()
    {
        Destroy(gameObject, 10);
    }

    public void setDamage(int i)
    {
        damage = i;
    }

    void Update()
    {
        if (exploded)
        {
            GameObject explosion = Instantiate(Explosion, transform.position, transform.rotation) as GameObject;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Collider[] others = Physics.OverlapSphere(this.transform.position, 5);
        for (int i = 0; i < others.Length; i++)
        {
            HealthController otherController = others[i].gameObject.transform.root.GetComponent<HealthController>();

            if (otherController != null)
            {
                otherController.getHit(damage);
                exploded = true;
            }
        }
    }
}
