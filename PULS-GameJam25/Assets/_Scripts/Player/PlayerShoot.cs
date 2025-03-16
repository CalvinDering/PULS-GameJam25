using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    private AudioSource weaponSound;

    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform rocketSpawnpoint;

    [SerializeField] private float bulletSpeed = 10f;

    private void Awake() {
        weaponSound = GetComponent<AudioSource>();
    }

    public void Shoot() {
        if(DestructionHandler.Instance.isPaused()) {
            return;
        }

        GameObject rocket = Instantiate(rocketPrefab, rocketSpawnpoint.position, rocketSpawnpoint.rotation, DestructionHandler.Instance.transform);
        Rigidbody rocketRigidbody = rocket.GetComponentInChildren<Rigidbody>();
        rocketRigidbody.AddForce(rocket.transform.forward * bulletSpeed, ForceMode.Impulse);

        weaponSound.Play();
    }
}
