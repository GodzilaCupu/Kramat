using UnityEngine;
using Cinemachine;


public class VirtualCameraExtension : CinemachineExtension
{
    [SerializeField] public float clampAngle { get; private set; }
    [SerializeField] public float _horizontalSpeed { get; private set; }
    [SerializeField] public float _verticalSpeed { get; private set; }

    private Vector3 startingRotation;
    [SerializeField] private CustomInputMap _inputMap;

    protected override void Awake()
    {
        if (startingRotation == null)
            startingRotation = transform.localRotation.eulerAngles;

        base.Awake();
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if(stage == CinemachineCore.Stage.Aim)
            {
                Vector2 deltaMouse = _inputMap.GetPlayerLookDelta();
                startingRotation.x += deltaMouse.x * _verticalSpeed * Time.deltaTime;
                startingRotation.y += deltaMouse.y * _horizontalSpeed * Time.deltaTime;
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
                state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);
            }
        }
    }
}
