using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPIndicator : MonoBehaviour
{
    public HealthController health;
    public GameObject healthbar;
    Vector3 startposition;
    Vector3 healthstartposition;
    int currenthealth;
    int maxhealth;
    public int maxlength = 175;

    private void Start()
    {
        healthstartposition = healthbar.transform.localPosition;
        startposition = transform.position;
        maxhealth = health.maxhealth;
        currenthealth = health.health;
    }

    void Update()
    {
        currenthealth = health.health;
        maxhealth = health.maxhealth;

        float offset = (float)maxlength -(float)maxlength * ((float)currenthealth / (float)maxhealth);
        transform.position = new Vector3(offset + startposition.x, transform.position.y, transform.position.z);
        healthbar.transform.localPosition = healthstartposition + new Vector3(-offset, 0, 0);
    }
}
