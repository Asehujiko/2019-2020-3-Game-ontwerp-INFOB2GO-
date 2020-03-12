using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankIndicator2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Body;
    public GameObject Barrel;
    public GameObject BodySprite;
    public GameObject BarrelSprite;

    bool active;
    void Start()
    {
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        bool prevactive = active;
        active = Screen.width > 1000;
        if (prevactive != active)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(active);
            }
        }
        if (!active)
        {
            return;
        }

        transform.position = new Vector3(100, 100, 0);

        float bodyRotation = Body.transform.eulerAngles.x;
        BodySprite.transform.localRotation = Quaternion.Euler(0, 0, -bodyRotation);
        float barrelRotation = Barrel.transform.localEulerAngles.x;
        BarrelSprite.transform.localRotation = Quaternion.Euler(0, 0, -barrelRotation);
    }
}
