using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

enum enum_Credits_Style{
    MainMenu,
    GOW,
    BreathEdge,
}

public class CreditsHandler : MonoBehaviour
{
    [SerializeField] private GameObject go_creditsPanel;
    [SerializeField] enum_Credits_Style _credits_Style;

    private bool isMainMenuScene;
    private bool canPlay;

    private void Start()
    {
        CheckScene();
        CheckTutorial_Style();
        SetEvent(true, isMainMenuScene);
    }

    private void Update()
    {
        if (isMainMenuScene)
            ClosePanel(CustomInputMap.current.GetPaused() ? true : false);
    }


    private void OnDisable()
    {
        SetEvent(false, isMainMenuScene);
    }

    private void CheckScene() => isMainMenuScene = SceneManager.GetActiveScene().name == enum_ScenesName.MainMenu.ToString() ? true : false;

    private void Tutorial_Credits(int id)
    {
        canPlay = id == ((int)enum_TutorialState.Credits) ? true : false; 
        EventsManager.current.PlayCredits(canPlay);
    } 
    
    private void OpenPanel()
    {
        go_creditsPanel.SetActive(go_creditsPanel.activeInHierarchy ? true : true);
        EventsManager.current.PlayCredits(true);
    }

    private void ClosePanel(bool isExit)
    {
        if(!isExit)
        return;

        go_creditsPanel.SetActive(false);
        EventsManager.current.PlayCredits(false);
    }

    private void CheckTutorial_Style()
    {
        switch(_credits_Style)
        {
            case enum_Credits_Style.MainMenu :
                Debug.Log("You In Main Menu Gamelan");
                break;

            case enum_Credits_Style.GOW :
                go_creditsPanel.GetComponent<CanvasGroup>().alpha = 1f;
                go_creditsPanel.GetComponent<Image>().enabled = false;
                Destroy(GetComponent<BreathEdge_Credits>());
                Debug.Log($"You In Tutorial Gamelan with : " + _credits_Style);
                break;

            case enum_Credits_Style.BreathEdge :
                go_creditsPanel.GetComponent<CanvasGroup>().alpha = 0f;
                go_creditsPanel.GetComponent<Image>().enabled = true;
                Destroy(gameObject.GetComponent<Gow_Credits>());
                Debug.Log($"You In Tutorial Gamelan with : " + _credits_Style);break;
        }
    }

    private void SetEvent(bool isEnable,bool mainMenu)
    {
        if (!isEnable)
        {
            EventsManager.current.onOpenPanelCredits -= OpenPanel;

            if(!mainMenu)
            {
                EventsManager.current.onPaused -= ClosePanel;   
                EventsManager.current.onTutorialProgres -= Tutorial_Credits;
                return;
            }
            return;
        }

        EventsManager.current.onOpenPanelCredits += OpenPanel;
        if (!mainMenu)
        {
            EventsManager.current.onPaused += ClosePanel;
            EventsManager.current.onTutorialProgres += Tutorial_Credits;
            return;
        }
    }
}