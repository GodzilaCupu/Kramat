using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransitionHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI t_transition;
    [SerializeField] private float timer;
    private bool canStoop = false;

    [SerializeField, TextArea(3, 5)] private string s_transition;
    private CanvasGroup cg_transition;

    private int kulonProgres;
    
    void Start()
    {
        cg_transition = GetComponent<CanvasGroup>();
        t_transition = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        t_transition.text = s_transition;
        EventsManager.current.onKulonProgres += CheckProgres;
    }

    private void OnDisable()
    {
        EventsManager.current.onKulonProgres -= CheckProgres;
    }

    private void Update()
    {
        if (timer > 0f)
        {
            StartDisplayTransition(kulonProgres);
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0f;
            StopDisplayTransition(kulonProgres);
        }
    }

    private void CheckProgres(int progres) => kulonProgres = progres;

    private void StartDisplayTransition(int progres)
    {
        if (progres != 0) return;

        LeanTween.alphaCanvas(cg_transition, 1, 0.5f);
        if (cg_transition.alpha == 1)
            canStoop = true;  
    }

    private void StopDisplayTransition(int progres)
    {
        if (!canStoop)
            return;

        LeanTween.alphaCanvas(cg_transition, 0, 0.5f);
        if (cg_transition.alpha == 0)
            this.gameObject.SetActive(false);

    }
}
