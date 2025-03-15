using UnityEngine;

public class Rocket : MonoBehaviour {

    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

}
