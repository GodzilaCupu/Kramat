using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KulonDialogueTriggerHandler : MonoBehaviour
{
    [SerializeField] private int idTrigger;
    private int idKulon;
    // Start is called before the first frame update
    void Start()
    {
        EventsManager.current.onKulonProgres += (v) => idKulon = v;

    }

    private void OnDisable()
    {
        EventsManager.current.onKulonProgres -= (v) => idKulon = v;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CheckDialogue();
        }
    }

    private void CheckDialogue()
    {
        switch (idTrigger)
        {
            case 1:
                if(idKulon == 1)
                    EventsManager.current.KulonPlayDialog(1);
                break;

            case 2:
                if (idKulon == 1) 
                {
                    EventsManager.current.CheckKulonProgres(2);
                    EventsManager.current.KulonPlayDialog(2);
                }
                break;

            case 3:
                if (idKulon == 3)
                    EventsManager.current.KulonPlayDialog(3);
                break;

        }
    }
}
