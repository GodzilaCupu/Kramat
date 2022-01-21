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
    [SerializeField] private bool panelGetOpen; 
    public bool getPanelValue { get { return panelGetOpen; } }


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

        
        for(int i = 0; i<menuBTN.Length;i++)
            switch (i)
            {
                case 0:
                    menuBTN[0].onClick.AddListener(() => ContinueProgres());
                    break;

                case 1:
                    menuBTN[1].onClick.AddListener(() => PlayProgres());
                    break;

                case 2:
                    menuBTN[2].onClick.AddListener(()=> OpenSettings());
                    break;

                case 3:
                    menuBTN[3].onClick.AddListener(() => OpenCredits());
                    break;

                case 4:
                    menuBTN[4].onClick.AddListener(() => Application.Quit());
                    break;
            }

    }

    private void SetAllComponentValue()
    {
        titleTXT.text = titleSTRING;

        // RenderTexture Harus di sesuaikan dengan resolusi Video Asli

        if (Data.GetPlayerData("PlayTime") == 0) menuBTN[1].gameObject.SetActive(false);
        else menuBTN[1].gameObject.SetActive(true);
    }

    private void ContinueProgres()
    {
        //Continue LastCheckPoint()
    }

    private void PlayProgres()
    {
        Data.SetPlayerData("PlayTime", 1);
        //Start new Progress()
    }

    private void OpenSettings()
    {
        //To Control Panel Settings Get Open;
    }

    private void OpenCredits()
    {
        //To Control Panel Credits Get Open;
    }
}
