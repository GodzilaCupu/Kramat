using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    [SerializeField] GameObject panel;
    CanvasGroup cg_panel;
    void Start()
    {
        cg_panel = panel.GetComponent<CanvasGroup>();
    }

    public void FadeOut()
    {
        LeanTween.alphaCanvas(cg_panel, 0, 0.5f);
        if (cg_panel.alpha == 0) panel.SetActive(false);
    }

    public void FadeIn()
    {
        if (!panel.activeInHierarchy) panel.SetActive(true);
        LeanTween.alphaCanvas(cg_panel, 1, 0.5f);
    }
}
