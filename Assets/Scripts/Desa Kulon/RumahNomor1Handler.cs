using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumahNomor1Handler : MonoBehaviour
{
    private int idKulon;
    [SerializeField] private GameObject Pintu;
    void Start()
    {
        EventsManager.current.onKulonProgres += (v) => idKulon = v;
    }

    private void OnDisable()
    {
        EventsManager.current.onKulonProgres -= (v) => idKulon = v;
    }

    private void Update()
    {
        CheckTask();
    }

    private void CheckTask()
    {
        if (idKulon == 2)
        {
            Pintu.SetActive(false);
            return;
        }
    }
}
