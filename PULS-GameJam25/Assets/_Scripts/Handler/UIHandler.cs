using System;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour {

    public static UIHandler Instance;

    [SerializeField] private TextMeshProUGUI scoreText, scoreShadowText;
    [SerializeField] private TextMeshProUGUI targetText, targetShadowText;
    [SerializeField] private TextMeshProUGUI timeLeftText, timeLeftShadowText;
    [SerializeField] private GameObject restartMenu;
    [SerializeField] private GameObject loreMenu;
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private GameObject creditsMenu;
    [SerializeField] private GameObject mainMenu;

    private int totalScore = 0;


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

    public void ShowRestartMenu(bool value = true) {
        restartMenu.SetActive(value);
    }

    public void InitScore(int totalScore) {
        this.totalScore = totalScore;
    }

    public void UpdateScore() {
        scoreText.text = $"Score: { DestructionHandler.Instance.GetScore() }";
        scoreShadowText.text = $"Score: { DestructionHandler.Instance.GetScore() }";
    }

    public void UpdateTimer(float timeLeft) {
        if(DestructionHandler.Instance.isPaused()) {
            timeLeftText.text = "Time left: 0.000";
            timeLeftShadowText.text = "Time left: 0.000";
        }
        if(timeLeft > 0) {
            timeLeftText.text = $"Time left: {timeLeft,6:0.000}";
            timeLeftShadowText.text = $"Time left: {timeLeft,6:0.000}";
        } else {
            timeLeftText.text = "Time left 0.000";
            timeLeftShadowText.text = "Time left 0.000";
        }
    }

    public void SetTarget(string target, string targetShadow) {
        targetText.text = $"{ target }";
        targetShadowText.text = $"{ targetShadow }";
    }

    public void ShowMainButtons() {
        loreMenu.SetActive(false);
        controlsMenu.SetActive(false);
        creditsMenu.SetActive(false);

        mainMenu.SetActive(true);
    }

    public void ShowCredits() {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void ShowControls() {
        mainMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void ShowLore() {
        mainMenu.SetActive(false);
        loreMenu.SetActive(true);
    }
}
