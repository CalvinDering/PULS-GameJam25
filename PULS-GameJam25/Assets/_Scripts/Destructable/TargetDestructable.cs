using UnityEngine;

public class TargetDestructable : Destructable {

    private bool shouldDestroy;

    [SerializeField] private Transform spawnPoint;

    public void Setup(GameObject target, bool shouldDestroy) {
        if(shouldDestroy) {
            Instantiate(target, spawnPoint.position, spawnPoint.rotation, spawnPoint);
        }
        this.shouldDestroy = shouldDestroy;
    }

    public bool ShouldDestroyTarget() {
        return shouldDestroy;
    }
        
}
