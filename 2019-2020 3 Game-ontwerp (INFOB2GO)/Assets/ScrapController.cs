using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapController : MonoBehaviour
{
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