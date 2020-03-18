using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbar : MonoBehaviour
{
    public GameObject overlay;
    public GameObject healthbar;
    public HealthController health;
    float overlaystart;
    float heathbarstart;
    public int maxoffset = 270;

    void Start()
    {
        overlaystart = overlay.transform.localPosition.x;
        heathbarstart = healthbar.transform.localPosition.x;
    }

    void Update()
    {
        float offset = (float)maxoffset - (float)maxoffset * ((float)health.health / (float)health.maxheath);
        overlay.transform.localPosition = new Vector3(overlaystart + offset, overlay.transform.localPosition.y, overlay.transform.localPosition.z);
        healthbar.transform.localPosition = new Vector3(heathbarstart - offset, healthbar.transform.localPosition.y, healthbar.transform.localPosition.z);
    }
}
