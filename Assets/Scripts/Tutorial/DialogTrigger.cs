using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] enum_TutorialState id;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            EventsManager.current.CheckProgresTutorial(((int)id));
            if (id != enum_TutorialState.Credits)
                EventsManager.current.DialougeTrigger(true);

        }
    }
}
