using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Volume))]
public class SwitchingPostProHandler : MonoBehaviour
{
    [Header("Scene")]
    [SerializeField] private Scene currentScene;
    private int idScene;

    [Header("Fog Component"),Space(10)]
    [SerializeField] private bool isOn_Fog;
    [SerializeField] private ForwardRendererData fr_data;
    [SerializeField] private ScriptableRendererFeature[] features;
    [SerializeField] private ScriptableRendererFeature[] FeaturesData;
    private ScriptableRendererFeature feature;

    [Header("Pos Pro Component")]
    [SerializeField] private bool isOn_PosPro;
    [SerializeField] private Volume posProData;

    [SerializeField] private ColorAdjustments color;

    [SerializeField] private VolumeProfile[] posProProfileData;

    // Start is called before the first frame update
    private void Start()
    {
        posProData = GetComponent<Volume>();
        features = fr_data.rendererFeatures.ToArray();
        feature = features[0];
        CheckScene(SceneManager.GetActiveScene());
        GetBrightness();

        EventsManager.current.onChangeBrightness += CheckBrightness;
    }

    private void OnDisable()
    {
        EventsManager.current.onChangeBrightness -= CheckBrightness;
    }


    private void CheckScene(Scene thisScene)
    {
        currentScene = thisScene;
        string name = currentScene.name;
        switch (name)
        {
            case "Tutorial":
                SetFog(1);
                SetPosPro(1);
                break;

            case "Wetan":
                SetFog(2);
                SetPosPro(2);
                break;

            case "Kulon":
                SetFog(3);
                SetPosPro(3);
                break;

            case "BosFight":
                SetFog(4);
                SetPosPro(4);
                break;

            default:
                SetFog(2);
                SetPosPro(2);
                break;
        }
    }

    private void SetFog(int id)
    {
        switch (id)
        {
            case 1:
                isOn_Fog = true;
                ChangeFog(0);
                break;

            case 2:
                isOn_Fog = false;
                break;

            case 3:
                isOn_Fog = true;
                ChangeFog(1);
                break;

            case 4:
                isOn_Fog = true;
                ChangeFog(2);
                break;
        }
        ActivationFog(isOn_Fog);
    }

    private void SetPosPro(int id)
    {
        switch (id)
        {
            case 1:
                isOn_PosPro = true;
                ChangePosPro(0);
                break;

            case 2:
                isOn_PosPro = true;
                ChangePosPro(1);
                break;

            case 3:
                isOn_PosPro = true;
                ChangePosPro(2);
                break;

            case 4:
                isOn_PosPro = true;
                ChangePosPro(3);
                break;
        }
        ActivationPosPro(isOn_PosPro);
    }

    private void ActivationFog(bool isOn) => feature.SetActive(isOn);
    private void ChangeFog(int id)
    {
        fr_data.rendererFeatures.Clear();
        feature = FeaturesData[id];
        fr_data.rendererFeatures.Add(feature);
    }

    private void ActivationPosPro(bool isOn) => posProData.enabled = isOn;
    private void ChangePosPro(int id) => posProData.profile = posProProfileData[id];
    private void CheckBrightness(float value) => color.postExposure.value = value;
    private void GetBrightness()
    {
        ColorAdjustments tmp;
        if (posProData.profile.TryGet<ColorAdjustments>(out tmp))
            color = tmp;

    }

}
