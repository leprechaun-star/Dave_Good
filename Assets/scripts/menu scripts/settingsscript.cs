using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class settingsscript : MonoBehaviour
{
    public void Start()
    {
        Resolution[] resolutions = Screen.resolutions;
    }


    public void fullscreen()
    {
        // Toggle fullscreen
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void Res768p()
    {
        //768p in resolution
        Screen.SetResolution(1366, 798, true);
    }
    public void Res900p()
    {
        //900p in resolution
        Screen.SetResolution(1600, 900, true);
    }

    public void Res1080p()
    {
        //1080p in resolution
        Screen.SetResolution(1920, 1080, true);
    }

    public void Res2K()
    {
        //2K resolution
        Screen.SetResolution(2560, 1440, true);
    }

    public void SetQuality(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
    }
}
