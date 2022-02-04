using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GraphicsHandler : MonoBehaviour
{
    [Header("DropDown Graphics")]
    [SerializeField] Dropdown[] dropdownsGraphics;

    [Header ("Resolution Parameter")]
    [SerializeField] Dropdown resolutionDropDown;
    [SerializeField] Resolution[] deviceResolutions;
    [SerializeField] Resolution currentResolution;
    [SerializeField] List<string> resolutionOptions = new List<string>();
    [SerializeField] int currentResolutionIndex;

    #region Resolutions
    public void ResolutionValue()
    {
        deviceResolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        currentResolutionIndex = 0;
        for (int i = 0; i < deviceResolutions.Length; i++)
        {
            string _resolutionOption = deviceResolutions[i].width + "x" + deviceResolutions[i].height;
            resolutionOptions.Add(_resolutionOption);

            if (deviceResolutions[i].width == Screen.currentResolution.width && deviceResolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        resolutionDropDown.AddOptions(resolutionOptions);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();

    }
    public void SetResolution(int index)
    {
        currentResolution = deviceResolutions[currentResolutionIndex];
        Screen.SetResolution(currentResolution.width, currentResolution.height, Screen.fullScreen);
    }
    #endregion

    #region Quality
    public void SetQuality(int index) => QualitySettings.SetQualityLevel(index);
    #endregion

    #region Mode
    public void SetMode(int index)
    {
        if (index > 0) SetFullScreen(true);
        else SetFullScreen(false);
    }
    void SetFullScreen(bool value) => Screen.fullScreen = value;
    #endregion
}