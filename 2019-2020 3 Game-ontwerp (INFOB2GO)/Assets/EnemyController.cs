using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Vector3 location, rayOrigin;
    private float maxRange = 500f;

    public NavMeshAgent agent;

    private void Start()
    {
        rayOrigin = new Vector3(0.5f, 0.5f, 0f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Ray ray = Camera.main.ViewportPointToRay(rayOrigin);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxRange))
            {
                location = hit.point;
                agent.SetDestination(location);
            }
        }
    }


}
