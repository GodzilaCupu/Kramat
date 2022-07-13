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

    [Header("Sound"), Space(5)]
    [SerializeField] private AudioMixer a_mainMixer;
    private string audioParameter_Master = "VolumeMaster";
    private string audioParameter_Effect = "VolumeEffect";
    private string audioParameter_Music = "VolumeMusic";

    private float f_vMaster;
    private float f_vEffect;
    private float f_vMusic;

    [Header("Graphic"), Space(5)]
    
    [SerializeField] private Toggle toggle_FullScreen;
    private bool Fullscreen_Mode;

    [SerializeField, Tooltip("0 = Prev, 1 = next")] private Button[] btn_quality;
    [SerializeField] private UniversalRenderPipelineAsset[] QualitySettings;
    [SerializeField] private TextMeshProUGUI t_quality;
    private int _qualityID = 1;

    [Header("Panel Configuration"), Space(10)]
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Scrollbar Scrolbar;
    [SerializeField] private Button btn_ResetConfig;
    [SerializeField] private Button btn_ExitPanel;

    [Header("Script Referance"), Space(10)]
    [SerializeField] private GameObject o_manager;

    private void Start()
    {
        Cursor.SetCursor(cursorSprite, Vector2.zero,CursorMode.Auto);
        SetGeneralButton();
        SetButtonQuality();
        SetToogleFullScreen();
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
        SetBrightness();
        SetSensitivity();
        MasterAudioSettings();
        EffectAudioSettings();
        MusicAudioSettings();
        CheckQuality();
    }

    private void GetValue()
    {
        // Check toogle + Quality BTN
        Fullscreen_Mode = Database.GetGraphic("FullScreen") == 1 ? true : false;
        SetFullScreen(Fullscreen_Mode);

        _qualityID = Database.GetGraphic("Quality");

        // Check Button Component
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
    private void SetGeneralButton()
    {
        btn_ExitPanel.onClick.AddListener(BackToPaused);
        btn_ResetConfig.onClick.AddListener(ResetConfig);
    }

    private void BackToPaused() => ActivationPanel(false);

    private void ResetConfig()
    {
        _qualityID = DefaultValue_Quality;
        toggle_FullScreen.isOn = DefaultValue_Fullscreen;

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
    }
    #endregion

    #region Panel Configuration;
    private void OpenPanel()
    {
        ActivationPanel(true);
        Scrolbar.value = 1;
    }

    private void ActivationPanel(bool isActive)
    {
        settingsPanel.SetActive(isActive);
        switch (isActive)
        {
            case true:
                GetValue();
                break;

            case false:
                CheckSettings();
                SaveData();
                break;
        } 
}
    #endregion

    #region Gameplay Configuration
    private void SetBrightness()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu") return;
        EventsManager.current.ChangeBrightness(f_brightness);
    }

    private void SetSensitivity()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu") return;
        EventsManager.current.ChangeSensitivy(f_sensitivity);
    }

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

    private void SetToogleFullScreen() => toggle_FullScreen.onValueChanged.AddListener((v) => SetFullScreen(v));

    private void SetFullScreen(bool v)
    {
        Screen.fullScreen = v;
        Fullscreen_Mode = v;
        Database.SetGraphic("FullScreen", Fullscreen_Mode ? 1 : 0);

        if (Fullscreen_Mode)
        {
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void SetButtonQuality()
    {
        btn_quality[0].onClick.AddListener(DecrementQuality);
        btn_quality[1].onClick.AddListener(IncrementQuality);
    }

    private void IncrementQuality() => _qualityID++;
    private void DecrementQuality() => _qualityID--;

    private void CheckQuality()
    {
        switch (_qualityID)
        {
            case 0:
                t_quality.text = "Low";
                btn_quality[0].interactable = false;
                btn_quality[1].interactable = true;

                GraphicsSettings.renderPipelineAsset = QualitySettings[_qualityID];
                break;

            case 1:
                t_quality.text = "Medium";
                btn_quality[1].interactable = true;
                btn_quality[0].interactable = true;
                GraphicsSettings.renderPipelineAsset = QualitySettings[_qualityID];
                break;

            case 2:
                t_quality.text = "High";
                btn_quality[0].interactable = true;
                btn_quality[1].interactable = false; 
                GraphicsSettings.renderPipelineAsset = QualitySettings[_qualityID];
                break;
        }
    
    }
    #endregion

    #region Save System
    public void SaveData()
    {
        // Gameplay
        Database.SetGameplay("Brightness", f_brightness);
        Database.SetGameplay("Sensitivity", f_sensitivity);

        // Audio
        Database.SetAudio("Master", f_vMaster);
        Database.SetAudio("Effect", f_vEffect);
        Database.SetAudio("Music", f_vMusic);

        // Graphic
        Database.SetGraphic("FullScreen", Fullscreen_Mode ? 1 : 0);
        Database.SetGraphic("Quality", _qualityID);
    }

    #endregion

}
