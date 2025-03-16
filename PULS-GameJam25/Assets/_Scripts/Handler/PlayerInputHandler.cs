using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour {

    public static PlayerInputHandler Instance;

    private InputActionAsset inputActionAsset;
    private InputActionMap playerActions;

    private InputAction movementInput;
    private InputAction lookInput;
    private InputAction shootInput;

    public Vector2 Movement;
    public Vector2 Look;

    private PlayerShoot playerShoot;

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        playerShoot = transform.parent.GetComponentInChildren<PlayerShoot>();

        inputActionAsset = GetComponent<PlayerInput>().actions;
        playerActions = inputActionAsset.FindActionMap("Player");
        Movement = Vector2.zero;
        Look = Vector2.zero;
    }

    private void Update() {
        Movement = movementInput.ReadValue<Vector2>();
        Look = lookInput.ReadValue<Vector2>();
    }

    private void OnEnable() {
        movementInput = playerActions.FindAction("Move");
        lookInput = playerActions.FindAction("Look");
        shootInput = playerActions.FindAction("Shoot");

        shootInput.performed += ShootPerformed;
        playerActions.Enable();
    }

    private void OnDisable() {
        shootInput.performed -= ShootPerformed;
        playerActions.Disable();
    }

    private void ShootPerformed(InputAction.CallbackContext context) {
        playerShoot.Shoot();
    }

}
