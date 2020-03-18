using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public void RedOnClick()
    {
        PlayerPrefs.SetString("HUDColor", "Red");
    }

    public void OrangeOnClick()
    {
        PlayerPrefs.SetString("HUDColor", "Orange");
    }

    public void YellowOnClick()
    {
        PlayerPrefs.SetString("HUDColor", "Yellow");
    }

    public void GreenOnClick()
    {
        PlayerPrefs.SetString("HUDColor", "Green");
    }

    public void CyanOnClick()
    {
        PlayerPrefs.SetString("HUDColor", "Cyan");
    }

    public void BlueOnClick()
    {
        PlayerPrefs.SetString("HUDColor", "Blue");
    }

    public void PurpleOnClick()
    {
        PlayerPrefs.SetString("HUDColor", "Purple");
    }

    public void PinkOnClick()
    {
        PlayerPrefs.SetString("HUDColor", "Pink");
    }
}
