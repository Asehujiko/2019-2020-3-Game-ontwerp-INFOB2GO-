using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Gun;
    public Camera Camera;
    public GameObject reticle;

    public LayerMask ignoreLayer;

    float maxRange = 500f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Weapon(Gun, reticle);
    }

    private void Weapon(GameObject Weapon, GameObject retical)
    {
        if (Weapon == null)
        {
            return;
        }

        Ray ray = new Ray();
        ray.origin = Weapon.transform.position;
        ray.direction = Weapon.transform.forward;

        RaycastHit hit;
        Vector3 hitlocation;
        if (Physics.Raycast(ray, out hit, maxRange, ~ignoreLayer))
        {
            hitlocation = hit.point;
        }
        else
        {
            hitlocation = Weapon.transform.forward * maxRange + Weapon.transform.position;
        }

        hitlocation = Camera.WorldToScreenPoint(hitlocation);

        retical.transform.position = hitlocation;
    }
}
