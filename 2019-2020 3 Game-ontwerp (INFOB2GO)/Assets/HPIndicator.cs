using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPIndicator : MonoBehaviour
{
    public HealthController health;
    public GameObject healthbar;
    public GameObject overlay;
    int currenthealth;
    int maxhealth;
    public int maxlength = 175;

    private void Start()
    {
        maxhealth = health.maxhealth;
        currenthealth = health.health;
    }

    void Update()
    {
        currenthealth = health.health;
        maxhealth = health.maxhealth;

        float offset = (float)maxlength -(float)maxlength * ((float)currenthealth / (float)maxhealth);
        overlay.transform.localPosition = new Vector3(offset, 0, 0);
        healthbar.transform.localPosition = new Vector3(-offset, 0, 0);
    }
}
