using UnityEngine;

public class Destructable : MonoBehaviour {

    [SerializeField] private GameObject destroyedGameObject;
    
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Rocket")) {
            DestructionHandler.Instance.ObjectDestroyed(this);
            DestructionHandler.Instance.SpawnExplosion(other.ClosestPoint(transform.position), transform.rotation, 20f);
            Instantiate(destroyedGameObject, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(other.transform.parent.gameObject);
        }
    }
        
}
