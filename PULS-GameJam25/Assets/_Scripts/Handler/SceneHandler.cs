using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {

    public static SceneHandler Instance;

    [SerializeField] private int mainMenuSceneIndex = 0;
    [SerializeField] private int gameSceneIndex = 1;

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadMainMenuScene() {
        StartCoroutine(LoadScene(mainMenuSceneIndex));
    }

    public void LoadGameScene() {
        StartCoroutine(LoadScene(gameSceneIndex));
    }

    private IEnumerator LoadScene(int index) {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);
        while(!asyncLoad.isDone) {
            yield return null;
        }

        if(index == mainMenuSceneIndex) {
            AudioHandler.Instance.PlayMainMenuMusic();
        } else if(index == gameSceneIndex) {
            AudioHandler.Instance.PlayGameMusic();
        }
    }

}
