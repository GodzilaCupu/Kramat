using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum enum_DialogText
{
    Name,
    Description
}

public class DialogHandler : MonoBehaviour
{
    [Header("Data Dialog")]
    [SerializeField] private enum_ScenesName nameScene;
    [SerializeField] private DialogManagerSO dialogData;
   
    
    [Header("Component Dialog")]
    [SerializeField] private GameObject go_Dialogue;

    [SerializeField] private TextMeshProUGUI[] t_display = new TextMeshProUGUI[2];
    [SerializeField] AudioSource as_Dialouge;
    private CanvasGroup cg_Dialogue;
    private AudioClip dialogueClip;
    private string s_NameDialog;
    private string s_Dialog;

    [Header("Identification")]
    [SerializeField] private int currentID;
    [SerializeField] private int MaxID;
    private int countID = 0;

    public bool IsPlayDialog { get { return canPlayDialouge; } }
    public bool IsFinished { get { return isFinished; } }
    
    bool paused;

    bool isPlayingAudio;
    bool isAlreadyPlay = false;

    bool isLast = false;
    bool isFirst = false;
    bool isFinished = false;
    bool canNext = false;
    bool canPlayDialouge = false;

    void Update()
    {
        if (paused)
        {
            as_Dialouge.Pause();
            return;
        }

        if (!canPlayDialouge)
        {
            SetDeactivePanel();
            as_Dialouge.Pause();
            ResetDialogID();    
            return;
        }

        CheckProgres(nameScene, countID);
    }

    #region Event Configuration
    private void Start()
    {
        as_Dialouge = GetComponent<AudioSource>();
        cg_Dialogue = go_Dialogue.GetComponent<CanvasGroup>(); 
        CheckScene(true);
    }

    private void OnDisable()
    {
        CheckScene(false);
    }

    private void CheckScene(bool active)
    {
        if (active)
        {
            EventsManager.current.onPaused += (v) => paused = v;
            switch (nameScene)
            {
                case enum_ScenesName.Tutorial:
                    EventsManager.current.onPlayDialogTutorial += (v) => currentID = v;
                    EventsManager.current.onDialougeTrigger += (v) => canPlayDialouge = v;
                    break;

                case enum_ScenesName.DesaWetan:
                    EventsManager.current.onWetanDialogProgres += (v) => currentID = v;
                    EventsManager.current.onDialougeTrigger += (v) => canPlayDialouge = v;
                    break;

                case enum_ScenesName.DesaKulon:
                    EventsManager.current.onKulonPlayDialog += (v) => currentID = v;
                    EventsManager.current.onDialougeTrigger += (v) => canPlayDialouge = v;
                    break;

                case enum_ScenesName.BosFight:
                    EventsManager.current.onPlayDialogBosFight += (v) => currentID = v;
                    EventsManager.current.onDialougeTrigger += (v) => canPlayDialouge = v;
                    break;
            }
            return;
        }

        EventsManager.current.onPaused -= (v) => paused = v;
        switch (nameScene)
        {
            case enum_ScenesName.Tutorial:
                EventsManager.current.onPlayDialogTutorial -= (v) => currentID = v;
                EventsManager.current.onDialougeTrigger -= (v) => canPlayDialouge = v;
                break;

            case enum_ScenesName.DesaWetan:
                EventsManager.current.onWetanDialogProgres -= (v) => currentID = v;
                EventsManager.current.onDialougeTrigger -= (v) => canPlayDialouge = v;
                break;

            case enum_ScenesName.DesaKulon:
                EventsManager.current.onKulonPlayDialog -= (v) => currentID = v;
                EventsManager.current.onDialougeTrigger -= (v) => canPlayDialouge = v;
                break;

            case enum_ScenesName.BosFight:
                EventsManager.current.onPlayDialogBosFight -= (v) => currentID = v;
                EventsManager.current.onDialougeTrigger -= (v) => canPlayDialouge = v;
                break;
        }
    }

    #endregion

    #region Progres
    private void CheckProgres(enum_ScenesName nameScene, int countId)
    {
        isFirst = countId == 0 ? true : false;
        isLast = countId == dialogData.maxLine ? true : false;

        canNext = isLast == false ? true : false;
        switch (nameScene)
        {
            case enum_ScenesName.Tutorial:
                dialogData.TutorialProgres(currentID, countId);
                break;

            case enum_ScenesName.DesaWetan:
                dialogData.WetanProgres(currentID, countId);
                break;

            case enum_ScenesName.DesaKulon:
                dialogData.KulonProgres(currentID, countId);
                break;

            case enum_ScenesName.BosFight:
                dialogData.BosFightProgres(currentID, countId);
                break;
        }
        CheckData();
        DisplayDialog();
    }

    private void PlayDialog()
    {
        isPlayingAudio = as_Dialouge.isPlaying == true ? true : false;

        if (isAlreadyPlay)
        {
            NextDialog();
            return;
        }

        if (isPlayingAudio)
            return;

        as_Dialouge.Play();
        isAlreadyPlay = true;
    }

    private void CheckData()
    {
        MaxID = dialogData.maxLine;
        dialogueClip = dialogData.dialogSound;
        as_Dialouge.clip = dialogueClip;

        s_NameDialog = dialogData.dialogName;
        s_Dialog = dialogData.dialogText;
    }

    private void SetText()
    {
        t_display[((int)enum_DialogText.Name)].text = s_NameDialog;
        t_display[((int)enum_DialogText.Description)].text = s_Dialog;
    }

    private void NextDialog()
    {
        if (CustomInputMap.current.GetDialogSkip() && canNext && !isPlayingAudio)
        //if (CustomInputMap.current.GetDialogSkip() && canNext)
        {
            countID++;
            isAlreadyPlay = false;
        }

        if (CustomInputMap.current.GetDialogSkip() && isLast && !canNext)
            SetDeactivePanel();

    }

    private void ResetDialogID()
    {
        countID = 0;
        isPlayingAudio = false;
        isAlreadyPlay = false;

        isLast = false;
        isFirst = false;
        canNext = false;
        canPlayDialouge = false;
    }
    #endregion

    #region Panels Configuration
    private void DisplayDialog()
    {
        if (isFirst)
        {
            isFinished = false;
            SetActivePanel();
            PlayDialog();
        }

        PlayDialog();
        SetText();
    }

    private void SetActivePanel()
    {
        go_Dialogue.SetActive(true);
        LeanTween.alphaCanvas(cg_Dialogue, 1, 0.5f);
        if (cg_Dialogue.alpha > 0.99)
            cg_Dialogue.alpha = 1;
    }

    private void SetDeactivePanel()
    {
        LeanTween.alphaCanvas(cg_Dialogue, 0, 0.5f);
        isFinished = true;
        ResetDialogID();
        EventsManager.current.MoveNPCWetan(true);
        EventsManager.current.DialougeTrigger(false); 
        go_Dialogue.SetActive(cg_Dialogue.alpha == 0? false : true);
    }
    #endregion
}

