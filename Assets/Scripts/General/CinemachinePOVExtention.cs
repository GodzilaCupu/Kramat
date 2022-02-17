using UnityEngine;
using Cinemachine;

public class CinemachinePOVExtention : CinemachineExtension
{
    [SerializeField] private float clampAngle = 80f;
    [SerializeField] private float horizontalSpeed = 10f;
    [SerializeField] private float verticalSpeed = 10f;

    private CustomInputManager inputManager;
    private Vector3 startingRotation;

    protected override void Awake()
    {
        inputManager = CustomInputManager.Instance;
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
                Vector2 deltaMouse = inputManager.GetMouseDelta();
                startingRotation.x += deltaMouse.x * verticalSpeed * Time.deltaTime;
                startingRotation.y += deltaMouse.y * horizontalSpeed* Time.deltaTime;
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
                state.RawOrientation = Quaternion.Euler(-startingRotation.y,startingRotation.x,0f);
            }
        }
    }
}
  