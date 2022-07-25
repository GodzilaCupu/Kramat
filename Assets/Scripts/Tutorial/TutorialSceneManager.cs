using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum enum_TutorialState
{
    Disclimer,
    Tutorial,
    DialogPapan1,
    DialogPapan2,
    DialogGamelan,
    Credits,
    Bumper,
}

public class TutorialSceneManager : MonoBehaviour
{
    [SerializeField] private int _tutorialProgresID;
    [SerializeField] private TutorialSFX_Handler sfx_Handler;
    private GameManager manager;

    private void Start()
    {
        Database.SetLastScene(SceneManager.GetActiveScene().name);
        manager = GetComponent<GameManager>();
    }

    private void Update()
    {
        CheckProgres();
        sfx_Handler.GetProgres(_tutorialProgresID);
    }

    private void OnEnable()
    {
        sfx_Handler = sfx_Handler != null ? sfx_Handler : GetComponent<TutorialSFX_Handler>();
        EventsManager.current.onTutorialProgres += GetProgres;
    }

    private void OnDisable()
    {
        EventsManager.current.onTutorialProgres -= GetProgres;
    }

    private void GetProgres(int id) => _tutorialProgresID = id;

    private void CheckProgres()
    {
        Database.SetProgresScene("Tutorial", _tutorialProgresID);
        switch (_tutorialProgresID)
        {
            case 0:
                EventsManager.current.CheckProgresTutorial(((int)enum_TutorialState.Disclimer));
                manager.SaveProgres(SceneManager.GetActiveScene().name, _tutorialProgresID); 
                break;

            case 1:
                manager.SaveProgres(SceneManager.GetActiveScene().name, _tutorialProgresID);
                EventsManager.current.CheckProgresTutorial(((int)enum_TutorialState.Tutorial));
                break;

            case 2:
                manager.SaveProgres(SceneManager.GetActiveScene().name, _tutorialProgresID);
                EventsManager.current.CheckProgresTutorial(((int)enum_TutorialState.DialogPapan1));
                EventsManager.current.PlayDialogTutorial(1);
                break;

            case 3:
                manager.SaveProgres(SceneManager.GetActiveScene().name, _tutorialProgresID);
                EventsManager.current.CheckProgresTutorial(((int)enum_TutorialState.DialogPapan2));         
                EventsManager.current.PlayDialogTutorial(2);
                break;

            case 4:
                manager.SaveProgres(SceneManager.GetActiveScene().name, _tutorialProgresID);
                EventsManager.current.CheckProgresTutorial(((int)enum_TutorialState.DialogGamelan));
                EventsManager.current.PlayDialogTutorial(3);
                break;

            case 5:
                manager.SaveProgres(SceneManager.GetActiveScene().name, _tutorialProgresID);
                EventsManager.current.CheckProgresTutorial(((int)enum_TutorialState.Credits));
                EventsManager.current.OpenPanelCredits();
                break;

            case 6:
                manager.SaveProgres(SceneManager.GetActiveScene().name, _tutorialProgresID); 
                EventsManager.current.CheckProgresTutorial(((int)enum_TutorialState.Bumper));
                break;

            default:
                Debug.Log($"Check ur id : {_tutorialProgresID}");
                break;
        }
    }
}
