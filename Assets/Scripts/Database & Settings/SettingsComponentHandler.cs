using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsComponentHandler : MonoBehaviour
{
    [SerializeField] private string Name;
    
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
        EventsManager.current.onOpenPanelSettings += CheckDataBase;

        SetButton();
        SetSlider();
    }

    private void OnDisable()
    {
        EventsManager.current.onOpenPanelSettings -= CheckDataBase;
    }

    private void Update()
    {
        CheckButton();
        CheckTextSlider();
        CheckValueSlider();
    }

    private void CheckDataBase()
    {
        switch (Name)
        {
            case "Brightness":
                currentValue = Database.GetGameplay("Brightness");
                break;

            case "Sensitivity":
                currentValue = Database.GetGameplay("Sensitivity");
                break;

            case "VolumeMaster":
                currentValue = Database.GetAudio("Master");
                break;

            case "VolumeMusic":
                currentValue = Database.GetAudio("Music");
                break;

            case "VolumeEffect":
                currentValue = Database.GetAudio("Effect");
                break;
        }
    }

    public void SetDefaultValue(float value) => currentValue = value;

    #region Buttons
    public void SetButton()
    {
        btn_Decrement.onClick.AddListener(SetDecrementValueButton);
        btn_Increment.onClick.AddListener(SetIncrementValueButton);
    }

    public void SetIncrementValueButton() => currentValue += incrementValue;
    public void SetDecrementValueButton() => currentValue -= incrementValue;

    private void CheckButton()
    {
        btn_Decrement.interactable = slider_Value.value == minValue ? false : true;
        btn_Increment.interactable = slider_Value.value == maxValue ? false : true;
    }
    #endregion

    #region Slider
    public void SetSlider()
    {
        slider_Value.maxValue = maxValue;
        slider_Value.minValue = minValue;
        slider_Value.onValueChanged.AddListener((v) => currentValue = v) ;
    }

    private void CheckValueSlider() => slider_Value.value = currentValue;
    #endregion

    #region Text
    public void CheckTextSlider()
    {
        double finalNumbeer = System.Math.Round(currentValue,2);
        txt_value.text = finalNumbeer.ToString();
    }
    #endregion
}
