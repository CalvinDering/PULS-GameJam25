using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float horizontalrotationSpeed = 0.5f;
    [SerializeField] private float verticalRotationSpeed = 0.2f;

    [SerializeField] private float maxVerticalAngle = 75f;
    private float horizontalRotation = 0f;
    private float verticalRotation = 0f;

    private void FixedUpdate() {
        if(DestructionHandler.Instance.isPaused()) {
            return;
        }

        Movement();
        Look();
    }

    private void Movement() {
        Vector3 direction = new Vector3(PlayerInputHandler.Instance.Movement.x, 0, PlayerInputHandler.Instance.Movement.y);

        Vector3 forward = transform.parent.forward;
        Vector3 right = transform.parent.right;
        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * direction.z + right * direction.x).normalized;

        transform.parent.position += moveDirection * movementSpeed * Time.fixedDeltaTime;
    }

    private void Look() {

        horizontalRotation += PlayerInputHandler.Instance.Look.x * horizontalrotationSpeed;
        verticalRotation += -PlayerInputHandler.Instance.Look.y * verticalRotationSpeed;

        verticalRotation = Mathf.Clamp(verticalRotation, -maxVerticalAngle, maxVerticalAngle);

        transform.parent.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, 0);
    }
}
