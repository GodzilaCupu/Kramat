using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialItem : MonoBehaviour
{
    [SerializeField] private GameObject _item;
    [SerializeField] private TutorialState _state;

    private void Start()
    {
        _item = this.gameObject;

        if (_item.active == true)
            _item.SetActive(false);

        EventsManager.current.onSetActiveTutorial += SetActive;
        EventsManager.current.onSetDeactiveTutorial += SetDeactive;
    }

    private void OnDestroy()
    {
        EventsManager.current.onSetActiveTutorial -= SetActive;
        EventsManager.current.onSetDeactiveTutorial -= SetDeactive;
    }

    private void SetActive(TutorialState State)
    {
        if (_state == State)
            _item.SetActive(true);
    }

    private void SetDeactive(TutorialState State)
    {
        if (State == _state)
            _item.SetActive(false);
    }

}
