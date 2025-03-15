using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float movementSpeed = 10f;
    
    private void FixedUpdate() {
        Movement();
    }

    private void Movement() {
        Vector3 direction = new Vector3(PlayerInputHandler.Instance.Movement.x, 0, PlayerInputHandler.Instance.Movement.y);

        transform.parent.position += direction * movementSpeed * Time.fixedDeltaTime;
    }
}
