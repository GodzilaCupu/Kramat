using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSawahHandler : MonoBehaviour
{   
    private int TaskSawah = ((int)enum_WetanState.MenggemburkanTanah);
    private int progresId;

    [SerializeField] private List<SawahHandler> Sawah;
    public int sawahDone;

    private void Start()
    {
        EventsManager.current.onWetanProgres += GetProgres;
    }

    private void OnDisable()
    {
        EventsManager.current.onWetanProgres += GetProgres;
    }

    private void GetProgres(int progres) => progresId = progres;

}
