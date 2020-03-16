using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject scrap;
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
        if(!dead)
        {
            dead = true;
            Instantiate(scrap, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
