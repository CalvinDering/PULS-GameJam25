using System;
using UnityEngine;

public class DestructionHandler : MonoBehaviour {

    public static DestructionHandler Instance;

    [SerializeField] private GameObject explosionPrefab;

    private int score = 0;

    [SerializeField] private float roundTimer = 60f;
    private float timer = 0f;

    private bool paused = false;

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        Cursor.lockState = CursorLockMode.Locked;
        paused = false;
    }

    private void Start() {
        score = 0;
        UIHandler.Instance.UpdateScore();
        UIHandler.Instance.ShowRestartMenu(false);
    }

    private void Update() {
        timer += Time.deltaTime;

        if(timer >= roundTimer) {
            Cursor.lockState = CursorLockMode.None;
            paused = true;
            UIHandler.Instance.ShowRestartMenu();
        }

        UIHandler.Instance.UpdateTimer(roundTimer - timer);
    }

    public void ObjectDestroyed(Destructable destructable) {
        if(destructable is TargetDestructable target) {
            if(target.ShouldDestroyTarget()) {
                score++;
            } else {
                score--;
            }
        } else {
            score--;
        }

        UIHandler.Instance.UpdateScore();
    }

    public void SpawnExplosion(Vector3 position, Quaternion rotation, float particleDuration) {

        GameObject explosion = Instantiate(explosionPrefab, position, rotation);
        Destroy(explosion, particleDuration);
    }

    public int GetScore() {
        return score;
    }

    public bool isPaused() {
        return paused;
    }

}
