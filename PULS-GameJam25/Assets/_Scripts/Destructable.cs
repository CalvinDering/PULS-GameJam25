using UnityEngine;

public class Destructable : MonoBehaviour {

    [SerializeField] private GameObject destroyedGameObject;
    
    private void OnCollisionEnter(Collision collision) {
        ContactPoint contact = collision.contacts[0];
        GameObject rocket = contact.otherCollider.gameObject;
        if(rocket.CompareTag("Rocket")) {
            Quaternion contactRotation = Quaternion.FromToRotation(Vector3.forward, contact.normal);
            DestructionHandler.Instance.SpawnExplosion(contact.point, contactRotation, 20f);
            Destroy(rocket.transform.parent.gameObject);

            if(destroyedGameObject != null) {
                DestructionHandler.Instance.ObjectDestroyed(this);
                Instantiate(destroyedGameObject, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
        
}
