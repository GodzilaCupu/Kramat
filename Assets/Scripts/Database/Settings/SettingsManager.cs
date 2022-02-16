using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SettingsManager : MonoBehaviour
{
    [Header("Script Reference")]
    [SerializeField] TabGroupSettings tabGroupScript;
    [SerializeField] GraphicsHandler _graphics => this.gameObject.GetComponent<GraphicsHandler>();
    [SerializeField] AudioHandler _audio => this.gameObject.GetComponent<AudioHandler>();

    [Header("Settings")]
    public Text titleSettings;
    public string[] stringTitleSettings = {"Gameplay","Audio","Graphics", "Settings" };
    [SerializeField] Button btnCloseSettings;

    public void SettingsValue()
    {
        _graphics.SetGraphicValue();
        _audio.SetAudioValue();
        btnCloseSettings.onClick.AddListener(CloseSettingsPanel);
    }

    public void CloseSettingsPanel()
    {
        _audio.OnPanelClose();
        TitleSettingChanger(3);
        PanelSettingsActivation(false);
    }

    public void OpenSettingsPanel()
    {
        PanelSettingsActivation(true);
        TitleSettingChanger(3);
        tabGroupScript.ResetTab();
    }

    public void TitleSettingChanger(int index) => titleSettings.text = stringTitleSettings[index];
    public void PanelSettingsActivation(bool value) => this.gameObject.SetActive(value);
}
