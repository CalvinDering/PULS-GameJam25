using UnityEngine;

public class RocketLauncher : MonoBehaviour {

    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform rocketSpawnpoint;

    [SerializeField] private float bulletSpeed = 10f;

    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            GameObject rocket = Instantiate(rocketPrefab, rocketSpawnpoint.position, rocketSpawnpoint.rotation, transform);
            Rigidbody rocketRigidbody = rocket.GetComponentInChildren<Rigidbody>();
            rocketRigidbody.AddForce(rocket.transform.forward * bulletSpeed);
        }
    }

}
