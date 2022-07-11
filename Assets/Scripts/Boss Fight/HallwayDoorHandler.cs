using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayDoorHandler : MonoBehaviour
{

    [SerializeField] private GameObject go_Pintu;
    private Animator animPintu;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            animPintu = go_Pintu.GetComponent<Animator>();
            animPintu.SetTrigger("isOpenPintuCandi_BosFight");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Collider thisCol = gameObject.GetComponent<BoxCollider>();
            animPintu = go_Pintu.GetComponent<Animator>();
            animPintu.SetTrigger("isClosePintuCandi_BosFight");
            EventsManager.current.BosFightProgres(((int)enum_GenderuwoState.Genderuwo1));
            EventsManager.current.DialougeTrigger(true);
            thisCol.enabled = false;
        }
    }
}
