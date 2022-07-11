using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FogTest : MonoBehaviour
{
    [SerializeField] private ForwardRendererData fr_data;
    [SerializeField] private ScriptableRendererFeature[] features;
    [SerializeField] private enum_ScenesName sceneName;

    // Start is called before the first frame update
    void Start()
    {
        features = fr_data.rendererFeatures.ToArray();
        CheckScene(sceneName);

    }

    private void CheckScene(enum_ScenesName name)
    {
        switch (name)
        {
            case enum_ScenesName.MainMenu:
                features[0].SetActive(false);

                break;

            case enum_ScenesName.Tutorial:
                features[0].SetActive(true);
                break;
        }
    }
}
