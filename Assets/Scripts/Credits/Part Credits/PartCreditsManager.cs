using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PartCreditsManager : MonoBehaviour
{
    // Part Controller
    public bool play;
    [SerializeField] private int _transisionDelay;
    [SerializeField] private int _startDelay;
    [SerializeField] private int _popupOpen;
    [SerializeField] private int _popupClose;

    [SerializeField] private int _id;
    private string _displayTextContainner;

    // Scriptible Object Asset Referance
    [SerializeField] private CreditsScriptibleObject[] _soContainner; // bentuknya array nanti

    // Text Object 
    private GameObject _displayTextObject;
    private TextMeshProUGUI _displayText;

    private void Start()
    {
        _id = 0;
        _displayTextObject = this.gameObject;
        _displayText = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        PlayCredits();
    }

    private void DisplayTextFormScriptibleObject(CreditsScriptibleObject so)
    {
        for (int i = 0; i < so._contentText.Count; i++)
        {
            _displayTextContainner += so._contentText[i] + "\n";
            _displayText.text = so.getJobdesk + "\n" + _displayTextContainner;
        }
    }


    private void PlayCredits()
    {
        if (!play)
            return;

        NextDisplaying(_id);
    }

    private void NextDisplaying(int id)
    {
        StartCoroutine(WaitPopUp(_popupOpen, _displayTextObject));
        DisplayTextFormScriptibleObject(_soContainner[id]);
        StartCoroutine(WaitPopClose(_popupClose, _displayTextObject));
    }

    #region Animation
    private void GetPopup(float intervalTime, GameObject target) => target.LeanScale(Vector2.one, intervalTime);
    private void GetClose(float intervalTime, GameObject target) => target.LeanScale(Vector2.zero, intervalTime).setEaseInBounce();
    #endregion

    IEnumerator WaitPopUp(float interval, GameObject target)
    {
        GetPopup(interval, target);
        yield return new WaitForSeconds(_transisionDelay);
    }

    IEnumerator WaitPopClose (float interval, GameObject target)
    {
        yield return new WaitForSeconds(_transisionDelay);
        GetClose(interval, target);
    }
}
