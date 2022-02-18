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


    //[Header("Variable")]
    //private bool _inRange, _onTrack;
    
    private void Start()
    {
        inputManager = GetComponent<CustomInputManager>();
        settingsManager = panelGame[0].GetComponent<SettingsManager>();
        settingsManager.SettingsValue();

        GameObject raycastGO = GameObject.FindGameObjectWithTag("MainCamera");
        _raycast = raycastGO.GetComponent<CameraRaycast>();

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
        if (_raycast.onTrack())
        {
            _raycast.ChangeCrosshairColor(Color.blue);
            if (_raycast.inRange())
            {
                _raycast.ChangeCrosshairSize(1.5f);
                if(inputManager.GetPickedObject() != 0)
                {
                    _raycast.CrosshairRaycast();
                    _raycast.ChangeCrosshairColor(Color.green);
                }
            }
            else
                _raycast.ChangeCrosshairSize(1f);
        }
        else
            _raycast.ChangeCrosshairColor(Color.black);

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
