using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    [SerializeField] GameObject startFade;
    [SerializeField] GameObject exitFade;
    CanvasGroup cg_start;
    CanvasGroup cg_exit;
    void Start()
    {
        cg_start = startFade.GetComponent<CanvasGroup>();
        cg_exit = exitFade.GetComponent<CanvasGroup>();
    }

    public void FadeOut()
    {
        LeanTween.alphaCanvas(cg_start, 0, 0.5f);
        if (cg_start.alpha == 0) startFade.SetActive(false);
    }

    public void FadeIn()
    {
        if (!exitFade.activeInHierarchy) exitFade.SetActive(true);
        LeanTween.alphaCanvas(cg_exit, 1, 0.5f);
        if (cg_exit.alpha == 1) SceneManager.LoadScene("Scene5");
    }
}
