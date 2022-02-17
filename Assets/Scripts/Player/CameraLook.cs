using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private float xRotation;
    private CustomInputManager inputManager;
    
    [SerializeField] private Transform playerBody;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float clampLook;

    private void Start()
    {
        inputManager = GameObject.Find("GameManager").GetComponent<CustomInputManager>();
        inputManager = CustomInputManager.Instance;

    }

    void Update()
    {
        float mouseX = inputManager.GetMouseDelta().x * mouseSensitivity * Time.deltaTime;

        float mouseY = inputManager.GetMouseDelta().y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -clampLook, clampLook);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }


}
