using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskNotificationHandler : MonoBehaviour
{
    [SerializeField] private CanvasGroup cgTask;
    [SerializeField] private TextMeshProUGUI txtTask;
    [SerializeField] private TaskNotificationSO dataTask;
    [SerializeField] private enum_ScenesName nameCurrentScene;

    private string sTask;

    private int idWetan = 0;
    private int idKulon = 0;
    private int idBosFight = 0;

    private int currentProgres = 0;
    private bool canChange;

    void Start()
    {
        nameCurrentScene = dataTask.SceneName;
        CheckKulonTask();
        cgTask.gameObject.SetActive(true);
        cgTask.alpha = 1;
        SetText();
        CheckScene(true);
    }

    private void OnDisable()
    {
        CheckScene(false);
    }

    private void Update()
    {
        CheckKulonTask();
        CheckBosFightTask();
        CheckChange();
        CheckPanel(canChange);
    }

    private void CheckChange()
    {
        switch (nameCurrentScene)
        {
            case enum_ScenesName.Tutorial:
                this.gameObject.SetActive(false);
                break;

            case enum_ScenesName.DesaWetan:
                canChange = currentProgres < idWetan ? true : false;
                break;

            case enum_ScenesName.DesaKulon:
                canChange = currentProgres < idKulon ? true : false;
                break;

            case enum_ScenesName.BosFight:
                canChange = currentProgres < idBosFight ? true : false;
                break;
        }
    }

    private void Current_onWetanProgres(int obj) => idWetan = obj > idWetan ? obj : idWetan;
    private void Current_onKulonProgres(int obj) => idKulon = obj > idKulon ? obj : idKulon;
    private void Current_onBosFightProgres(int obj) => idBosFight = obj > idBosFight ? obj : idBosFight;

    private void CheckScene(bool Start)
    {
        if (Start)
        {
            switch (nameCurrentScene)
            {
                case enum_ScenesName.DesaWetan:
                    EventsManager.current.onWetanProgres += Current_onWetanProgres;
                    canChange = currentProgres < idWetan ? true : false;
                    break;

                case enum_ScenesName.DesaKulon:
                    EventsManager.current.onKulonProgres += Current_onKulonProgres;
                    canChange = currentProgres < idKulon ? true : false;
                    break;

                case enum_ScenesName.BosFight:
                    EventsManager.current.onBosFightProgres += Current_onBosFightProgres;
                    canChange = currentProgres < idBosFight ? true : false;
                    break;
            }
            return;
        }
        
        switch (nameCurrentScene)
        {
            case enum_ScenesName.DesaWetan:
                EventsManager.current.onWetanProgres -= Current_onWetanProgres;
                break;

            case enum_ScenesName.DesaKulon:
                EventsManager.current.onKulonProgres -= Current_onKulonProgres;
                break;

            case enum_ScenesName.BosFight:
                EventsManager.current.onBosFightProgres -= Current_onBosFightProgres;
                break;
        }
    }

    private void CheckPanel(bool isChange)
    {
        if (!isChange)
            return;

        SetText();
    }

    private void SetText()
    {
        switch (nameCurrentScene)
        {
            case enum_ScenesName.DesaWetan:
                sTask = dataTask.TaskWord[idWetan];
                txtTask.text = sTask;
                currentProgres = idWetan;
                break;

            case enum_ScenesName.DesaKulon:
                sTask = dataTask.TaskWord[idKulon];
                txtTask.text = sTask;
                currentProgres = idKulon;
                break;

            case enum_ScenesName.BosFight:
                sTask = dataTask.TaskWord[0];
                txtTask.text = sTask;
                currentProgres = idBosFight;
                break;
        }
    }

    private void CheckKulonTask()
    {
        if (nameCurrentScene != enum_ScenesName.DesaKulon) return;

        if(currentProgres < 1)
        {
            cgTask.gameObject.SetActive(false);
            cgTask.alpha = 0;
            return;
        }

        cgTask.gameObject.SetActive(true);
        cgTask.alpha = 1;
    }

    private void CheckBosFightTask()
    {
        if (nameCurrentScene != enum_ScenesName.BosFight) return;

        if (currentProgres != 1)
        {
            cgTask.gameObject.SetActive(false);
            cgTask.alpha = 0;
            return;
        }

        cgTask.gameObject.SetActive(true);
        cgTask.alpha = 1;
    }
}
