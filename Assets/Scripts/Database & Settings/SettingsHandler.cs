using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public enum enum_SettingsComponent
{
    Brightness,
    Sensitivity,
    VolumeMaster,
    VolumeMusic,
    VolumeEffect,
    FullScreen,
    Quality
}

public class SettingsHandler : MonoBehaviour
{
    [Header("Cursor")]
    [SerializeField] private Texture2D cursorSprite;

    [Header("Content Configuration"), Space(10)]
    [SerializeField] private List<SettingsComponentHandler> componenets;

    [Header("Value Default"), Space(10)]
    [SerializeField] private int DefaultValue_Quality;
    [SerializeField] private bool DefaultValue_Fullscreen;
    [SerializeField] private float DefaultValue_Brightness;
    [SerializeField] private float DefaultValue_Sensitivity;
    [SerializeField] private float DefaultValue_VolumeMaster;
    [SerializeField] private float DefaultValue_VolumeMusic;
    [SerializeField] private float DefaultValue_VolumeEffect;

    [Header("Gameplay"), Space(10)]
    private float f_brightness;
    private float f_sensitivity;

    public float BrightnessData { get { return f_brightness; } set { f_brightness = value; } }
    public float SensitivityData { get { return f_sensitivity; } set { f_sensitivity = value; } }

    [Header("Sound"), Space(5)]
    [SerializeField] private AudioMixer a_mainMixer;
    private string audioParameter_Master = "VolumeMaster";
    private string audioParameter_Effect = "VolumeEffect";
    private string audioParameter_Music = "VolumeMusic";

    private float f_vMaster;
    private float f_vEffect;
    private float f_vMusic;

    private float _audioMin = 0.0001f;
    private float _audioMax = 1f;

    public float VolumeMasterData { get { return f_vMaster; } set { f_vMaster = value; } }
    public float VolumeMusicData { get { return f_vEffect; } set { f_vEffect = value; } }
    public float VolumeEffectData { get { return f_vMusic; } set { f_vMusic = value; } }


    [Header("Graphic"), Space(5)]
    [SerializeField] private Toggle toggle_FullScreen;
    private bool Fullscreen_Mode;
    public bool isFullscreen { get { return Fullscreen_Mode; } set { Fullscreen_Mode = value; } }

    [SerializeField] private UniversalRenderPipelineAsset[] QualitySettings;
    [SerializeField, Tooltip("0 = Prev, 1 = next")] private Button[] btn_quality;
    [SerializeField] private TextMeshProUGUI t_quality;
    private int _qualityID = 1;
    public int QualityID { get { return _qualityID; } set { _qualityID = value; } }

    [Header("Panel Configuration"), Space(10)]
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Button btn_ResetConfig;
    [SerializeField] private Button btn_ExitPanel;
    [SerializeField] private Scrollbar Scrolbar;

    [Header("Script Referance"), Space(10)]
    [SerializeField] private GameObject o_manager;
    [SerializeField] private SettingsData _data;

    private void Start()
    {
        Cursor.SetCursor(cursorSprite, Vector2.zero,CursorMode.Auto);
        if (!settingsPanel.activeInHierarchy)
        {
            settingsPanel.SetActive(true);
            GetValue();
            settingsPanel.SetActive(false);
        }
        SetButton();
        EventsManager.current.onOpenPanelSettings += OpenPanel;
    }

    private void OnDisable()
    {
        EventsManager.current.onOpenPanelSettings -= OpenPanel;
    }

    private void Update()
    {
        CheckSettings();
    }

    private void CheckSettings()
    {
        BrightnessSettings();
        SensitivitySettings();
        MasterAudioSettings();
        EffectAudioSettings();
        MusicAudioSettings();
        FullScreenModeSettings();
        CheckQuality(_qualityID);
    }

    private void GetValue()
    {
        Fullscreen_Mode = toggle_FullScreen.isOn ? true : false;
        switch (t_quality.text.ToString())
        {
            case "Low":
                _qualityID = 0;
                break;

            case "Medium":
                _qualityID = 1;
                break;

            case "High":
                _qualityID = 2;
                break;
        }

        for (int i = 0; i < componenets.Count; i++)
        {
            switch (i)
            {
                case ((int)enum_SettingsComponent.Brightness):
                    f_brightness = componenets[((int)enum_SettingsComponent.Brightness)].Value;
                    break;

                case ((int)enum_SettingsComponent.Sensitivity):
                    f_sensitivity = componenets[((int)enum_SettingsComponent.Sensitivity)].Value;
                    break;

                case ((int)enum_SettingsComponent.VolumeMaster):
                    f_vMaster = componenets[((int)enum_SettingsComponent.VolumeMaster)].Value;
                    break;

                case ((int)enum_SettingsComponent.VolumeMusic):
                    f_vMusic = componenets[((int)enum_SettingsComponent.VolumeMusic)].Value;
                    break;

                case ((int)enum_SettingsComponent.VolumeEffect):
                    f_vEffect = componenets[((int)enum_SettingsComponent.VolumeEffect)].Value;
                    break;
            }
        }
    }

