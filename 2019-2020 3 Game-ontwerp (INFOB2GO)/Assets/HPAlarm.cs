using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPAlarm : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip alarm;
    public Image r;
    int counter;
    float timer;
    bool goalarm;

    private void Start()
    {
        counter = 0;
        timer = 0;
        r.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (goalarm)
        {
            if (counter > 4)
            {
                goalarm = false;
                counter = 0;
                timer = 0;
                return;
            }
            timer += Time.deltaTime;
            if (timer > 0.5f)
            {
                timer = 0;
                r.enabled = !r.enabled;
                if (!r.enabled)
                {
                    counter++;
                }
            }
        }
    }

    public void Alarm()
    {
        audioSource.PlayOneShot(alarm);
        goalarm = true;
    }
}
