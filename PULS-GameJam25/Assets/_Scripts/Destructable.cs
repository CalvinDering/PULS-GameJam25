using UnityEngine;

public class Destructable : MonoBehaviour {

    [SerializeField] private GameObject destroyedGameObject;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Rocket")) {
            Instantiate(destroyedGameObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
        
}
