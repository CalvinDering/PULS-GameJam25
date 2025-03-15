using UnityEngine;

public class PlayerShoot : MonoBehaviour {


    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform rocketSpawnpoint;

    [SerializeField] private float bulletSpeed = 10f;

    public void Shoot() {
        GameObject rocket = Instantiate(rocketPrefab, rocketSpawnpoint.position, rocketSpawnpoint.rotation, DestructionHandler.Instance.transform);
        Rigidbody rocketRigidbody = rocket.GetComponentInChildren<Rigidbody>();
        rocketRigidbody.AddForce(rocket.transform.forward * bulletSpeed, ForceMode.Impulse);
    }
}
