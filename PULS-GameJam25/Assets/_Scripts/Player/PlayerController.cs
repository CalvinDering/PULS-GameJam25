using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float horizontalrotationSpeed = 0.5f;
    [SerializeField] private float verticalRotationSpeed = 0.2f;

    [SerializeField] private float maxVerticalAngle = 75f;
    private float horizontalRotation = 0f;
    private float verticalRotation = 0f;

    private void Start() {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate() {
        Movement();
        Look();
    }

    private void Movement() {
        Vector3 direction = new Vector3(PlayerInputHandler.Instance.Movement.x, 0, PlayerInputHandler.Instance.Movement.y);
        Vector3 moveDirection = transform.parent.TransformDirection(direction);
        moveDirection.y = 0;

        transform.parent.position += moveDirection * movementSpeed * Time.fixedDeltaTime;
    }

    private void Look() {

        horizontalRotation += PlayerInputHandler.Instance.Look.x * horizontalrotationSpeed;
        verticalRotation += -PlayerInputHandler.Instance.Look.y * verticalRotationSpeed;

        verticalRotation = Mathf.Clamp(verticalRotation, -maxVerticalAngle, maxVerticalAngle);

        transform.parent.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, 0);
    }
}
