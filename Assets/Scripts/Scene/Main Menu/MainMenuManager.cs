using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("Main Menu Component")]
    [SerializeField] List<Button> btnMainMenu;
    [SerializeField] List<GameObject> panelMainMenu;

    [Header("Script Reference")]
    [SerializeField] SettingsManager settingsManager;

    private void Awake()
    {
        MainMenuValue();
    }

    void MainMenuValue()
    {
        settingsManager.SettingsValue();

        if (Data.GetPlayerData("PlayerCount") == 0 || Data.GetPlayerData("PlayerCount") < 1)
            btnMainMenu[1].gameObject.SetActive(false);
        else
            btnMainMenu[1].gameObject.SetActive(true);

        for (int i =0;i<btnMainMenu.Count;i++)
            switch (i)
            {
                case 0:
                    btnMainMenu[0].onClick.AddListener(() => Debug.Log("New Game Test"));
                    Data.SetPlayerData("PlayerCount", 1);
                    break;

                case 1:
                    btnMainMenu[1].onClick.AddListener(() => Debug.Log("Continue"));
                    break;

                case 2:
                    btnMainMenu[2].onClick.AddListener(() => settingsManager.OpenSettingsPanel());
                    break;

                case 3:
                    btnMainMenu[3].onClick.AddListener(() => MainPanelActivator(2, true));
                    break;

                case 4:
                    btnMainMenu[4].onClick.AddListener(() => Application.Quit());
                    Debug.Log("Quit Game");
                    break;
            }
    }

    public void MainPanelActivator(int indexPanel, bool condition) => panelMainMenu[indexPanel].SetActive(condition);
}
