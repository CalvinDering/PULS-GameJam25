using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour {

    public static UIHandler Instance;

    [SerializeField] private TextMeshProUGUI scoreText, scoreShadowText;
    [SerializeField] private TextMeshProUGUI targetText, targetShadowText;

    private int totalScore = 0;

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start() {

        UpdateScore();
    }

    public void StartGame() {
        SceneHandler.Instance.LoadGameScene();
    }

    public void LoadMainMenu() {
        SceneHandler.Instance.LoadMainMenuScene();
    }

    public void InitScore(int totalScore) {
        this.totalScore = totalScore;
    }

    public void UpdateScore() {
        scoreText.text = $"Score: { DestructionHandler.Instance.GetScore() }";
        scoreShadowText.text = $"Score: { DestructionHandler.Instance.GetScore() }";
    }

    public void SetTarget(string target, string targetShadow) {
        targetText.text = $"{ target }";
        targetShadowText.text = $"{ targetShadow }";
    }
}
