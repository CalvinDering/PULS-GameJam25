using UnityEngine;

public class Deathplane : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Rocket")) {
            Destroy(other.transform.parent.gameObject);
        }
    }
}
