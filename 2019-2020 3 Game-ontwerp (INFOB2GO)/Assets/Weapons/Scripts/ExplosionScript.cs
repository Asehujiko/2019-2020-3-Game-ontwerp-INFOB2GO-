using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        GetComponent<AudioSource>().PlayOneShot(clip);
        GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(WaitDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale += new Vector3(+0.2f, +0.2f, +0.2f);

    }

    IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject, 0.05f);
    }
}