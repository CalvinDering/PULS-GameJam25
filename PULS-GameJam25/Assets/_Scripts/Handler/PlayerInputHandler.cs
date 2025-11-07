using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour {

    public static PlayerInputHandler Instance;

    private InputActionAsset inputActionAsset;
    private InputActionMap playerActions;

    private InputAction movementInput;
    private InputAction lookInput;
    private InputAction shootInput;
    private InputAction pauseInput;

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
        pauseInput = playerActions.FindAction("Interact");

        shootInput.performed += ShootPerformed;
        pauseInput.performed += PausePerformed;
        playerActions.Enable();
    }

    private void OnDisable() {
        shootInput.performed -= ShootPerformed;
        pauseInput.performed -= PausePerformed;
        playerActions.Disable();
    }

    private void ShootPerformed(InputAction.CallbackContext context) {
        playerShoot.Shoot();
    }

    private void PausePerformed(InputAction.CallbackContext context) {
        ParticleSystem[] particleSystems = FindObjectsOfType<ParticleSystem>();
        foreach(ParticleSystem particle in particleSystems) {
            if(particle.isPlaying) {
                particle.Pause();
            }
            
        }
        Destructable[] destructables = FindObjectsOfType<Destructable>();
        foreach(Destructable destructable in destructables) {
            destructable.Pause();
        }

        Rocket[] rockets = FindObjectsOfType<Rocket>();
        foreach(Rocket rocket in rockets) {
            rocket.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

}
