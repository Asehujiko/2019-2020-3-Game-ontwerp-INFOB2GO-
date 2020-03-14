using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeOnDamage : MonoBehaviour
{
    ParticleSystem ps;
    public float playerHealth = 10;//change to player health

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var main = ps.main;
        if(playerHealth <= 5.0f)
        {
            main.startSpeed = playerHealth;
            ps.enableEmission = true;
        }
        else
        {
            main.startSpeed = 5;
            ps.enableEmission = false;
        }
        
        
    }
}
