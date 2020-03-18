using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
        AudioSource audio = GetComponent<AudioSource>();
        GetComponent<AudioSource>().PlayOneShot(clip);
    }

    IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject, 0.5f);
    }
}