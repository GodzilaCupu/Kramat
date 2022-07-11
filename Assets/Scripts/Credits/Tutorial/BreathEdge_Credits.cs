using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class BreathEdge_Credits : MonoBehaviour
{
    [Header("Panel Configurations")]
    [SerializeField] private GameObject go_Panel;
    [SerializeField] private TextMeshProUGUI t_TextCredits;
    [SerializeField,TextArea(3,5)] private string[] s_TextCredits;

    [Header ("Canvas Group "),Space(5)]
    private CanvasGroup cg_Panel;
    
    [Header ("Gamelan Properties"),Space(15)]
    [SerializeField] private bool _isPlay;
    
    [Header ("Timer "),Space(5)]
    [SerializeField] private float _timer = 10;
    private float _countDown;

    [Header ("Progres"),Space(5)]
    private int _currentId  = 0;
    private int _nextId = 0;

    private void Start() 
    {
        t_TextCredits.GetComponent<CanvasGroup>().alpha = 1f;

        _countDown = _timer;
        t_TextCredits.text = s_TextCredits[_currentId];
        cg_Panel = go_Panel.GetComponent<CanvasGroup>();

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
        SetTextToCenter();
        t_TextCredits.text = s_TextCredits[id];
        LeanTween.alphaCanvas(cg_Panel,1f,0.5f);
    }
    
    private void NextCredits()
    {   
        if(_currentId > s_TextCredits.Length){
            _isPlay = false;
            EventsManager.current.CloseCredits();
            EventsManager.current.CheckProgresTutorial(((int)enum_TutorialState.Bumper));
        }

        if(_currentId < _nextId){
            _currentId = _nextId;
        }
    }

    private void ShowCredits(int id){
        if(_countDown > 0)
        {
            SetText(id);
            _countDown -= Time.deltaTime;
        }
        else
        {
            LeanTween.alphaCanvas(cg_Panel,0f,0.5f);
            if(cg_Panel.alpha < 0.3f)
            {
                _nextId = (id) + 1;
                _countDown = _timer;
            }
        }
    }

    private void SetTextToCenter(){
        RectTransform rt_Panel = t_TextCredits.gameObject.GetComponent<RectTransform>();
        rt_Panel.anchoredPosition = Vector2.zero;
    }
}
