using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeOnDamage : MonoBehaviour
{
    ParticleSystem ps;
    ParticleSystem.MainModule main;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        main = ps.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
