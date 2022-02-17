using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private CustomInputManager inputManager;
    [SerializeField] private float gravityValue;
    [SerializeField] private float playerSpeedWalking;
    [SerializeField] private float playerSpeedSprint;
    [SerializeField] private Transform _cameraPos;


    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = CustomInputManager.Instance;
        _cameraPos = Camera.main.transform;
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        Vector2 playerInputMovement = inputManager.GetPlayerMovement();
        Vector3 playerMove = new Vector3(playerInputMovement.x, 0f, playerInputMovement.y);

        Vector3 move = playerMove.x * transform.right + playerMove.z * transform.forward;
        move = _cameraPos.forward * move.z + _cameraPos.right * move.x;

        // check Sprinting
        if (inputManager.GetPlayerSprint() == 1)
            PlayerMove(playerSpeedSprint, move);
        else
            PlayerMove(playerSpeedWalking, move);

    }

    void PlayerMove(float speed, Vector3 playerDirection)
    {
        //Check Ground
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
            playerVelocity.y = 0f;

        playerDirection.y += gravityValue * Time.deltaTime;
        controller.Move(playerDirection * speed * Time.deltaTime);
    }
}
