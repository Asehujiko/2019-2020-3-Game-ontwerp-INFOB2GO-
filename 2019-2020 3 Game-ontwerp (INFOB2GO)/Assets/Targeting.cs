using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PrimaryWeapon;
    public GameObject SecondaryWeapon;
    public GameObject TertiaryWeapon;
    public GameObject CameraRotator;
    public Camera Camera;
    public GameObject retical;

    float maxRange = 500f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Weapon(GameObject Weapon)
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
        if (Physics.Raycast(ray, out hit, maxRange))
        {
            hitlocation = hit.point;
        }
        else
        {
            hitlocation = Weapon.transform.forward * maxRange;
        }

        hitlocation = new Vector3(hitlocation.x - CameraRotator.transform.position.x, hitlocation.y - CameraRotator.transform.position.y, hitlocation.z - CameraRotator.transform.position.z);
        hitlocation = Quaternion.Inverse(CameraRotator.transform.rotation) * hitlocation;

        retical.transform.localPosition = hitlocation;
    }
}
