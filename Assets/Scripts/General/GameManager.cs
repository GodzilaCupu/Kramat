using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CustomInputManager))]
public class GameManager : MonoBehaviour
{
    [Header ("Script Reference")]
    private CustomInputManager inputManager;
    private SettingsManager settingsManager;
    [SerializeField] private CameraRaycast _raycast;

    [Header("Panel")]
    [SerializeField] private List<GameObject> panelGame;

    [Header("Variable")]
    private RaycastHit ray;


    private void Start()
    {
        inputManager = GetComponent<CustomInputManager>();
        settingsManager = panelGame[0].GetComponent<SettingsManager>();
        settingsManager.SettingsValue();
        
    }

    private void Update() 
    {
        GetObject();
    }

    private void GetPause()
    {
        if(inputManager.GetESCPressed() != 1)
        {
            
        }
    }

    private void GetObject()
    {
        if(inputManager.GetPickedObject() != 0)
        {
            _raycast.CrosshairRaycast();
        }else
            _raycast.CrosshairRaycast();

    }

    private void GetPanelValue()
    {
        panelGame.Add(settingsManager.gameObject);

        for(int i = 0;i<panelGame.Count;i++){
            if(panelGame[i].active != false) 
                panelGame[i].SetActive(false);
        } 
    }
}
