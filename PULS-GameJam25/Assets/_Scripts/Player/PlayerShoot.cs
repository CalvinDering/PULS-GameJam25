using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    private AudioSource weaponSound;

    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform rocketSpawnpoint;

    [SerializeField] private float bulletSpeed = 10f;

    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private int linePoints = 175;
    [SerializeField] private float timeIntervalInPoints = 0.01f;

    private void Awake() {
        weaponSound = GetComponent<AudioSource>();
        if(lineRenderer != null) {
            lineRenderer.enabled = true;
        }
    }

    private void Update() {
        if(lineRenderer == null) {
            return;
        }

        DrawTrajectory();
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

    private void DrawTrajectory() {
        Vector3 origion = rocketSpawnpoint.position;
        Vector3 startVelocity = bulletSpeed * rocketSpawnpoint.forward;
        lineRenderer.positionCount = linePoints;
        float time = 0;
        for(int i = 0; i < linePoints; i++) {
            float x = (startVelocity.x * time) + (Physics.gravity.x / 2 * time * time);
            float y = (startVelocity.y * time) + (Physics.gravity.y / 2 * time * time);
            float z = (startVelocity.z * time) + (Physics.gravity.z / 2 * time * time);
            Vector3 point = new Vector3(x, y, z);
            lineRenderer.SetPosition(i, origion + point);
            time += timeIntervalInPoints;
        }
    

    }
}
