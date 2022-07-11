using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingsData
{
    [Header("Gameplay")]
    public float brightnesData;
    public float sensitivityData;

    [Header("Sound"), Space(5)]
    public float vMasterData;
    public float vEffectData;
    public float vMusicData;

    [Header("Graphic"), Space(5)]
    public bool Fullscreen_Mode;
    public int _qualityID;

    public SettingsData(SettingsHandler Settings)
    {
        brightnesData = Settings.BrightnessData;
        sensitivityData = Settings.SensitivityData;

        vMasterData = Settings.VolumeMasterData;
        vEffectData = Settings.VolumeEffectData;
        vMusicData = Settings.VolumeMusicData;

        Fullscreen_Mode = Settings.isFullscreen;
        _qualityID = Settings.QualityID;
    }
}
