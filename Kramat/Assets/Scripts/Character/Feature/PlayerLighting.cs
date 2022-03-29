using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class PlayerLighting : MonoBehaviour
{
    [SerializeField] private PlayerEventHandlerSO e_PlayerSO;
    [SerializeField] private Light senter;

    private void Start()
    {
        senter = GetComponent<Light>();
    }

    private void OnEnable() => e_PlayerSO.e_Lighting += SetLighting;

    private void OnDisable() => e_PlayerSO.e_Lighting -= SetLighting;

    void SetLighting()
    {
        switch (senter.enabled)
        {
            case false:
                senter.enabled = true;
                break;

            case true:
                senter.enabled = false;
                break;
        }
    }
}
