using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum enum_GenderuwoState
{
    Lorong,
    Genderuwo1,
    Genderuwo2
}

public class BossFightManager : MonoBehaviour
{
    [SerializeField] private Fade fade;
    [SerializeField] private DialogHandler dialogHandler;
    [SerializeField] private GenderuwoHandler genderuwo;
    [SerializeField] private int bosFightProgres;
    [SerializeField] private List<SesajenHandler> sesajenProgres;
    [SerializeField] private float Timer;
    float currentTimer;
    public int sesajenCurrentProgres;

    void Start()
    {
        currentTimer = Timer;
        Database.SetLastScene(SceneManager.GetActiveScene().name);
        EventsManager.current.onBosFightProgres += GetProgres;
    }

    private void OnDisable()
    {
        EventsManager.current.onBosFightProgres -= GetProgres;
    }
    void Update()
    {
        CheckProgres(bosFightProgres);
    }

    private void GetProgres(int progres) => bosFightProgres = progres;
    private void CheckProgres(int id)
    {
        Database.SetProgresScene("BosFight", id);
        switch (id)
        {
            case ((int)enum_GenderuwoState.Lorong):
                if (Timer > 0f) Timer -= Time.deltaTime;
                else fade.FadeOut();
                break;

            case ((int)enum_GenderuwoState.Genderuwo1):
                EventsManager.current.PlayDialogBosFight(1);
                if (id != 1) return;
                if (!dialogHandler.IsFinished) return;
                EventsManager.current.BosFightProgres(2);
                break;

            case ((int)enum_GenderuwoState.Genderuwo2):
                EventsManager.current.BosFightProgres(sesajenCurrentProgres == 4 ? 3 : bosFightProgres);
                break;

            case 3:
                EventsManager.current.PlayDialogBosFight(2);
                if (id != 3) return;
                if (!dialogHandler.IsFinished) return; 
                genderuwo.Death();
                fade.FadeIn();
                break;
        }
    }

    public void ResetScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    public void BackToMainMenu() => SceneManager.LoadScene("MainMenu");
}
