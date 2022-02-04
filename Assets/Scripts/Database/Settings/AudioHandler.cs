using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] AudioMixer mainMixer;
    [SerializeField] float soundMultiplier = 45f;

    [SerializeField] Slider[] audioSlider;

    public void SetAudioValue()
    {
        for (int i = 0; i < audioSlider.Length; i++)
            switch (i)
            {
                case 0:
                    GetAudioData(0, "Master");
                    audioSlider[0].onValueChanged.AddListener(CalculationMasterValue);
                    break;

                case 1:
                    GetAudioData(1, "Bgm");
                    audioSlider[1].onValueChanged.AddListener(CalculationBGMValue);
                    break;

                case 2:
                    GetAudioData(2, "Sfx");
                    audioSlider[2].onValueChanged.AddListener(CalculationSFXValue);
                    break;
            }
    }

    public void OnPanelClose()
    {
        SaveAudioData(0, "Master");
        SaveAudioData(1, "Bgm");
        SaveAudioData(2, "Sfx");
    }

    public void GetAudioData(int indexSlider, string databaseKey) => audioSlider[indexSlider].value = Data.GetSettings(databaseKey);

    public void SaveAudioData(int indexSlider, string databaseKey) => Data.SetSettings(databaseKey, audioSlider[indexSlider].value);

    public void CalculationMasterValue(float value) => mainMixer.SetFloat("Master_Volume", Mathf.Log10(value) * soundMultiplier);

    public void CalculationBGMValue(float value) => mainMixer.SetFloat("BGM_Volume", Mathf.Log10(value) * soundMultiplier);

    public void CalculationSFXValue(float value) => mainMixer.SetFloat("SFX_Volume", Mathf.Log10(value) * soundMultiplier);
}
