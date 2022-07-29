using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TransitionHandler : MonoBehaviour
{
    [Header("Transition Settings")]
    [SerializeField] private float timer;
    [SerializeField] private TextMeshProUGUI t_transition;
    private float currentTimer;
    private bool isDone;

    [Header("Transition Component")]
    [SerializeField] private CanvasGroup cg_transition;
    [SerializeField, TextArea(3, 5)] private string s_transition;

    private void Start()
    {
        //cg_transition = gameObject.transform.GetChild(0).gameObject.GetComponent<CanvasGroup>();
        currentTimer = timer;
    }

    public void StartTransition()
    {
        if(currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
            EventsManager.current.SetActivationMovement(false);
        }
        else
        {
            if (isDone) return;

            EventsManager.current.SetActivationMovement(true);
            LeanTween.alphaCanvas(cg_transition, 0, 0.5f);
            isDone = true;
        }
    }

    public void FinishTransition()
    {
        if(cg_transition.alpha == 0)
        {
            Database.SetProgresScene("Kulon", 4);
            LeanTween.alphaCanvas(cg_transition, 1, 0.5f);
            EventsManager.current.SetActivationMovement(false);
        }
        else
            SceneManager.LoadScene("BosFight");
    }
}
