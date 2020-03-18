﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcRendererScript : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.05f);
    }

    public void createArc(Vector3 target)
    {
        LineRenderer arcRenderer = gameObject.AddComponent<LineRenderer>();
        arcRenderer.SetPosition(0, transform.position);
        arcRenderer.SetPosition(1, target);
        arcRenderer.startColor = Color.cyan;
        arcRenderer.endColor = Color.blue;
        arcRenderer.startWidth = 0.1f;
        arcRenderer.endWidth = 0.1f;
    }
}