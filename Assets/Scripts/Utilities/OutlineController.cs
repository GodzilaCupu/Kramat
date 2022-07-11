using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class OutlineController : MonoBehaviour
{
    private bool isOn;
    private Outline outline;

    private void Start()
    {
        outline = GetComponent<Outline>();
        EventsManager.current.onRaycast += (v) => isOn = v;
    }

    private void OnDisable()
    {
        EventsManager.current.onRaycast -= (v) => isOn = v;
    }

    private void Update()
    {
        if (isOn)
        {
            outline.enabled = true;
            return;
        }
        outline.enabled = false;
    }
}
