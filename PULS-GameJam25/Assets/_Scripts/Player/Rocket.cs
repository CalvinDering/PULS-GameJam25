using UnityEngine;

public class Rocket : MonoBehaviour {

    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        if(rb.velocity.sqrMagnitude > 0.01f) {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }

}
