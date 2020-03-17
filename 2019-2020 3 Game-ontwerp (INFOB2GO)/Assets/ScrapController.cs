using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapController : MonoBehaviour
{
    public Rigidbody rigidbody;

    private void Start()
    {
        transform.position += new Vector3(0, 0.5f, 0);
        rigidbody.angularVelocity = new Vector3(0, 7.5f, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.transform.root.gameObject;
        PlayerController otherController = other.GetComponent<PlayerController>();

        if (otherController != null)
        {
            otherController.GetScrap();
            Destroy(gameObject);
        }
    }
}