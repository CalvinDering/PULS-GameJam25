using UnityEngine;

public class UIHandler : MonoBehaviour {

    public static UIHandler Instance;

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void StartGame() {
        SceneHandler.Instance.LoadGameScene();
    }

    public void LoadMainMenu() {
        SceneHandler.Instance.LoadMainMenuScene();
    }
}
