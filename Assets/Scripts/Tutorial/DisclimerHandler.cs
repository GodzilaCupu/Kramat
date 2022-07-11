using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisclimerHandler : MonoBehaviour
{
    [SerializeField] TutorialSFX_Handler sfx;
    [SerializeField, TextArea(3, 5)] private string[] s_displayText;
    [SerializeField] private TextMeshProUGUI t_displayText;

    [SerializeField] private float _targetTimer = 3f;
    private float currentTimer;
    private int _diclaimerProgres = 0;

    [SerializeField] private CanvasGroup cg_panel;
    private CanvasGroup cg_text;

    private bool isPlay = false;

    private void Start()
    {
        currentTimer = _targetTimer;
        cg_text = t_displayText.gameObject.GetComponent<CanvasGroup>();
        EventsManager.current.onTutorialProgres += Current_onPlayDisclimer;
    }

    private void OnDisable()
    {
        EventsManager.current.onTutorialProgres -= Current_onPlayDisclimer;
    }

    private void Update()
    {
        DisclaimerPanel();
        if(_diclaimerProgres == 1)
        {
            sfx.StartPlayDisclimer();
            return;
        }
        

    }

    private void Current_onPlayDisclimer(int id) => isPlay = id == ((int)enum_TutorialState.Disclimer) ? true : false;

    private void DisclaimerPanel()
    {
        if (!isPlay)
            return;

        if (currentTimer > 0)
        {
            switch (_diclaimerProgres)
            {
                case 0:
                    SetText();
                    SetActivePanel();
                    EventsManager.current.SetActivationMovement(false);
                    currentTimer -= Time.deltaTime;
                    break;

                case 1:
                    SetActiveText();
                    currentTimer -= Time.deltaTime;
                    break;

                default:
                    Debug.LogWarning($"Check ur id : {_diclaimerProgres}");
                    break;
            }
        }
        else
        {
            switch (_diclaimerProgres)
            {
                case 0:
                    SetDeactiveText();
                    currentTimer = _targetTimer;
                    _diclaimerProgres += 1;
                    break;

                case 1:
                    isPlay = false;
                    SetDeactivePanel();
                    currentTimer = 0;
                    EventsManager.current.SetActivationMovement(true);
                    EventsManager.current.CheckProgresTutorial(((int)enum_TutorialState.Tutorial));
                    break;

                default:
                    Debug.LogWarning($"Check ur id : {_diclaimerProgres}");
                    break;
            }
        }
    }

    #region Panel
    private void SetActivePanel() => cg_panel.alpha = 1f;

    private void SetDeactivePanel() 
    {
        LeanTween.alphaCanvas(cg_panel, 0, 1f);
        this.gameObject.SetActive(cg_panel.alpha == 0 ? true : false);
    }

    #endregion

    #region Text
    private void SetText()
    {
        if(_diclaimerProgres == 0)
        {
            t_displayText.text = s_displayText[0];
            t_displayText.fontSize = 70f;
        }
        else
        {
            t_displayText.text = s_displayText[1];
            t_displayText.fontSize = 100f;
        }
    }

    private void SetActiveText()
    {
        if (cg_text.alpha == 0f)
        {
            LeanTween.alphaCanvas(cg_text, 1f, 1f).setDelay(.5f);

            if (cg_text.alpha > 0.89f)
                cg_text.alpha = 1;
            else
                SetText();
        }
    }

    private void SetDeactiveText()
    {
        LeanTween.alphaCanvas(cg_text, 0f, 1f);
        if (cg_text.alpha < 0.15)
            cg_text.alpha = 0f;
    }
    #endregion

}
