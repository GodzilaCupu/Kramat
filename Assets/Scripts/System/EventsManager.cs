using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager current;
    void Awake()
    {
        if (current != null && current != this) Destroy(this);
        else current = this;
    }

    #region Tutorial

    public event Action<TutorialState> onSetActiveTutorial;
    public event Action<TutorialState> onSetDeactiveTutorial;
    public event Action<int> onNextTutorial;    
    public void SetActiveTutorial(TutorialState state) => onSetActiveTutorial?.Invoke(state);
    public void SetDeactiveTutorial(TutorialState state) => onSetDeactiveTutorial?.Invoke(state);
    public void SetNextTutorial(int id) => onNextTutorial?.Invoke(id);

    #endregion

}
