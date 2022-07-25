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
    private HandleposHandler itemCarrier;

    private void Start()
    {
        itemCarrier = GameObject.Find("Handle Pos").GetComponent<HandleposHandler>();
        go_current = this.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            switch (status)
            {
                case enum_RumahKiDalang.Pintu:
                    if (!itemCarrier.IsCarriedSomething) return;
                    if (itemCarrier.ItemName == "Kunci")
                    {
                        Animator pintu = go_current.GetComponent<Animator>();
                        pintu.SetTrigger("isOpenPintuRumah");
                        itemCarrier.DestroyItem();
                        sources.Play();
                    }
                    break;

                case enum_RumahKiDalang.PintuRuang:
                    if (!itemCarrier.IsCarriedSomething) return;
                    if (itemCarrier.ItemName == "Kalung")
                    {
                        Animator laci = go_current.GetComponent<Animator>();
                        laci.SetTrigger("isOpen");
                        itemCarrier.DestroyItem();
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
