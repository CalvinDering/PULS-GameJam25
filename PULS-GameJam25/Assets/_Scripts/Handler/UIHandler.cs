using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour {

    public static UIHandler Instance;

    [SerializeField] private TextMeshProUGUI scoreText, scoreShadowText;
    [SerializeField] private TextMeshProUGUI targetText, targetShadowText;

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

    public void ShowScore(bool shouldShow = true) {
        scoreText.text = $"Score: { DestructionHandler.Instance.GetScore() }";
        scoreShadowText.text = $"Score: { DestructionHandler.Instance.GetScore() }";
        scoreText.enabled = shouldShow;
        scoreShadowText.enabled = shouldShow;
    }

    public void SetTarget(string target, string targetShadow) {
        targetText.text = $"{ target }";
        targetShadowText.text = $"{ targetShadow }";
    }
}
