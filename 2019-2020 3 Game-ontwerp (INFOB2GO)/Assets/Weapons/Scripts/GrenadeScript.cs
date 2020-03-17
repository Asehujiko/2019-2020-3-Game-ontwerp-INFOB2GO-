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
            HealthController otherController = FindParentWithHealth(others[i].gameObject);

            if (otherController != null)
                otherController.getHit(damage);
        }

        GameObject explosion = Instantiate(Explosion, transform.position, transform.rotation) as GameObject;
        Destroy(gameObject);
    }

    public HealthController FindParentWithHealth(GameObject childObject)
    {
        Transform t = childObject.transform;
        int i = 0;
        if (t.gameObject.GetComponent<HealthController>())
        {
            return t.gameObject.GetComponent<HealthController>();
        }
        while (t.parent != null)
        {
            if (t.parent.gameObject.GetComponent<HealthController>())
            {
                Debug.Log(t.parent.name);
                return t.parent.gameObject.GetComponent<HealthController>();
            }
            t = t.parent.transform;
        }
        return null; // Could not find a parent with given tag.
    }
}