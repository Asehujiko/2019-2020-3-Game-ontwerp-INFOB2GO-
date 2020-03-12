using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Turret;
    public GameObject Body;
    public GameObject TurretSprite;
    public GameObject BodySprite;
    private bool active;
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

        transform.position = new Vector3(Screen.width - 100, 100, 0);

        float turretRotation = Turret.transform.eulerAngles.y;
        TurretSprite.transform.rotation = Quaternion.Euler(0, 0, -turretRotation);

        float bodyRotation = Body.transform.eulerAngles.y;
        BodySprite.transform.rotation = Quaternion.Euler(0, 0, -bodyRotation);
    }
}