using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [Header("Panels")]
    public CanvasGroup panelBestScore;
    public CanvasGroup panelRestart;

    [Header("UI Elements")]
    public TMP_Text currentScoreText;
    public TMP_Text bestScoreText;

    [Header("Buttons")]
    public Button buttonNext;
    public Button buttonRestart;

    void Start()
    {
        // Load phone number
        string phone = SaveSystem.LoadPhoneNumber();

        // Load current & best score
        int currentScore = PlayerPrefs.GetInt("LastScore", 0);
        int bestScore = SaveSystem.LoadBestScore(phone);

        currentScoreText.text = "Your Score: " + currentScore;
        bestScoreText.text = "Best Score: " + bestScore;

        // Initial states
        panelBestScore.alpha = 1f;
        panelBestScore.interactable = true;
        panelBestScore.blocksRaycasts = true;

        panelRestart.alpha = 0f;
        panelRestart.interactable = false;
        panelRestart.blocksRaycasts = false;

        // Button listeners
        buttonNext.onClick.AddListener(OnNextClicked);
        buttonRestart.onClick.AddListener(OnRestartClicked);
    }

    public void OnNextClicked()
    {
        // Use the singleton
        PanelFader.Instance.FadePanels(panelBestScore, panelRestart);
    }

    public void OnRestartClicked()
    {
        // Reload the main game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Sandbox");
    }
}
