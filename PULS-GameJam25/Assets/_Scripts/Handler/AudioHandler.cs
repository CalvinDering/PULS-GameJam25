using UnityEngine;

public class AudioHandler : MonoBehaviour {

    public static AudioHandler Instance;

    [SerializeField] private AudioSource mainMenuMusic;
    [SerializeField] private AudioSource gameMusic;

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        PlayMainMenuMusic();
    }

    public void PlayMainMenuMusic() {
        gameMusic.Stop();

        mainMenuMusic.Play();
    }

    public void PlayGameMusic() {
        gameMusic.Play();
        mainMenuMusic.Stop();
    }
}
