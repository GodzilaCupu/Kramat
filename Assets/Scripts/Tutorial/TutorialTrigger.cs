using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField] private int Id;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player")
            EventsManager.current.SetNextTutorial(Id);
    }
}
