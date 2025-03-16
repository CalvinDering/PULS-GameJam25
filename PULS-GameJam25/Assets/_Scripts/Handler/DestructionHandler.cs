using System;
using UnityEngine;

public class DestructionHandler : MonoBehaviour {

    public static DestructionHandler Instance;

    [SerializeField] private GameObject explosionPrefab;

    private int score = 0;

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start() {
        score = 0;
    }

    public void ObjectDestroyed(Destructable destructable) {
        if(destructable is TargetDestructable target) {
            if(target.ShouldDestroyTarget()) {
                score++;
            } else {
                score--;
            }
        }
    }

    public void SpawnExplosion(Vector3 position, Quaternion rotation, float particleDuration) {

        GameObject explosion = Instantiate(explosionPrefab, position, rotation);
        Destroy(explosion, particleDuration);
    }

    public int GetScore() {
        return score;
    }

}
