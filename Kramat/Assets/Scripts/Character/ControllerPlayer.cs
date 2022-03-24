using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ControllerPlayer : MonoBehaviour
{
    [SerializeField] private CustomInputMap _inputMap;
    [SerializeField] private Transform cameraPos;

    [SerializeField] private float gravity = -15f;
    [SerializeField] private float falloutTimeout = 0.15f;
    [SerializeField] private bool isGround = true;
    [SerializeField] private float groundOffset = -0.14f;
    [SerializeField] private float groundRadius = 0.5f;
    [SerializeField] private float speedChangeRate = 10f;
    [SerializeField] private LayerMask groundLayer;

    private float _falloutTimeoutDelta;
    private float _verticalVelocity;
    private float _terminalVelocity = 53.0f;

    [SerializeField] private float playerSpeedWalk;
    [SerializeField] private float playerSpeedSprint;
    private float speed;

    private CharacterController controller;


    [SerializeField] private float animationSmoothTime;
    [SerializeField] private Animator anim;
    private Vector3 playerVelocity;
    [SerializeField] private int moveXParameterAnimationID;
    [SerializeField] private int moveZParameterAnimationID;
    [SerializeField] private int isRunning;

    private Vector2 animationTransisionBlend;
    private Vector2 animationVelocity;

    private const float _threshold = 0.01f;
    private float _cinemachineTargetPitch;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        moveXParameterAnimationID = Animator.StringToHash("MoveX");
        moveZParameterAnimationID = Animator.StringToHash("MoveZ");
        isRunning = Animator.StringToHash("Running");
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        Gravity();
        PlayerMovement();
    }

    private void LateUpdate()
    {
        
    }

    void PlayerMovement()
    {
        Vector2 playerInputMovement = _inputMap.GetPlayerMovementWalk();

        animationTransisionBlend = Vector2.SmoothDamp(animationTransisionBlend, playerInputMovement, ref animationVelocity, animationSmoothTime);
        Vector3 playerMove = new Vector3(animationTransisionBlend.x, 0f, animationTransisionBlend.y).normalized;
        

        float targetSpeed = _inputMap.GetPlayerSprintTrigger() == 1 ? playerSpeedSprint : playerSpeedWalk;
        

        if (_inputMap.GetPlayerMovementWalk() == Vector2.zero) targetSpeed = 0.0f;

        float currentHorizontalspeed = new Vector3(controller.velocity.x, 0.0f, controller.velocity.z).magnitude;

        float speedOffset = 0.1f;

        if (currentHorizontalspeed < targetSpeed - speedOffset || currentHorizontalspeed > targetSpeed + speedOffset)
        {
            speed = Mathf.Lerp(currentHorizontalspeed, targetSpeed, Time.deltaTime * speedChangeRate);
            speed = Mathf.Round(speed * 1000f) / 1000f;
        }
        else
            speed = targetSpeed;

        Vector3 move = playerMove.x * transform.right + playerMove.z * transform.forward;
        
        if(_inputMap.GetPlayerMovementWalk() != Vector2.zero)
            move = cameraPos.forward * move.z + cameraPos.right * move.x;


        //SetAnimation
        PlayAnimation();

        controller.Move(move.normalized * (speed * Time.deltaTime) + new Vector3(0f, _verticalVelocity, 0f) * Time.deltaTime);
    }


    private void PlayAnimation()
    {
        switch (_inputMap.GetPlayerSprintTrigger())
        {
            case 0:
                anim.SetBool(isRunning, false);
                anim.SetFloat(moveXParameterAnimationID, animationTransisionBlend.x);
                anim.SetFloat(moveZParameterAnimationID, animationTransisionBlend.y);
                break;

            case 1:
                anim.SetBool(isRunning, true);
                anim.SetFloat(moveXParameterAnimationID, animationTransisionBlend.x);
                anim.SetFloat(moveZParameterAnimationID, animationTransisionBlend.y);
                break;
        }
    }

    private void Gravity()
    {
        if (isGround)
        {
            _falloutTimeoutDelta = falloutTimeout;

            if (_verticalVelocity < 0.0f)
                _verticalVelocity = -2f;
        }
        else
        {
            if(_falloutTimeoutDelta >= 0f)
                _falloutTimeoutDelta -= Time.deltaTime;

        }

        if (_verticalVelocity < _terminalVelocity)
            _verticalVelocity += gravity * Time.deltaTime;
    }

    private void GroundCheck()
    {
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - groundOffset, transform.position.z);
        isGround = Physics.CheckSphere(spherePosition, groundRadius, groundLayer, QueryTriggerInteraction.Ignore);
    }

    //private void CameraRotation()
    //{
    //    // if there is an input
    //    if (_inputMap.GetPlayerLookDelta().sqrMagnitude >= _threshold)
    //    {
    //        _cinemachineTargetPitch += _inputMap.GetPlayerLookDelta().y * RotationSpeed * Time.deltaTime;
    //        _rotationVelocity = _input.look.x * RotationSpeed * Time.deltaTime;

    //        // clamp our pitch rotation
    //        _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

    //        // Update Cinemachine camera target pitch
    //        CinemachineCameraTarget.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, 0.0f, 0.0f);

    //        // rotate the player left and right
    //        transform.Rotate(Vector3.up * _rotationVelocity);
    //    }
    //}

    private void OnDrawGizmosSelected()
    {
        Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);
        Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);

        if (isGround) Gizmos.color = transparentGreen;
        else Gizmos.color = transparentRed;

        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - groundOffset, transform.position.z), groundRadius);

    }
}
