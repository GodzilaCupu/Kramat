using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enum_RumahKiDalang
{
    Pintu,
    PintuRuang,
    BosFight
}

public class PintuKiDalangHandler : MonoBehaviour
{
    [SerializeField] private enum_RumahKiDalang status;
    [SerializeField] private GameObject go_current;
    [SerializeField] private AudioSource sources;
    private ControllerPlayer player;

    private void Start()
    {
        go_current = this.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            switch (status)
            {
                case enum_RumahKiDalang.Pintu:
                    player = other.gameObject.GetComponent<ControllerPlayer>();
                    if (!player.CarriedSomthing) return;
                    if (player.ItemCarried == "Kunci")
                    {
                        Animator pintu = go_current.GetComponent<Animator>();
                        pintu.SetTrigger("isOpenPintuRumah");
                        player.ItemKulon();
                        sources.Play();
                    }
                    break;

                case enum_RumahKiDalang.PintuRuang:
                    player = other.gameObject.GetComponent<ControllerPlayer>();
                    if (!player.CarriedSomthing) return;
                    if (player.ItemCarried == "Kalung")
                    {
                        Animator laci = go_current.GetComponent<Animator>();
                        laci.SetTrigger("isOpen");
                        player.ItemKulon();
                        sources.Play();
                    }
                    break;

                case enum_RumahKiDalang.BosFight:
                    KulonStoryHandler storyHandler = GameObject.Find("GameManager").GetComponent<KulonStoryHandler>();

                    if (storyHandler.ProgresID != 4) return;

                    Animator gerbang = go_current.GetComponent<Animator>();
                    gerbang.SetTrigger("isOpenPintuCandi_Wetan");
                    break;
            }
        }
    }
}
