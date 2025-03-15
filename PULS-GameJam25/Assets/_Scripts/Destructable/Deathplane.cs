using UnityEngine;

public class Deathplane : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Rocket")) {
            GameObject rocket = other.transform.parent.gameObject;
            ParticleSystem[] ps = rocket.GetComponentsInChildren<ParticleSystem>();

            if(ps.Length > 0) {
                rocket.GetComponentInChildren<Collider>().enabled = false;
                rocket.GetComponentInChildren<MeshRenderer>().enabled = false;

                float maxLifeTime = 0f;

                foreach(ParticleSystem particleSystem in ps) {
                    particleSystem.Stop();
                    float lifeTime = particleSystem.main.duration + particleSystem.main.startLifetime.constantMax;
                    if(lifeTime > maxLifeTime) {
                        maxLifeTime = lifeTime;
                    }
                }

                Destroy(rocket, maxLifeTime);
            }
        }
    }
}
