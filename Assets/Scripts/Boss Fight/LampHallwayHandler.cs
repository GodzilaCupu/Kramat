using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampHallwayHandler : MonoBehaviour
{
    [SerializeField] List<GameObject> lampHallway;
    [SerializeField] List<GameObject> lampArena;

    private void Start()
    {
        GetLamp(false,lampArena);
        GetLamp(true,lampHallway);
        EventsManager.current.onDoorHallwayPast += SetLamp;
    }


    private void OnDisable()
    {
        EventsManager.current.onDoorHallwayPast -= SetLamp;

    }

    private void SetLamp()
    {
        GetLamp(true, lampArena);
        GetLamp(false, lampHallway);
    }

    private void GetLamp(bool isOn,List<GameObject> objLamp)
    {
        foreach (GameObject lampu in objLamp)
        {
            // Get Particle
            GameObject childParticleParent = lampu.transform.GetChild(1).gameObject;
            GameObject childParticle = childParticleParent.transform.GetChild(0).gameObject;

            //GetLight
            Light childLamp = lampu.transform.GetChild(2).gameObject.GetComponent<Light>();

            childLamp.enabled = isOn;
            childParticle.SetActive(isOn);
        }
    }
}
