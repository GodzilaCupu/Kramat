using UnityEngine;

public class CustomInputMap : MonoBehaviour
{
    private InputControlMap inputMap;

    public static CustomInputMap current;

    void Awake()
    {
        if (current != null && current != this)
            Destroy(this);
        else current = this;

        inputMap = new InputControlMap();
    }

    private void OnEnable()
    {
        inputMap.Player.Enable();

        inputMap.Player.Sprint.performed += ctx => GetPlayerSprintTrigger = true;
        inputMap.Player.Sprint.canceled += ctx => GetPlayerSprintTrigger = false;
    }

    private void OnDisable()
    {
        inputMap.Player.Disable();

        inputMap.Player.Sprint.performed -= ctx => GetPlayerSprintTrigger = true;
        inputMap.Player.Sprint.canceled -= ctx => GetPlayerSprintTrigger = false;
    }

    #region Movement
    public Vector2 GetPlayerMovementWalk() => inputMap.Player.Walking.ReadValue<Vector2>();
    public Vector2 GetPlayerLookDelta() => inputMap.Player.Look.ReadValue<Vector2>();
    public bool GetPlayerSprintTrigger;
    #endregion

    #region Interect
    public bool GetPlayerGrabObject() => inputMap.Player.Grab.triggered;
    public bool GetPlayerSenter() => inputMap.Player.Senter.triggered;
    public bool GetPlayerNPC_ItemInterect() => inputMap.Player.NPCInterectGrabObject.triggered;
    public bool GetDialogSkip() => inputMap.Player.Skip_Dialog.triggered;
    public bool GetPaused() => inputMap.Player.Pause.triggered;
    #endregion
}
