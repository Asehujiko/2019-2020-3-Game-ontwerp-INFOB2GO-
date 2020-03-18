using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVelocity : MonoBehaviour
{
    // Start is called before the first frame update
    public float randomniss;
    public float velocity;
    public float rotation;
    public Vector3 direction;
    public Rigidbody rigidbody;
    void Start()
    {
        if (rigidbody != null)
        {
            rigidbody.velocity = transform.rotation * new Vector3((direction.x + Random.Range(0, randomniss)) * velocity, (direction.y + Random.Range(0, randomniss)) * velocity, (direction.z + Random.Range(0, randomniss)) * velocity);
            rigidbody.angularVelocity = new Vector3(rotation + Random.Range(0, randomniss), rotation + Random.Range(0, randomniss), rotation + +Random.Range(0, randomniss));
        }
    }

}
