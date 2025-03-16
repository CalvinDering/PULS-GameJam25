using UnityEngine;

public class SoundFXPlayer : MonoBehaviour {

    public static SoundFXPlayer Instance;

    [SerializeField] private AudioClip[] audioClips;

    [SerializeField] private float minPitch = 0.85f;
    [SerializeField] private float maxPitch = 1.15f;

    private AudioSource audioSource;

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public AudioClip GetRandomSound(bool randomPitch = true, bool stereoPan = true) {
        AudioClip clip = audioClips[Random.Range(0, audioClips.Length)];
        if(randomPitch) {
            audioSource.pitch = Random.Range(minPitch, maxPitch);
        }

        if(stereoPan) {
            Vector3 viewPortPosition = Camera.main.ViewportToWorldPoint(transform.position);
            audioSource.panStereo = viewPortPosition.x;
        }

        return clip;
    }

    public float PlayRandomSound(bool randomPitch = true, bool stereoPan = true) {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        if(randomPitch) {
            audioSource.pitch = Random.Range(minPitch, maxPitch);
        }

        if(stereoPan) {
            Vector3 viewPortPosition = Camera.main.ViewportToWorldPoint(transform.position);
            audioSource.panStereo = viewPortPosition.x;
        }

        audioSource.Play();

        return audioSource.clip.length;
    }

    public void StopAudio() {
        audioSource.Stop();
    }

}
