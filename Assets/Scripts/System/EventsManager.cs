using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enum_ScenesName
{
    Loading,
    MainMenu,
    Tutorial,
    DesaWetan,
    DesaKulon,
    BosFight
}

public class EventsManager : MonoBehaviour
{
    public static EventsManager current;

    void Awake()
    {
        if (current != null && current != this) Destroy(this);
        else current = this;
    }

    #region Main menu Buttons

    public event Action onStartNewGame;
    public void StartNewGame() => onStartNewGame?.Invoke();

    public event Action onContinueGame;
    public void ContinueGame() => onContinueGame?.Invoke();

    #endregion

    #region Tutorial
    public event Action<int> onPlayDialogTutorial;

    public event Action<int> onPlaySFXTutorial;
    public event Action<int> onTutorialProgres;

    public event Action<bool> onPlayTrailer;

 
    public void PlayDialogTutorial(int dialog ) => onPlayDialogTutorial?.Invoke(dialog);

    public void PlaySFXTutorial(int progres) => onPlaySFXTutorial?.Invoke(progres);
    public void CheckProgresTutorial(int progres) => onTutorialProgres?.Invoke(progres);

    public void PlayVideoTrailer(bool onPlay) => onPlayTrailer?.Invoke(onPlay);
    #endregion

    #region Wetan

    public event Action<int> onSawahTrigger;
    public event Action<int> onWetanDialogProgres;
    public event Action<int> onWetanProgres;
    public event Action<bool> onMoveNPCWetan;


    public void SawahTrigger(int id) => onSawahTrigger?.Invoke(id);
    public void CheckProgresWetan(int progres) => onWetanProgres?.Invoke(progres);
    public void DialogWetanProgres(int progres) => onWetanDialogProgres?.Invoke(progres);
    public void MoveNPCWetan(bool progres) => onMoveNPCWetan?.Invoke(progres);


    #endregion

    #region Kulon

    public event Action onSumurPlay;
    public event Action onResetPlayerPosition;

    public event Action<int> onKulonProgres;
    public event Action<int> onKulonPlayDialog;
    public event Action<bool> onOpenNote;


    public void SumurPlay() => onSumurPlay?.Invoke();
    public void ResetPlayerPosition() => onResetPlayerPosition?.Invoke();

    public void CheckKulonProgres(int progres) => onKulonProgres?.Invoke(progres);
    public void KulonPlayDialog(int progres) => onKulonPlayDialog?.Invoke(progres);
    public void OpenNote(bool isOpen) => onOpenNote?.Invoke(isOpen);

    #endregion

    #region BossFight

    public event Action onInspectKeris;
    public event Action onDoorHallwayPast;
    public event Action<int> onPlayDialogBosFight;

    public event Action<int> onBosFightProgres;
    public event Action<bool> onPlayGenderuwo;

    public event Action<GameObject> onAttackTrigger;


    public void InspectKeris() => onInspectKeris?.Invoke();
    public void DoorHallwayPast() => onDoorHallwayPast?.Invoke();
    public void PlayDialogBosFight(int progres) => onPlayDialogBosFight?.Invoke(progres);

    public void BosFightProgres(int progres) => onBosFightProgres?.Invoke(progres);
    public void PlayGenderuwo(bool canPlay) => onPlayGenderuwo?.Invoke(canPlay);

    public void AttackTrigger(GameObject sesajen) => onAttackTrigger?.Invoke(sesajen);
    #endregion

    #region UI

    public event Action<string> onItemName;
    public event Action<string> onNPCName;

    public event Action<bool> onDisplayItem;
    public event Action<bool> onDisplayNPC;

    public event Action<bool> onDisplayTask;

    public void CheckNameNPC(string name) => onNPCName.Invoke(name);
    public void CheckNameItem(string name) => onItemName.Invoke(name);
    public void CheckDisplayTask(bool task) => onDisplayTask.Invoke(task);
    public void CheckDisplayNPC(bool canDisplay) => onDisplayNPC.Invoke(canDisplay);
    public void CheckDisplayItem(bool canDisplay) => onDisplayItem.Invoke(canDisplay);

    #endregion

    #region Player Feature

    public event Action onFlashlightTrigger;
    
    public event Action<bool> onRaycast;
    public event Action<bool> onDialougeTrigger;
    public event Action<bool> onNPCDialogueTrigger;
    public event Action<bool> onFlashlightBlinking;
   
    public event Action<GameObject> onGrabItemTrigger;

    public void FlashlightTrigger() => onFlashlightTrigger?.Invoke();

        
    public void SetRaycast(bool isOn) => onRaycast?.Invoke(isOn);
    public void DialougeTrigger(bool isOn) => onDialougeTrigger?.Invoke(isOn);
    public void NPCDialogTrigger(bool isOn) => onNPCDialogueTrigger?.Invoke(isOn);
    public void SetFlashlightBlink(bool isOn) => onFlashlightBlinking?.Invoke(isOn);
    
    public void GrabItemTrigger(GameObject item) => onGrabItemTrigger?.Invoke(item);
    #endregion

    #region Settings

    public event Action onOpenPanelSettings;

    public event Action<bool> onPaused;

    public event Action<bool> onTurnOffMovement;

    public event Action<float> onChangeSensitivy;

    public event Action<float> onChangeBrightness;

    public void OpenPanelSettings() => onOpenPanelSettings?.Invoke();
    public void Paused(bool isPaused) => onPaused?.Invoke(isPaused);
    public void SetActivationMovement(bool isOn) => onTurnOffMovement?.Invoke(isOn);
    public void ChangeSensitivy(float value) => onChangeSensitivy?.Invoke(value);
    public void ChangeBrightness(float value) => onChangeBrightness?.Invoke(value);

    #endregion

    #region Credits

    public event Action onOpenPanelCredits;
    public void OpenPanelCredits() => onOpenPanelCredits?.Invoke();

    public event Action onClosePanelCredits;
    public void CloseCredits() => onClosePanelCredits?.Invoke();

    public event Action<bool> onPlayCredits;
    public void PlayCredits(bool isPlay) => onPlayCredits?.Invoke(isPlay);

    #endregion

    #region Scene Transision

    public event Action<enum_ScenesName,enum_ScenesName> onLoadScene;
    public void LoadScene(enum_ScenesName startScene, enum_ScenesName targetScene) => onLoadScene?.Invoke(startScene,targetScene);

    #endregion
}

