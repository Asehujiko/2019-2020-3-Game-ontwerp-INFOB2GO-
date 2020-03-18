using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadHUDColor : MonoBehaviour
{
    // List with all the public GameObjects listed below which make up the HUD
    // Will be added to the list in Start()
    private List<GameObject> HUDList = new List<GameObject>();
    public GameObject CenterTarget;
    public GameObject TITurret;
    public GameObject TIBody;
    public GameObject TIKompas;
    public GameObject EIAbsolute;
    public GameObject EIRelative;
    public GameObject RIAbsolute;
    public GameObject RIRelative;
    public GameObject TI2Rotation;
    public GameObject TI2Body;
    public GameObject TI2Barrel;
    public GameObject TargetingReticle;
    public GameObject HP1;
    public GameObject HP21;
    public GameObject HP22;
    public GameObject HP23;
    public GameObject HP24;
    public GameObject HP25;
    public GameObject HP3;
    public GameObject HP41;
    public GameObject HP42;
    public GameObject HP43;
    public GameObject HP44;
    public GameObject HP45;
    public GameObject emergency;

    // The HUD color materials
    public Material Red;
    public Material Orange;
    public Material Yellow;
    public Material Green;
    public Material Cyan;
    public Material Blue;
    public Material Purple;
    public Material Pink;
    

    // Start is called before the first frame update
    void Start()
    {
        HUDList.Add(CenterTarget);
        HUDList.Add(TITurret);
        HUDList.Add(TIBody);
        HUDList.Add(TIKompas);
        HUDList.Add(EIAbsolute);
        HUDList.Add(EIRelative);
        HUDList.Add(RIAbsolute);
        HUDList.Add(RIRelative);
        HUDList.Add(TI2Rotation);
        HUDList.Add(TI2Body);
        HUDList.Add(TI2Barrel);
        HUDList.Add(TargetingReticle);
        HUDList.Add(HP1);
        HUDList.Add(HP21);
        HUDList.Add(HP22);
        HUDList.Add(HP23);
        HUDList.Add(HP24);
        HUDList.Add(HP25);
        HUDList.Add(HP3);
        HUDList.Add(HP41);
        HUDList.Add(HP42);
        HUDList.Add(HP43);
        HUDList.Add(HP44);
        HUDList.Add(HP45);
        HUDList.Add(emergency);

        if (PlayerPrefs.GetString("HUDColor") == "Red")
        {
            foreach (GameObject HUDElement in HUDList)
            {
                HUDElement.GetComponent<Image>().material = Red;
            }
        }

        if (PlayerPrefs.GetString("HUDColor") == "Orange")
        {
            foreach (GameObject HUDElement in HUDList)
            {
                HUDElement.GetComponent<Image>().material = Orange;
            }
        }

        if (PlayerPrefs.GetString("HUDColor") == null || PlayerPrefs.GetString("HUDCOlor") == "Yellow")
        {
            foreach (GameObject HUDElement in HUDList)
            {
                HUDElement.GetComponent<Image>().material = Yellow;
            }
        }

        if (PlayerPrefs.GetString("HUDColor") == "Green")
        {
            foreach (GameObject HUDElement in HUDList)
            {
                HUDElement.GetComponent<Image>().material = Green;
            }
        }

        if (PlayerPrefs.GetString("HUDColor") == "Cyan")
        {
            foreach (GameObject HUDElement in HUDList)
            {
                HUDElement.GetComponent<Image>().material = Cyan;
            }
        }

        if (PlayerPrefs.GetString("HUDColor") == "Blue")
        {
            foreach (GameObject HUDElement in HUDList)
            {
                HUDElement.GetComponent<Image>().material = Blue;
            }
        }

        if (PlayerPrefs.GetString("HUDColor") == "Purple")
        {
            foreach (GameObject HUDElement in HUDList)
            {
                HUDElement.GetComponent<Image>().material = Purple;
            }
        }

        if (PlayerPrefs.GetString("HUDColor") == "Pink")
        {
            foreach (GameObject HUDElement in HUDList)
            {
                HUDElement.GetComponent<Image>().material = Pink;
            }
        }
    }
}
