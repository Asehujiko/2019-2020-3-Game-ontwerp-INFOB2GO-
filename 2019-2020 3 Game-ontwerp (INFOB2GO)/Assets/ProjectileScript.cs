﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1);
    }

    void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
}
