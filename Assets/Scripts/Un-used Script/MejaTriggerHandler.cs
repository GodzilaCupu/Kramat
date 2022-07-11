using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejaTriggerHandler : MonoBehaviour
{
    [SerializeField] private GameObject go_desk;
    [SerializeField] private Transform t_drop;
    [SerializeField] private AudioClip aclip_dropsound;
    
    private AudioSource asource_desk;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GetDrop();
        }
    }

    public void GetDrop()
    {
        EventsManager.current.CheckKulonProgres(3);
        go_desk.transform.position = t_drop.position;
        go_desk.transform.rotation = t_drop.rotation;
        asource_desk.Play();
    }
}