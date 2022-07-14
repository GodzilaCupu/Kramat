using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausedHandler : MonoBehaviour
{
    [SerializeField] private GameObject panel_pause;
    [SerializeField] private GameManager manager;
    [SerializeField,Tooltip("0 : Resume ; 1 : Settings ; 2 : MainMenu ")] private Button[] btn_pause;
    private bool isPaused;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == enum_ScenesName.MainMenu.ToString())
            return;

        SetButton();
        Cursor.visible = false;
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if(CustomInputMap.current.GetPaused())
            CheckPaused(true);

        CheckCursor();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus) return;

        CheckPaused(true);
    }
    private void SetButton()
    {
        btn_pause[0].onClick.AddListener(delegate { CheckPaused(false); });
        btn_pause[1].onClick.AddListener(OpenSettings);
        btn_pause[2].onClick.AddListener(BackToMainMenu);
    }

    private void CheckPaused(bool paused)
    {
        if (SceneManager.GetActiveScene().name == enum_ScenesName.MainMenu.ToString())
        {
            Cursor.visible = true;
            return;
        }

        Cursor.visible = paused;
        isPaused = paused;
        panel_pause.SetActive(paused);
        EventsManager.current.Paused(paused);
        EventsManager.current.SetActivationMovement(!paused);
    }

    public void BackToMainMenu()
    {
        CheckPaused(false);
        SceneManager.LoadScene("MainMenu");
        manager.SaveProgres(SceneManager.GetActiveScene().name, Database.GetProgresScene(SceneManager.GetActiveScene().name));
    }

    public void OpenSettings() => EventsManager.current.OpenPanelSettings();
    private void CheckCursor()
    {
        if (SceneManager.GetActiveScene().name == enum_ScenesName.MainMenu.ToString())
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None; 
            return;
        }

        if (isPaused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            return;
        }

        if (Database.GetGraphic("FullScreen") == 1)
        {
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }
        Cursor.lockState = CursorLockMode.Confined;
    }
}