    #region Reset & Close Button
    private void SetButton()
    {
        btn_ExitPanel.onClick.AddListener(BackToPaused);
        btn_ResetConfig.onClick.AddListener(ResetConfig);
    }


    private void BackToPaused()
    {
        ActivationPanel(false);
    }

    private void ResetConfig()
    {
        _qualityID = DefaultValue_Quality;
        Fullscreen_Mode = DefaultValue_Fullscreen;

        for (int i = 0; i < componenets.Count; i++)
        {
            switch (i)
            {
                case ((int)enum_SettingsComponent.Brightness):
                    componenets[((int)enum_SettingsComponent.Brightness)].SetDefaultValue(DefaultValue_Brightness);
                    break;

                case ((int)enum_SettingsComponent.Sensitivity):
                    componenets[((int)enum_SettingsComponent.Sensitivity)].SetDefaultValue(DefaultValue_Sensitivity);
                    break;

                case ((int)enum_SettingsComponent.VolumeMaster):
                    componenets[((int)enum_SettingsComponent.VolumeMaster)].SetDefaultValue(DefaultValue_VolumeMaster);
                    break;

                case ((int)enum_SettingsComponent.VolumeMusic):
                    componenets[((int)enum_SettingsComponent.VolumeMusic)].SetDefaultValue(DefaultValue_VolumeMusic);
                    break;

                case ((int)enum_SettingsComponent.VolumeEffect):
                    componenets[((int)enum_SettingsComponent.VolumeEffect)].SetDefaultValue(DefaultValue_VolumeEffect);
                    break;
            }
        }

        SaveDataSettings();
    }

    #endregion

    #region Panel Configuration;
    private void OpenPanel()
    {
        ActivationPanel(true);
        CheckDatabase();
        Scrolbar.value = 1;
    }

    private void ActivationPanel(bool isActive)
    {
        settingsPanel.SetActive(isActive);
        SaveDataSettings(); 
        GetValue();
}
    #endregion

    #region Gameplay Configuration
    private void BrightnessSettings() => EventsManager.current.ChangeBrightness(f_brightness);

    private void SensitivitySettings() => EventsManager.current.ChangeSensitivy(f_sensitivity);
    #endregion

    #region Sound Configuration
    private void MasterAudioSettings() => a_mainMixer.SetFloat(audioParameter_Master, Mathf.Log10(componenets[((int)enum_SettingsComponent.VolumeMaster)].Value) * 20);
    private void MusicAudioSettings() 
    {
        a_mainMixer.SetFloat(audioParameter_Music, Mathf.Log10(componenets[((int)enum_SettingsComponent.VolumeMusic)].Value) * 20);
        componenets[((int)enum_SettingsComponent.VolumeEffect)].MaxValue = f_vMaster;
    }

    private void EffectAudioSettings() => a_mainMixer.SetFloat(audioParameter_Effect, Mathf.Log10(componenets[((int)enum_SettingsComponent.VolumeEffect)].Value) * 20);
    #endregion

    #region Graphic Configuration

    private void FullScreenModeSettings() => toggle_FullScreen.onValueChanged.AddListener((v) => SetFullScreen(v));

    private void SetFullScreen(bool v)
    {
        Screen.fullScreen = v;
        Fullscreen_Mode = v;
    }

    public void IncrementQuality() => _qualityID++;
    public void DecrementQuality() => _qualityID--;

    private void CheckQuality(int value)
    {
        switch (value)
        {
            case 0:
                t_quality.text = "Low";
                btn_quality[0].interactable = false;
                btn_quality[1].interactable = true;

                GraphicsSettings.renderPipelineAsset = QualitySettings[value];
                break;

            case 1:
                t_quality.text = "Medium";
                btn_quality[1].interactable = true;
                btn_quality[0].interactable = true;
                GraphicsSettings.renderPipelineAsset = QualitySettings[value];
                break;

            case 2:
                t_quality.text = "High";
                btn_quality[0].interactable = true;
                btn_quality[1].interactable = false; 
                GraphicsSettings.renderPipelineAsset = QualitySettings[value];
                break;
        }
    
    }
    #endregion

    #region Save System
    public void SaveDataSettings() => Save_Data.SaveSettings(this);

    public void CheckDatabase()
    {
        SettingsData data = Save_Data.LoadSettings();
        isFullscreen = data.Fullscreen_Mode;
        QualityID = data._qualityID;
        _data = data;
        Debug.Log($"Check DataBase for Quality && Fullscreen");
    }
    #endregion

}
