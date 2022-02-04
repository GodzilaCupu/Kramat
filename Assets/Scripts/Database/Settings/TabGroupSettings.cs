using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroupSettings : MonoBehaviour
{
    [Header("Script Reference")]
    [SerializeField] SettingsManager settingsManager;

    [Header("Object Reference")]
    [SerializeField] List<GameObject> panelContentSettings;
    [SerializeField] List<TabButtonsSettings> btnTabSettings;


    public void Suscribe(TabButtonsSettings tab)
    {
        if (btnTabSettings == null) btnTabSettings = new List<TabButtonsSettings>();

        btnTabSettings.Add(tab);
    }

    public void SelectedTab(TabButtonsSettings tab)
    {
        ResetTab();
        int _index = tab._id;
        for (int i = 0; i < panelContentSettings.Count; i++)
            if (i == _index)
            {
                panelContentSettings[i].SetActive(true);
                settingsManager.TitleSettingChanger(i);
            }
    }

    public void ResetTab()
    {
        for (int i = 0; i < panelContentSettings.Count; i++)
            panelContentSettings[i].SetActive(false);
    }
}

