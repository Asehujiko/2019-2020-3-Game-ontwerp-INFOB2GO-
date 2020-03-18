using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public GameObject scrap;
    public List<GameObject> destroyedParts;
    public int health;
    public int maxhealth;
    protected bool dead;

    public void setHealth(int health)
    {
        this.health = health;
    }

    public void getHit(int damage)
    {
        health -= damage;
        if (health <= 0)
            die();
    }

    public virtual void die()
    {
        if (!dead)
        {
            dead = true;
            if (scrap != null)
            {
                Instantiate(scrap, transform.position, transform.rotation);
            }
            for (int i = 0; i < destroyedParts.Count; i++)
            {
                Instantiate(destroyedParts[i], transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}