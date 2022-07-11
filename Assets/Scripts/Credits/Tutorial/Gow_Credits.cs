using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Gow_Credits : MonoBehaviour
{
    [Header("Panel Configurations")]
    [SerializeField] private GameObject go_Panel;
    [SerializeField] private TextMeshProUGUI t_TextCredits;
    [SerializeField] private string[] s_TextCredits;

    [Header ("Canvas Group "),Space(5)]
    private CanvasGroup cg_TextCredits;
    
    [Header ("Gamelan Properties"),Space(15)]
    [SerializeField] private bool _isPlay;
    
    [Header ("Timer "),Space(5)]
    [SerializeField] private float _timer = 10;
    private float _countDown;

    [Header ("Progres"),Space(5)]
    private int _currentId  = 0;

    private void Start() 
    {
        _countDown = _timer;
        t_TextCredits.text = s_TextCredits[_currentId];

        cg_TextCredits = t_TextCredits.GetComponent<CanvasGroup>();   

        EventsManager.current.onPlayCredits += CheckPlay;
    }

    private void Update()
    {
        NextCredits();
        if(_isPlay)
            ShowCredits(_currentId);
    }

    private void OnDisable() =>  EventsManager.current.onPlayCredits -= CheckPlay;

    private void CheckPlay(bool isplay) => _isPlay = isplay ? true : false;

    private void SetText(int id){
        t_TextCredits.text = s_TextCredits[id];
        LeanTween.alphaCanvas(cg_TextCredits,1f,0.5f);
    }
    
    private void NextCredits()
    {   
        if(_currentId < s_TextCredits.Length) 
            return;

        _isPlay = false;
        EventsManager.current.CloseCredits();
        EventsManager.current.CheckProgresTutorial(((int)enum_TutorialState.Bumper));
    }

    private void ShowCredits(int id){
        if(_countDown > 0)
        {
            SetText(id);
            _countDown -= Time.deltaTime;
        }
        else
        {
            LeanTween.alphaCanvas(cg_TextCredits,0f,0.5f);
            if(cg_TextCredits.alpha < 0.3f)
            {
                _currentId = (id) + 1;
                _countDown = _timer;
            }
        }
    }
}