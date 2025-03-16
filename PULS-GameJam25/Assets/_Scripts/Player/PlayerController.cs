using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float horizontalrotationSpeed = 0.5f;
    [SerializeField] private float verticalRotationSpeed = 0.2f;

    [SerializeField] private float maxVerticalAngle = 75f;
    private float horizontalRotation = 0f;
    private float verticalRotation = 0f;

    private float minXBound = 0f;
    private float maxXBound;
    private float minZBound = 0f;
    private float maxZBound;

    private void Start() {
        maxXBound = HouseSpawner.Instance.GetWidth();
        maxZBound = HouseSpawner.Instance.GetHeight();
    }

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

        float clampedX = Mathf.Clamp(transform.parent.position.x, minXBound, maxXBound);
        float clampedZ = Mathf.Clamp(transform.parent.position.z, minZBound, maxZBound);

        transform.parent.position = new Vector3(clampedX, transform.parent.position.y, clampedZ);

    }

    private void Look() {

        horizontalRotation += PlayerInputHandler.Instance.Look.x * horizontalrotationSpeed;
        verticalRotation += -PlayerInputHandler.Instance.Look.y * verticalRotationSpeed;

        verticalRotation = Mathf.Clamp(verticalRotation, -maxVerticalAngle, maxVerticalAngle);

        transform.parent.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, 0);
    }
}
