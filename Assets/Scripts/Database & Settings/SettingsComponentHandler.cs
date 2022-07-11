using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsComponentHandler : MonoBehaviour
{
    [SerializeField] private string Name;
    [SerializeField] private SettingsData _data;
    
    [Header("Value"),Space(10)]
    [SerializeField] private float incrementValue;
    [SerializeField] private float currentValue;
    [SerializeField] private float maxValue;
    [SerializeField] private float minValue;
    public float Value { get {return currentValue; } set { currentValue = value; } }
    public float MaxValue { get {return maxValue; } set { maxValue = value; } }
    public float MinValue { get {return minValue; } set { minValue = value; } }

    [Header("Button"), Space(10)]
    [SerializeField] private Button btn_Decrement;
    [SerializeField] private Button btn_Increment;

    [Header("Slider"), Space(10)]
    [SerializeField] private Slider slider_Value;

    [Header("Input Field"), Space(10)]
    [SerializeField] private TextMeshProUGUI txt_value;

    // Start is called before the first frame update
    void Start()
    {
        SetButton();
        SetValueSlider();
        CheckTextValue();
        CheckValueSlider();
        EventsManager.current.onOpenPanelSettings += CheckDataBase;
    }

    private void OnDisable()
    {
        EventsManager.current.onOpenPanelSettings -= CheckDataBase;
    }

    private void CheckDataBase()
    {
        SettingsData data = Save_Data.LoadSettings();
        switch (Name)
        {
            case "Brightness":
                currentValue = data.brightnesData;
                break;

            case "Sensitivity":
                currentValue = data.sensitivityData;
                break;

            case "VolumeMaster":
                currentValue = data.vMasterData;
                break;

            case "VolumeMusic":
                currentValue = data.vEffectData;
                break;

            case "VolumeEffect":
                currentValue = data.vMusicData;
                break;
        }
        _data = data;
        Debug.Log($"Check DataBase for {Name}");
    }

    public void SetDefaultValue(float value) => currentValue = value;

    #region Buttons
    public void SetButton()
    {
        btn_Decrement.onClick.AddListener(SetDecrementValueButton);
        btn_Increment.onClick.AddListener(SetIncrementValueButton);
    }

    private void CheckButton()
    {
        btn_Decrement.interactable = slider_Value.value == minValue ? false : true;
        btn_Increment.interactable = slider_Value.value == maxValue ? false : true;
    }

    public void SetIncrementValueButton()
    {
        currentValue += incrementValue;
        CheckValueSlider();
    }
    public void SetDecrementValueButton()
    {
        currentValue -= incrementValue;
        CheckValueSlider();
    }
    #endregion

    #region Slider
    public void SetValueSlider()
    {
        slider_Value.maxValue = maxValue;
        slider_Value.minValue = minValue;
        slider_Value.onValueChanged.AddListener(GetValueChangeSlider);
    }

    private void GetValueChangeSlider(float input)
    {
        currentValue = input;
        CheckTextValue();
        CheckButton();
    }

    private void CheckValueSlider() => slider_Value.value = currentValue;
    #endregion

    #region Text
    public void CheckTextValue()
    {
        double finalNumbeer = System.Math.Round(currentValue,2);
        txt_value.text = finalNumbeer.ToString();
    }
    #endregion
}
