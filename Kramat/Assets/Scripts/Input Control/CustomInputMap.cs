using UnityEngine.InputSystem;
using UnityEngine;

public class CustomInputMap : MonoBehaviour
{
    private InputControlMap inputMap;
    private static CustomInputMap _instance;

    public static CustomInputMap Instace { get { return _instance; } }

    private void OnEnable() => inputMap.Enable();

    private void OnDisable() => inputMap.Disable();


    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;

        inputMap = new InputControlMap();

    }

    // HardCoded To script
    //#region Movement
    //inputMap.Player.Walking.performed += ctx => GetPlayerMovementWalk();
    //inputMap.Player.Sprint.performed += ctx => GetPlayerSprintTrigger();
    //inputMap.Player.Look.performed += ctx => GetPlayerLookDelta();
    //#endregion

    //#region Player Interact
    //inputMap.Player.Grab.performed += ctx => GetPlayerGrabObject();
    //inputMap.Player.Senter.performed += ctx => GetPlayerSenter();
    //inputMap.Player.NPCInterect.performed += ctx => GetPlayerNPC_ItemInterect();
    //#endregion

    #region Movement
    public Vector2 GetPlayerMovementWalk() => inputMap.Player.Walking.ReadValue<Vector2>();
    public Vector2 GetPlayerLookDelta() => inputMap.Player.Look.ReadValue<Vector2>();
    public bool GetPlayerSprintTrigger() => inputMap.Player.Sprint.triggered;
    #endregion

    #region Interect
    public bool GetPlayerGrabObject() => inputMap.Player.Grab.triggered;
    public bool GetPlayerSenter() => inputMap.Player.Senter.triggered;
    public bool GetPlayerNPC_ItemInterect() => inputMap.Player.NPCInterectGrabObject.triggered;
    #endregion
}
