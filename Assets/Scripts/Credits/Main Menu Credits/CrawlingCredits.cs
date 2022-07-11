using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CrawlingCredits : MonoBehaviour
{
    [Header("Animation Properties")]
    [SerializeField] private float _credits_target = 18000f;
    [SerializeField] private float _credits_Duration = 35f;
    [SerializeField] private Vector3 startPos;

    [Header("Credtis Component"),Space(20)]
    [SerializeField] private CreditsScriptibleObject[] so_credits;
    [SerializeField] private TextMeshProUGUI t_credits;
    [SerializeField] private GameObject go_credits;

    private string _textContentConainer;

    private void Start()
    {
        startPos = new Vector3(0, -1000, 0);
        EventsManager.current.onPlayCredits += PlayCredits;
    }

    private void OnDisable()
    {
        EventsManager.current.onPlayCredits -= PlayCredits;
    }        

    void PlayCredits(bool isPlay)
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

            LeanTween.moveLocalY(go_credits, _credits_target, _credits_Duration);
            if (go_credits.transform.localPosition == new Vector3(go_credits.transform.localPosition.x, _credits_target, go_credits.transform.localPosition.z)) SceneManager.LoadScene("MainMenu");
        }
        else
        {
            LeanTween.cancel(go_credits);
            Cursor.visible = isPlay;
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
