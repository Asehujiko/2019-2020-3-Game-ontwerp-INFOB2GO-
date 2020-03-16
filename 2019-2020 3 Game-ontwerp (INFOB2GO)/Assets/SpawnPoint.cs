using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject seepoint;
    private PlayerController player;
    private float maxRange = 500f;
    public GameObject Enemy;

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
        Collider[] objects = Physics.OverlapBox(transform.position + new Vector3(0, 1, 0), new Vector3(1, 1, 1.5f));
        for (int i = 0; i < objects.Length; i++)
        {
            Debug.DrawLine(objects[i].transform.position, objects[i].transform.position + new Vector3(0, 1, 0), Color.red);
            HealthController otherController = objects[i].gameObject.transform.root.GetComponent<HealthController>();

            if (otherController != null)
                return false;

            //Destroy(objects[i]);
        }

        if (player == null)
        {
            return true;
        }

        seepoint.transform.LookAt(player.transform.position);
        Ray ray = new Ray();
        ray.origin = seepoint.transform.position;
        ray.direction = seepoint.transform.forward;

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxRange))
        {
            GameObject hitobject = hit.collider.transform.root.gameObject;
            PlayerController isplayer = hitobject.GetComponent<PlayerController>();
            if (isplayer != null)
            {
                return false;
            }
            return true;
        }
        return true;
    }
}
