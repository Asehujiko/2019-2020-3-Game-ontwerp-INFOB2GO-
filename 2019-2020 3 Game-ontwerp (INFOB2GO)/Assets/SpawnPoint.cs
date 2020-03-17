using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject[] seepoints;
    public LayerMask ignoreLayer;
    private PlayerController player;
    private float maxRange = 500f;
    public GameObject Enemy;
    private Camera camera;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void Spawn()
    {
        Instantiate(Enemy, transform.position, transform.rotation);
    }

    public bool AreaClear()
    {
        player = FindObjectOfType<PlayerController>();
        Collider[] objects = Physics.OverlapBox(transform.position + new Vector3(0, 1, 0), new Vector3(1, 1, 1.5f));
        for (int i = 0; i < objects.Length; i++)
        {
            HealthController otherController = objects[i].gameObject.transform.root.GetComponent<HealthController>();

            if (otherController != null)
                return false;

            //Destroy(objects[i]);
        }

        if (player == null)
        {
            return true;
        }
        camera = Camera.main;

        if (Vector3.Distance(transform.position, player.transform.position) < 40)
        {
            return false;
        }

        for (int i = 0; i < seepoints.Length; i++)
        {
            seepoints[i].transform.LookAt(camera.transform.position);
            Ray ray = new Ray();
            ray.origin = seepoints[i].transform.position;
            ray.direction = seepoints[i].transform.forward;

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxRange, ~ignoreLayer))
            {
                GameObject hitobject = hit.collider.transform.root.gameObject;
                PlayerController isplayer = hitobject.GetComponent<PlayerController>();
                if (isplayer != null)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
