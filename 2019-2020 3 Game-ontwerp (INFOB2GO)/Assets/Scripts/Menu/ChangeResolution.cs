using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeResolution : MonoBehaviour
{
    public FullScreenMode fullscreenMode;

    public void Select800x600()
    {
        Screen.SetResolution(800, 600, fullscreenMode, 0);
    }

    public void Select1024x768()
    {
        Screen.SetResolution(1024, 768, fullscreenMode, 0);
    }

    public void Select1280x720()
    {
        Screen.SetResolution(1280, 720, fullscreenMode, 0);
    }

    public void Select1366x768()
    {
        Screen.SetResolution(1366, 768, fullscreenMode, 0);
    }

    public void Select1440x1080()
    {
        Screen.SetResolution(1440, 1080, fullscreenMode, 0);
    }

    public void Select1600x900()
    {
        Screen.SetResolution(1600, 900, fullscreenMode, 0);
    }

    public void Select1680x1050()
    {
        Screen.SetResolution(1680, 1050, fullscreenMode, 0);
    }

    public void  Select1920x1080()
    {
        Screen.SetResolution(1920, 1080, fullscreenMode, 0);
    }
}
