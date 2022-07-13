using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum enum_MainMenuButtons
{
    Play,
    Continue,
    Settings,
    Credits,
    ExitGame,
}

public class MainMenuButtonsHandler : MonoBehaviour
{
    [Header("Buttons Main in Main Menu")]

    [SerializeField, Tooltip("0 = btn play game \n1 = btn continue game \n2 = btn open settings panel \n3 = btn open credits panel \n4 = btn exit game")]
    private Button[] btn_MainMenu;
    GameManager manager;
    private bool alreadyPlay;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        CallingButtons();
        CheckContinue();
    }

    private void Update()
    {
        CheckContinue();
    }

    private void CheckContinue()
    {
        if(manager.LastProgresTutorial() == 0)
        {
            alreadyPlay = false;
            return;
        }

        alreadyPlay = true;

        if (!alreadyPlay)
        { 
            btn_MainMenu[0].gameObject.SetActive(false);
            return;
        }

        btn_MainMenu[0].gameObject.SetActive(true);
    }

    private void CallingButtons()
    {
        for (int i = 0; i < btn_MainMenu.Length; i++)
        {
            switch (i)
            {
                case 0:
                    btn_MainMenu[((int)enum_MainMenuButtons.Play)].onClick.AddListener(StartGame);
                    break;

                case 1:
                    btn_MainMenu[((int)enum_MainMenuButtons.Continue)].onClick.AddListener(ContinueGame);
                    break;

                case 2:
                    btn_MainMenu[((int)enum_MainMenuButtons.Settings)].onClick.AddListener(OpenSettingsPanel);
                    break;

                case 3:
                    btn_MainMenu[((int)enum_MainMenuButtons.Credits)].onClick.AddListener(OpenCreditsPanel);
                    break;

                case 4:
                    btn_MainMenu[((int)enum_MainMenuButtons.ExitGame)].onClick.AddListener(ExitGame);
                    break;

                default:
                    Debug.Log($"Check ur id {i}");
                    break;
            }
        }
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Tutorial");
        alreadyPlay = true;
    }

    private void ContinueGame()
    {
        string lastScene = Database.GetLastScene();
        SceneManager.LoadScene(lastScene);
    }
    
    private void OpenSettingsPanel() => EventsManager.current.OpenPanelSettings();
    private void OpenCreditsPanel()  => EventsManager.current.OpenPanelCredits();
    private void ExitGame() => Application.Quit();
}

