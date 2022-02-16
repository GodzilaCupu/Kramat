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

    public void SetGraphicValue()
    {
        ResolutionValue();
        QualityValue();
        ModeValue();

        dropdownsGraphics[0].onValueChanged.AddListener(delegate { SetResolution(dropdownsGraphics[0]); });

        dropdownsGraphics[1].onValueChanged.AddListener(delegate { SetQuality(dropdownsGraphics[1]); });

        dropdownsGraphics[2].onValueChanged.AddListener(delegate { SetMode(dropdownsGraphics[2]); });
    }

    #region Resolutions
    private void ResolutionValue()
    {
        deviceResolutions = Screen.resolutions;
        dropdownsGraphics[0] = resolutionDropDown;
        resolutionDropDown.ClearOptions();
        currentResolutionIndex = 0;
        for (int i = 0; i < deviceResolutions.Length; i++)
        {
            string _resolutionOption = deviceResolutions[i].width + " x " + deviceResolutions[i].height;
            resolutionOptions.Add(_resolutionOption);

            if (deviceResolutions[i].width == Screen.currentResolution.width && deviceResolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        resolutionDropDown.AddOptions(resolutionOptions);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();

    }
    private void SetResolution(Dropdown dropdown)
    {
        currentResolution = deviceResolutions[dropdown.value];
        Screen.SetResolution(currentResolution.width, currentResolution.height, Screen.fullScreen);

        Debug.Log("Resolusion" + currentResolution);
    }
    #endregion

    #region Quality
    private void QualityValue() => dropdownsGraphics[1].value = QualitySettings.GetQualityLevel();

    private void SetQuality(Dropdown dropdown) => QualitySettings.SetQualityLevel(dropdown.value);
    #endregion

    #region Mode
    public void SetMode(Dropdown dropdown)
    {
        int _index = dropdown.value;
        if (_index == 0) SetFullScreen(true);
        else SetFullScreen(false);
    }

    void ModeValue() => SetFullScreen(Screen.fullScreen);

    void SetFullScreen(bool value) => Screen.fullScreen = value;
    #endregion
}