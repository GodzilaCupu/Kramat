using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ControllerPlayer : MonoBehaviour
{
    [Header("Input Player")]
    [SerializeField] private CustomInputMap _inputMap;
    private CharacterController controller;

    [Space(15)]
    [Header("Player Configuration")]
    [SerializeField] private float playerSpeedWalk;
    [SerializeField] private float playerSpeedSprint;
    [SerializeField] private float speedChangeRate = 10f;
    private float _speed;

    private bool isRunning;
    private bool isMoving;

    [Space(8)]
    [SerializeField] private float gravity = -15f;
    [SerializeField] private bool isGround = true;

    [Space(8)]
    [SerializeField] private float groundOffset = -0.14f;
    [SerializeField] private float groundRadius = 0.5f;
    [SerializeField] private LayerMask groundLayer;

    [Space(8)]
    [SerializeField] private float terminalVelocity = 53.0f;
    [SerializeField] private float falloutTimeout = 0.15f;
    private float _falloutTimeoutDelta;
    private float _verticalVelocity;

    [Space(15)]
    [Header("Animation Configuration")]
    [InspectorLabel_Override("Player Anim")]
    [SerializeField] private Animator anim;

    [Space(8)]
    [SerializeField] private float animationSmoothTime;

    [Space(8)]
    private int runAnimatorID;
    private int moveXParameterAnimationID;
    private int moveZParameterAnimationID;

    private Vector2 _animationTransisionBlend;
    private Vector2 _animationVelocity;

    [Space(15)]
    [Header("Camera Configuration")]
    [SerializeField] private GameObject cameraTarget;
    //[SerializeField] private GameObject kepala;

    private float _startCameraPos; 
    private float _timerHeadbob;

    [Space(8)]
    [SerializeField] private float topClamp;
    [SerializeField] private float bottomClamp;
    [SerializeField] private float rotationSpeed;

    private float _rotationVelocity;
    private float _cinemachineTargetPitch;

    private const float _threshold = 0.01f;

    [Space(8)]
    [Header("HeadBob")]
    [SerializeField] private bool useHeadBob;

    [Tooltip("Kecepatan Naik Turun HeadBob pas lagi jalan")]
    [SerializeField] private float walkingHeadBobSpeed;
    [Tooltip("Jarak Naik Turun HeadBob pas lagi jalan")]
    [SerializeField] private float walkingHeadBobAmmount;

    [Tooltip("Kecepatan Naik Turun HeadBob pas lagi lari")]
    [SerializeField] private float runningHeadBobSpeed;    
    [Tooltip("Jarak Naik Turun HeadBob pas lagi lari")]
    [SerializeField] private float runningHeadBobAmmount;

    [SerializeField] private float headbobSmothingtime;

    [Space(15)]
    [Header("SFX Configuration")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] List<AudioClip> footstepAudio = new List<AudioClip>();
    [SerializeField] [Range(0f, 1f)] private float m_RunstepLenghten;
    [SerializeField] private float stepInterval;

    private float _stepCycle;
    private float _nextStep;

    //private FootstepSFXSwapper _sfxSwapper;

    [Space(15)]
    [Header("Event Scriptable Object")]
    [SerializeField] private PlayerEventHandlerSO e_playerSO;

    void Start()
    {
        //_sfxSwapper = GetComponent<FootstepSFXSwapper>();
        controller = GetComponent<CharacterController>();
        _inputMap = GetComponent<CustomInputMap>();
        anim = GetComponent<Animator>();

        moveXParameterAnimationID = Animator.StringToHash("MoveX");
        moveZParameterAnimationID = Animator.StringToHash("MoveZ");
        runAnimatorID = Animator.StringToHash("Running");
        _startCameraPos = cameraTarget.transform.localPosition.y;

    }

    private void Update()
    {
        HeadBobHandler();
        FiturSenter();
    }

    // Update is called once per frame indepedent
    private void FixedUpdate()
    {
        GroundCheck();
        Gravity();
        PlayerMovement();
    }

    private void LateUpdate()
    {
        CameraRotation();
    }

    #region Player Movement

    private void GroundCheck()
    {
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - groundOffset, transform.position.z);
        isGround = Physics.CheckSphere(spherePosition, groundRadius, groundLayer, QueryTriggerInteraction.Ignore);
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
            if (_falloutTimeoutDelta >= 0f)
                _falloutTimeoutDelta -= Time.deltaTime;

        }

        if (_verticalVelocity < terminalVelocity)
            _verticalVelocity += gravity * Time.deltaTime;
    }

    private void PlayerMovement()
    {
        //Get Input and smothing value
        Vector2 playerInputMovement = _inputMap.GetPlayerMovementWalk();
        _animationTransisionBlend = Vector2.SmoothDamp(_animationTransisionBlend, playerInputMovement, ref _animationVelocity, animationSmoothTime);

        //Get speed, Sprint or walking
        float targetSpeed = _inputMap.GetPlayerSprintTrigger() ? playerSpeedSprint : playerSpeedWalk;
        isRunning = targetSpeed == playerSpeedSprint ? true : false;

        if (_inputMap.GetPlayerMovementWalk() == Vector2.zero)
        {
            targetSpeed = 0.0f;
            isMoving = false;
        }

        float currentHorizontalspeed = new Vector3(controller.velocity.x, 0.0f, controller.velocity.z).magnitude;
        float speedOffset = 0.1f;

        if (currentHorizontalspeed < targetSpeed - speedOffset || currentHorizontalspeed > targetSpeed + speedOffset)
        {
            _speed = Mathf.Lerp(currentHorizontalspeed, targetSpeed, Time.deltaTime * speedChangeRate);
            _speed = Mathf.Round(_speed * 1000f) / 1000f;
            isMoving = true;
        }
        else
            _speed = targetSpeed;

        Vector3 playerMove = new Vector3(_animationTransisionBlend.x, 0f, _animationTransisionBlend.y);
        if (_inputMap.GetPlayerMovementWalk() != Vector2.zero)
        {
            playerMove = transform.right * playerMove.x + transform.forward * playerMove.z;
            isMoving = true;
        }
        controller.Move(playerMove * (_speed * Time.deltaTime) + new Vector3(0f, _verticalVelocity, 0f) * Time.deltaTime);


        //SetAnimation
        PlayAnimation();

        //SetAudio
        ProgressCycle(targetSpeed);

    }

    #endregion

    #region Camera Movement

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }

    private void CameraRotation()
    {
        // if there is an input
        if (_inputMap.GetPlayerLookDelta().sqrMagnitude >= _threshold)
        {
            _cinemachineTargetPitch += _inputMap.GetPlayerLookDelta().y * rotationSpeed * Time.deltaTime;
            _rotationVelocity = _inputMap.GetPlayerLookDelta().x * rotationSpeed * Time.deltaTime;

            // clamp our pitch rotation
            _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, bottomClamp, topClamp);

            // Update Cinemachine camera target pitch
            cameraTarget.transform.localRotation = Quaternion.Euler(-_cinemachineTargetPitch, 0.0f, 0.0f);
            //kepala.transform.localRotation = Quaternion.Euler(-_cinemachineTargetPitch, 0.0f, 0.0f);

            // rotate the player left and right
            transform.Rotate(Vector3.up * _rotationVelocity);

        }
    }

    private void HeadBobHandler()
    {
        if (useHeadBob)
        {
            if (isMoving)
            {
                _timerHeadbob = Time.deltaTime * (isRunning ? runningHeadBobSpeed : walkingHeadBobSpeed);
                float newCameraPos = _startCameraPos + Mathf.Sin(_timerHeadbob) * (isRunning ? runningHeadBobAmmount : walkingHeadBobAmmount);
                cameraTarget.transform.localPosition = new Vector3(cameraTarget.transform.localPosition.x, newCameraPos, cameraTarget.transform.localPosition.z);
                Debug.Log("posCam = " + cameraTarget.transform.localPosition.y);
            }
        }
    }

    #endregion

    #region Animation + Sound

    private void PlayAnimation()
    {
        switch (_inputMap.GetPlayerSprintTrigger())
        {
            case false:
                anim.SetBool(runAnimatorID, false);
                anim.SetFloat(moveXParameterAnimationID, _animationTransisionBlend.x);
                anim.SetFloat(moveZParameterAnimationID, _animationTransisionBlend.y);
                break;

            case true:
                anim.SetBool(runAnimatorID, true);
                anim.SetFloat(moveXParameterAnimationID, _animationTransisionBlend.x);
                anim.SetFloat(moveZParameterAnimationID, _animationTransisionBlend.y);
                break;
        }
    }

    private void ProgressCycle(float speed)
    {
        if (controller.velocity.sqrMagnitude > 0 && _inputMap.GetPlayerMovementWalk() != Vector2.zero)
            _stepCycle += (controller.velocity.magnitude + (speed * (runAnimatorID == 0 ? 1f : m_RunstepLenghten))) * Time.deltaTime;

        if (!(_stepCycle > _nextStep))
            return;

        _nextStep = _stepCycle + stepInterval;

        PlaySFX();
    }

    public void SwapAudioCollections(WalkingScrptibleObject audioClip)
    {
        footstepAudio.Clear();
        for (int i = 0; i < audioClip.stepingSFX.Count; i++)
            footstepAudio.Add(audioClip.stepingSFX[i]);

    }

    private void PlaySFX()
    {
        if (!controller.isGrounded)
            return;

        int n = Random.Range(1, footstepAudio.Count);
        audioSource.clip = footstepAudio[n];
        audioSource.PlayOneShot(audioSource.clip);

        footstepAudio[n] = footstepAudio[0];
        footstepAudio[0] = audioSource.clip;
    }


    #endregion

    #region Utilities + Player Feature

    private void FiturSenter()
    {
        bool isPressed = _inputMap.GetPlayerSenter();

        if(isPressed)
            e_playerSO.LightingEvent();

        Debug.Log("Key Senter = " + isPressed);
    }


    private void OnDrawGizmosSelected()
    {
        Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);
        Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);

        if (isGround) Gizmos.color = transparentGreen;
        else Gizmos.color = transparentRed;

        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - groundOffset, transform.position.z), groundRadius);

    }
    #endregion
}
