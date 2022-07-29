using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Light))]
public class PlayerLighting : MonoBehaviour
{
    [SerializeField] private Light senter;
    private bool isBlinking = false;

    [SerializeField] private float timerToBlink;
    private float blinkTime;

    private void Start()
    {
        blinkTime = timerToBlink;
        EventsManager.current.onFlashlightTrigger += SetLighting;
        if (SceneManager.GetActiveScene().name == "Kulon")
            EventsManager.current.onFlashlightBlinking += (v) => isBlinking = v;

    }

    private void Update()
    {
        FlashLightBlinking(isBlinking);
    }

    private void OnDisable()
    {
        EventsManager.current.onFlashlightTrigger -= SetLighting;
        if (SceneManager.GetActiveScene().name == "Kulon")
            EventsManager.current.onFlashlightBlinking -= (v) => isBlinking = v;

    }

    void SetLighting() => senter.enabled = senter.enabled == true ? senter.enabled = false : senter.enabled = true;

    void FlashLightBlinking(bool blinking)
    {
        if (!blinking) return;

        if(blinkTime == 0)
        {
            senter.enabled = false;
            blinkTime = timerToBlink;
            return;
        }

        senter.enabled = true;
        blinkTime -= Time.deltaTime;
    }
}
