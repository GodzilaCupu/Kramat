using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAdd_OnHandler : MonoBehaviour
{
    [Header("Ui")]
    [SerializeField] private GameObject go_panelFade;
    private CanvasGroup cg_panelFade;

    [Header("Player Conviguration"), Space(5)]
    [SerializeField] private Transform t_resetPos;
    [SerializeField] private GameObject go_player;


    private void Start()
    {
        go_player = this.gameObject;
        cg_panelFade = go_panelFade.GetComponent<CanvasGroup>();
        EventsManager.current.onResetPlayerPosition += GetReset;

    }

    private void OnDisable()
    {
        EventsManager.current.onResetPlayerPosition += GetReset;
    }

    private void GetReset()
    {
        ShowFading();
        if (cg_panelFade.alpha == 1f)
            go_player.transform.position = t_resetPos.position;

        HideFading();
    }

    private void ShowFading()
    {
        if (!go_panelFade.activeInHierarchy)
            go_panelFade.SetActive(true);

        LeanTween.alphaCanvas(cg_panelFade, 1, 0.5f);
    }

    private void HideFading() => LeanTween.alphaCanvas(cg_panelFade, 0, 0.5f);
}

