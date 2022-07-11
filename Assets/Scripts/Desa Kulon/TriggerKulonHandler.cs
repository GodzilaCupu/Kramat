using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enum_TriggerKulon
{
    AnakSetan,
    RumahKidalang,
    GapuraBosFight
}

public class TriggerKulonHandler : MonoBehaviour
{
    [SerializeField] private enum_TriggerKulon triggerID;
    private int progresID;
    // Start is called before the first frame update
    void Start()
    {
        EventsManager.current.onKulonProgres += (v) => progresID = v;
    }

    private void OnDisable()
    {
        EventsManager.current.onKulonProgres -= (v) => progresID = v;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        switch (triggerID)
        {
            case enum_TriggerKulon.AnakSetan:
                if (progresID != 0) return;

                EventsManager.current.KulonPlayDialog(1);
                EventsManager.current.DialougeTrigger(true);
                break;


            case enum_TriggerKulon.RumahKidalang:
                if (progresID != 0) return;

                EventsManager.current.KulonPlayDialog(2);
                EventsManager.current.DialougeTrigger(true);
                break;

            case enum_TriggerKulon.GapuraBosFight:
                if (progresID != 3) return;
                EventsManager.current.CheckKulonProgres(4);
                break;
        }
    }
}
