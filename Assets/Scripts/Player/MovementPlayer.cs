using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementPlayer : MonoBehaviour
{
    [Header("Script Reference")]
    [SerializeField] PlayerInput playerInputHandler;
    [SerializeField] CharacterController playerController;

    [Header("Input Action")]
    [SerializeField] InputAction _move;
    [SerializeField] InputAction _sprint;

    [Header("Walking Component")]
    [SerializeField] Vector3 playerVectorMovement;
    [SerializeField] float speedWalk;
    [SerializeField] float speedSprint;

    private void Awake()
    {
        playerController = this.gameObject.GetComponent<CharacterController>();
        playerInputHandler = this.gameObject.GetComponent<PlayerInput>();

        _move = playerInputHandler.actions["Walking"];
        _sprint = playerInputHandler.actions["Sprint"];
        
    }

    public void Update()
    {
        playerMovement();
    }


    void playerMovement()
    {
        Vector2 inputAxis = _move.ReadValue<Vector2>();

        if (_sprint.ReadValue<float>() == 1) playerController.Move(new Vector3(inputAxis.x, 0, inputAxis.y) * speedSprint * Time.deltaTime);
        else playerController.Move(new Vector3(inputAxis.x, 0, inputAxis.y) * speedWalk * Time.deltaTime);
    }


}
