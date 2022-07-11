using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingTips : MonoBehaviour
{
    [SerializeField] private float timer;

    [SerializeField] private TextMeshProUGUI t_TipsJawa;
    [SerializeField] private TextMeshProUGUI t_TipsTranslate;

    [SerializeField, TextArea(3, 6)] List<string> s_tipsJawa;
    [SerializeField, TextArea(3, 6)] List<string> s_tipsTranslate;

    private CanvasGroup c_tips;

    private int displayTips;

    // Start is called before the first frame update
    void Start()
    {
        t_TipsJawa = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        t_TipsTranslate = this.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        c_tips = this.gameObject.GetComponent<CanvasGroup>();
        StartCoroutine(GetRandomizeTips());
    }

    IEnumerator GetRandomizeTips()
    {
        displayTips = Random.Range(0, s_tipsJawa.Count);
        t_TipsJawa.text = s_tipsJawa[displayTips];
        t_TipsTranslate.text = s_tipsTranslate[displayTips];

        LeanTween.alphaCanvas(c_tips, 1, 0.3f);
        
        yield return new WaitForSeconds(timer);

        LeanTween.alphaCanvas(c_tips, 0, 0.3f);

        yield return new WaitForSeconds(0.5f);

        displayTips = displayTips >= s_tipsJawa.Count ? displayTips = 0 : displayTips++;

        t_TipsJawa.text = s_tipsJawa[displayTips];
        t_TipsTranslate.text = s_tipsTranslate[displayTips];
        LeanTween.alphaCanvas(c_tips, 1, 0.3f);
    }
}
