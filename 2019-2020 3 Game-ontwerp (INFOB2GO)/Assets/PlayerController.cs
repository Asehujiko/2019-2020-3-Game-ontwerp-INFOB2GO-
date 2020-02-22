using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float rotationSpeed = 10f;
    public float CannonROF = 10f;
    public float GatlingROF = 100f;

    public GameObject cannonball;
    public GameObject gatlingbullet;
    public GameObject leftCannonEmitter;
    public GameObject rightCannonEmitter;

    float lastFired = 0;

    void Update()
    {
        lastFired += Time.deltaTime;

        transform.Translate(0, 0, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);

        if (Input.GetMouseButton(0) && lastFired > 1 / CannonROF)
        {
            GameObject leftCannonBall = Instantiate(cannonball, leftCannonEmitter.transform.position, leftCannonEmitter.transform.rotation) as GameObject;
            GameObject rightCannonBall = Instantiate(cannonball, rightCannonEmitter.transform.position, rightCannonEmitter.transform.rotation) as GameObject;

            leftCannonBall.GetComponent<Rigidbody>().AddRelativeForce(0, 5000, 0);
            rightCannonBall.GetComponent<Rigidbody>().AddRelativeForce(0, 5000, 0);

            lastFired = 0;
        }

        else if (Input.GetMouseButton(1) && lastFired > 1 / GatlingROF)
        {
            GameObject leftCannonBall = Instantiate(gatlingbullet, leftCannonEmitter.transform.position, leftCannonEmitter.transform.rotation) as GameObject;
            GameObject rightCannonBall = Instantiate(gatlingbullet, rightCannonEmitter.transform.position, rightCannonEmitter.transform.rotation) as GameObject;

            leftCannonBall.GetComponent<Rigidbody>().AddRelativeForce(Random.Range(-100f, 100f), 2500, Random.Range(-100f, 100f));
            rightCannonBall.GetComponent<Rigidbody>().AddRelativeForce(Random.Range(-100f, 100f), 2500, Random.Range(-100f, 100f));

            lastFired = 0;
        }
    }
}