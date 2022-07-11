using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBanaspati : MonoBehaviour
{
    [SerializeField] private BanaspatiHandler banaspati;
    private int idKulon;

    private void Update()
    {
        idKulon = banaspati.kulonProgres;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            banaspati.CanChasing = banaspati.CanChasing == true ? false : true;
    }
       
}
