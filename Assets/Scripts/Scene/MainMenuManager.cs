using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Title")]
    [SerializeField] private TextMeshProUGUI titleTXT;
    [SerializeField] private string titleSTRING;
    //[SerializeField] private Image titleIMG;
    //[SerializeField] private Sprite titleSPRITE;

    [Header("Buttons")]
    [SerializeField] private Button[] menuBTN;

    private void Awake()
    {
        GetAllComponentObject();
    }

    private void Start()
    {
        SetAllComponentValue();
    }

    private void GetAllComponentObject()
    {
        titleTXT = GameObject.Find("Title").GetComponent<TextMeshProUGUI>();
        //titleIMG = GameObject.Find("Title").GetComponent<Image>();



    }

    private void SetAllComponentValue()
    {
        titleTXT.text = titleSTRING;

        // RenderTexture Harus di sesuaikan dengan resolusi Video Asli
    }

}
