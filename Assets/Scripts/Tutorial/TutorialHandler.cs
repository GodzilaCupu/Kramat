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
    [SerializeField] private float _targetTimer = 10;

    private float _currentTimer;
    int _currentTutorial;


    private void Start()
    {
        _currentTimer = _targetTimer;
        _currentTutorial = 1;
    }

    private void Update()
    {
        if(_currentTutorial < 4)
            CheckTutorialProgres(_currentTutorial);
    }


    private void OnEnable()
    {
        EventsManager.current.onNextTutorial += NextTutorial;
    }

    private void OnDisable()
    {
        EventsManager.current.onNextTutorial -= NextTutorial;
    }

    #region Spawanner

    private void ActivationTutor(TutorialState State) => EventsManager.current.SetActiveTutorial(State);
    private void DeactivationTutor(TutorialState State) => EventsManager.current.SetDeactiveTutorial(State);

    #endregion

    #region Tutorial Manager

    private void NextTutorial(int id) => _currentTutorial = id;

    private void CheckTutorialProgres(int id)
    {
        switch (id)
        {
            case 1:
                DisplayStartTutorial(TutorialState.MouseLook, TutorialState.Movement);
                Debug.Log($"Ur id {_currentTutorial}");
                break;

            case 2:
                DisplayNextTutorial(TutorialState.Flashlight);
                Debug.Log($"Ur id {_currentTutorial}");

                break;

            case 3:
                DisplayNextTutorial(TutorialState.Flashlight);
                _currentTutorial = 2;
                Debug.Log($"Ur id {_currentTutorial}");
                break;

            default:
                Debug.Log($"Check Ur id {_currentTutorial}");
                break;
        }
    }

    #endregion

    #region Timer

    private void DisplayNextTutorial(TutorialState State)
    {
        ActivationTutor(State);
        if (_currentTimer > 0)
        {
            _currentTimer -= Time.deltaTime;
            Debug.Log($"Ur time {_currentTimer}");
        }
        else
        {
            DeactivationTutor(State);
            _currentTimer = _targetTimer;
            Debug.Log($"Ur time {_currentTimer}");
            _currentTutorial = 0;
        }
    }

    private void DisplayStartTutorial(TutorialState State1, TutorialState State2)
    {
        ActivationTutor(State1);
        ActivationTutor(State2);
        if (_currentTimer > 0)
        {
            _currentTimer -= Time.deltaTime;
            Debug.Log($"Ur time {_currentTimer}");
        }
        else
        {
            DeactivationTutor(State1);
            DeactivationTutor(State2);
            _currentTimer = _targetTimer;
            Debug.Log($"Ur time {_currentTimer}");
            _currentTutorial = 0;
        }
    }
    #endregion
}
