using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public GameObject scrap;
    public List<GameObject> destroyedPats;
    public int health;
    bool dead;

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

    void die()
    {
        if (!dead)
        {
            dead = true;
            if (scrap != null)
            {
                Instantiate(scrap, transform.position, transform.rotation);
            }
            for (int i = 0; i < destroyedPats.Count; i++)
            {
                Instantiate(destroyedPats[i], transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
