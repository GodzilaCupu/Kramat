using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CrawlingCredits : MonoBehaviour
{
    [Header("Animation Properties")]
    [SerializeField] private float _credits_target;
    [SerializeField] private float _credits_Duration = 35f;
    [SerializeField] private Vector3 startPos;

    [Header("Credtis Component"),Space(20)]
    [SerializeField] private CreditsScriptibleObject[] so_credits;
    [SerializeField] private TextMeshProUGUI t_credits;
    [SerializeField] private GameObject go_credits;

    [SerializeField] private GameObject paused;

    private string _textContentConainer;

    private void Start()
    {
        CheckScene(SceneManager.GetActiveScene(), true);
    }
           
    private void OnDisable() => CheckScene(SceneManager.GetActiveScene(), false);

    private void CheckScene(Scene sceneName, bool isPlay)
    {
        if(sceneName.name == "MainMenu")
        {
            if (isPlay)
            {
                EventsManager.current.onPlayCredits += PlayMainMenu;
                paused = null;
                return;
            }
            EventsManager.current.onPlayCredits -= PlayMainMenu;
            return;
        }
        if (isPlay)
        {
            EventsManager.current.onPlayCredits += PlayScene5;
            return;
        }
        EventsManager.current.onPlayCredits -= PlayScene5;
    }

    private void Update()
    {
        print(LeanTween.tweensRunning + " animate");
        if (SceneManager.GetActiveScene().name == "MainMenu") return;
        if (paused.activeInHierarchy)
        {
            LeanTween.pause(go_credits);
            Cursor.visible = true;
            return;
        }
        LeanTween.resume(go_credits);
        Cursor.visible = false;
    }

    void PlayMainMenu(bool isPlay)
    {
        DisplayCreditsFromS0();
        if (isPlay)
        {
            if(go_credits.transform.position != startPos)
                go_credits.transform.localPosition = startPos;

            Cursor.visible = isPlay;
           
            if(SceneManager.GetActiveScene().name == "MainMenu")
            {

                LeanTween.moveLocalY(go_credits, _credits_target, _credits_Duration).setLoopClamp();
                return;
            }
        }
        else
        {
            LeanTween.cancel(go_credits);
            Cursor.visible = isPlay;
        }
    }
    void PlayScene5(bool isPlay)
    {
        DisplayCreditsFromS0();
        if (isPlay)
        {
            if (go_credits.transform.position != startPos)
                go_credits.transform.localPosition = startPos;

            LeanTween.moveLocalY(go_credits, _credits_target, _credits_Duration);
            Cursor.visible = !isPlay;
        }
    }

    void DisplayCreditsFromS0()
    {
        for(int i = 0; i < so_credits.Length; i++)
        {
            so_credits[i].ContentBuilder();
            for (int j = 0; j < so_credits[i]._contentText.Count; j++)
            {
                _textContentConainer += so_credits[i]._contentText[j] + "\n";
                t_credits.text = _textContentConainer;
                t_credits.fontSizeMax = 200f;
            }
        }
    }
}
