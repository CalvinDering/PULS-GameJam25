using UnityEngine;

public class TargetDestructable : Destructable {

    [SerializeField] private bool shouldDestroy = true;

    public bool ShouldDestroyTarget() {
        return shouldDestroy;
    }
        
}
