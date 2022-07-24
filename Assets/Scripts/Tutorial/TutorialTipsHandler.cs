using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enum_TutorialTipsState
{
    Movement,
    Interactions,
    Flashlight,
    Run,
}

public class TutorialTipsHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> panels;
    [SerializeField] private List<CanvasGroup> cg_Panels;

    [SerializeField] private float _targetTimer = 10f;

    private float currentTimer;
    private int _currentTutorial = 0;
    
    private bool isPlay = false;
    private bool isPaused;

    private void Start()
    {
        GetPanels();
        currentTimer = _targetTimer;
    }

    private void OnEnable()
    {
        EventsManager.current.onPaused += (v) => isPaused = v;
        EventsManager.current.onTutorialProgres += CheckProgres;
    }

    private void OnDisable()
    {
        EventsManager.current.onPaused -= (v) => isPaused = v;
        EventsManager.current.onTutorialProgres += CheckProgres;
    }

    private void Update()
    {
        if (isPlay)
            if(!isPaused)
                TutorialPanels();
    }

    private void CheckProgres(int id) => isPlay = id == ((int)enum_TutorialState.Tutorial) ? true : false;

    #region Panel
    private void GetPanels()
    {
        panels.Clear();
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            GameObject panel = this.gameObject.transform.GetChild(i).gameObject;

            cg_Panels.Add(panel.GetComponent<CanvasGroup>());
            panels.Add(panel);
        }
    }

    private void TutorialPanels()
    {

        if (currentTimer > 0)
        {
            switch (_currentTutorial)
            {
                case ((int)enum_TutorialTipsState.Movement):
                    SetActivePanel(enum_TutorialTipsState.Movement);
                    currentTimer -= Time.deltaTime;
                    break;

                case ((int)enum_TutorialTipsState.Interactions):
                    SetActivePanel(enum_TutorialTipsState.Interactions);
                    currentTimer -= Time.deltaTime;
                    break;

                case ((int)enum_TutorialTipsState.Flashlight):
                    SetActivePanel(enum_TutorialTipsState.Flashlight);
                    currentTimer -= Time.deltaTime;
                    break;

                case ((int)enum_TutorialTipsState.Run):
                    SetActivePanel(enum_TutorialTipsState.Run);
                    currentTimer -= Time.deltaTime;
                    break;

                default:
                    Debug.LogWarning($"Check ur id : {_currentTutorial}");
                    break;
            }
        }
        else
        {
            switch (_currentTutorial)
            {
                case ((int)enum_TutorialTipsState.Movement):
                    SetDeactivePanel(enum_TutorialTipsState.Movement);
                    break;

                case ((int)enum_TutorialTipsState.Interactions):
                    SetDeactivePanel(enum_TutorialTipsState.Interactions);
                    break;

                case ((int)enum_TutorialTipsState.Flashlight):
                    SetDeactivePanel(enum_TutorialTipsState.Flashlight);
                    break;

                case ((int)enum_TutorialTipsState.Run):
                    SetDeactivePanel(enum_TutorialTipsState.Run);
                    isPlay = false;
                    break;

                default:
                    Debug.LogWarning($"Check ur id : {_currentTutorial}");
                    break;
            }
        }
    }

    private void SetActivePanel(enum_TutorialTipsState state)
    {
        switch (state)
        {
            case enum_TutorialTipsState.Movement:
                LeanTween.alphaCanvas(cg_Panels[((int)state)], 1, 0.5f);
                if (cg_Panels[((int)state)].alpha > 0.89f)
                    cg_Panels[((int)state)].alpha = 1f;
                break;

            case enum_TutorialTipsState.Interactions:
                LeanTween.alphaCanvas(cg_Panels[((int)state)], 1, 0.5f);
                if (cg_Panels[((int)state)].alpha > 0.89f)
                    cg_Panels[((int)state)].alpha = 1f;
                break;

            case enum_TutorialTipsState.Flashlight:
                if (cg_Panels[((int)enum_TutorialTipsState.Movement)].alpha == 0f)
                {
                    LeanTween.alphaCanvas(cg_Panels[((int)state)], 1, 0.5f);
                    if (cg_Panels[((int)state)].alpha > 0.89f)
                        cg_Panels[((int)state)].alpha = 1f;
                }
                break;

            case enum_TutorialTipsState.Run:
                if (cg_Panels[((int)enum_TutorialTipsState.Flashlight)].alpha == 0f)
                {
                    LeanTween.alphaCanvas(cg_Panels[((int)state)], 1, 0.5f);
                    if (cg_Panels[((int)state)].alpha > 0.89f)
                        cg_Panels[((int)state)].alpha = 1f;
                }
                break;
        }
    }

    private void SetDeactivePanel(enum_TutorialTipsState state)
    {
        LeanTween.alphaCanvas(cg_Panels[((int)state)], 0, 0.5f);
        if (cg_Panels[((int)state)].alpha < 0.15f)
        {
            if(state == enum_TutorialTipsState.Run)
            {
                currentTimer = 0f;
                cg_Panels[((int)state)].alpha = 0f;
            }
            else
            {
                cg_Panels[((int)state)].alpha = 0f;
                currentTimer = _targetTimer;
                _currentTutorial += 1;
            }
        }
    }
    #endregion

}
