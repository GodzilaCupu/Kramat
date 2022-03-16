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

    private int _id;
    private string _displayTextContainner;

    // Scriptible Object Asset Referance
    [SerializeField] private CreditsScriptibleObject[] _soContainner; // bentuknya array nanti

    // Text Object 
    private GameObject _displayTextObject;
    private TextMeshProUGUI _displayText;

    private void Start()
    {
        _id = 0;
        _displayTextObject = gameObject.transform.GetChild(0).gameObject;
        _displayText = _displayTextObject.GetComponent<TextMeshProUGUI>();
        DisplayTextFormScriptibleObject(_soContainner[0]);
    }

    private void DisplayTextFormScriptibleObject(CreditsScriptibleObject so)
    {
        for (int i = 0; i < so._contentText.Count; i++)
        {
            _displayTextContainner += so._contentText[i] + "\n";
            _displayText.text = so.getJobdesk + "\n" + _displayTextContainner;
        }
    }

    IEnumerator TransisionDelay() 
    {
        _id++;
        GetClose(_popupClose, _displayTextObject);
        yield return _transisionDelay; 
    }


    private void CreditsManager(CreditsScriptibleObject so)
    {
        if (!play)
            return;
        StartTrasision(0);
    }

    private void StartTrasision(int id)
    {
        DisplayTextFormScriptibleObject(_soContainner[id]);
        GetPopup(_popupOpen, _displayTextObject);
        StartCoroutine(TransisionDelay());
    }

    #region Animation
    private void GetPopup(float intervalTime, GameObject target) => target.LeanScale(Vector2.one, intervalTime);
    private void GetClose(float intervalTime, GameObject target) => target.LeanScale(Vector2.zero, intervalTime).setEaseInBounce();
    #endregion
}
