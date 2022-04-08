using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TutorialState
{
    MouseLook,
    Movement,
    Flashlight,
    Run,
    Credits,
    End
}

public class TutorialHandler : MonoBehaviour
{
    [SerializeField] private bool _spawn;
    [SerializeField] private float _targetTimer = 10;

    bool _startCountTimer;
    float _currentTimer;
    int _currentTutorial = 1;


    private void Start()
    {
        _currentTimer = _targetTimer;
        StartTutorial();
    }

    private void OnEnable()
    {
        EventsManager.current.onNextTutorial += TutorialManager;
    }

    private void OnDisable()
    {
        EventsManager.current.onNextTutorial -= TutorialManager;
    }


    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    #region Spawanner

    private void ActivationTutor(TutorialState State) => EventsManager.current.SetActiveTutorial(State);
    private void DeactivationTutor(TutorialState State) => EventsManager.current.SetDeactiveTutorial(State);

    private void TutorTimer(TutorialState State) 
    {
        ActivationTutor(State);

        if (_startCountTimer == false)
            _startCountTimer = true;
        else
            DeactivationTutor(State);

    }

    private void Timer()
    {
        if (_startCountTimer)
        {
            if (_currentTimer > 0)
            {
                _currentTimer -= Time.deltaTime;
                Debug.Log($"Ur time {_currentTimer}");
            }
            else
            {
                _currentTimer = _targetTimer;
                _startCountTimer = false;
                Debug.Log($"Ur time {_currentTimer}");
            }
            Debug.Log($"Ur count {_startCountTimer}");
        }
    }
    #endregion

    #region Tutorial Management
    private void StartTutorial()
    {
        TutorTimer(TutorialState.MouseLook);
        TutorTimer(TutorialState.Movement);
        _currentTutorial++;
        Debug.Log($"Ur id {_currentTutorial}");
    }


    private void TutorialManager(int id)
    {
        switch (id)
        {
            case 2:
                TutorTimer(TutorialState.Flashlight);
                _currentTutorial++;
                Debug.Log($"Ur id {_currentTutorial}");

                break;

            case 3:
                TutorTimer(TutorialState.Flashlight);
                Debug.Log($"Ur id {_currentTutorial}");
                break;

            default:
                Debug.Log($"Check Ur id {_currentTutorial}");
                break;

        }
    }

    #endregion
}
