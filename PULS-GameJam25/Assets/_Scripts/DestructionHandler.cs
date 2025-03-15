using UnityEngine;

public class DestructionHandler : MonoBehaviour {

    public static DestructionHandler Instance;

    [SerializeField] private GameObject explosionPrefab;

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void SpawnExplosion(Vector3 position, Quaternion rotation, float particleDuration) {

        GameObject explosion = Instantiate(explosionPrefab, position, rotation);
        Destroy(explosion, particleDuration);
    }

}
