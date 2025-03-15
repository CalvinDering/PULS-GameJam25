using UnityEngine;

public class Destructable : MonoBehaviour {

    [SerializeField] private float explosionForce = 500f;
    [SerializeField] private float explosionRadius = 5f;

    private Collider mainCollider;

    private void Awake() {
        mainCollider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision) {
        ContactPoint contact = collision.contacts[0];
        GameObject rocket = contact.otherCollider.gameObject;
        if(rocket.CompareTag("Rocket")) {
            Quaternion contactRotation = Quaternion.FromToRotation(Vector3.forward, contact.normal);
            DestructionHandler.Instance.SpawnExplosion(contact.point, contactRotation, 20f);
            Destroy(rocket.transform.parent.gameObject);

            HandleDestruction();
        }
    }

    private void HandleDestruction() {
        foreach(Transform child in transform.GetComponentsInChildren<Transform>()) {
            if(child == transform) {
                continue;
            }

            Rigidbody childRb = child.GetComponent<Rigidbody>();
            if(childRb == null) {
                continue;
            }

            childRb.isKinematic = false;
            childRb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }

        Collider[] collider = GetComponents<Collider>();
        foreach(Collider col in collider) {
            col.enabled = false;
        }
    }
        
}
