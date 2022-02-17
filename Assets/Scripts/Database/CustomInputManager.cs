using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomInputManager : MonoBehaviour
{
    private InputPlayer playerControl;
    private static CustomInputManager _instance;

    public static CustomInputManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;

        playerControl = new InputPlayer();
    }

    private void OnEnable() => playerControl.Enable();

    private void OnDisable() => playerControl.Disable();

    public Vector2 GetPlayerMovement() => playerControl.Pemain.Walking.ReadValue<Vector2>();

    public Vector2 GetMouseDelta() => playerControl.Pemain.LookMouse.ReadValue<Vector2>();

    public float GetPlayerSprint() => playerControl.Pemain.Sprint.ReadValue<float>();
}
