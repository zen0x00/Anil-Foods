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

    [Header("Popup")]
    public PhonePopupController phonePopup;

    void Start()
    {
        string phone = SaveSystem.LoadPhoneNumber();

        int currentScore = PlayerPrefs.GetInt("LastScore", 0);
        int bestScore = SaveSystem.LoadBestScore(phone);

        currentScoreText.text = "Your Score: " + currentScore;
        bestScoreText.text = "Best Score: " + bestScore;

        panelBestScore.alpha = 1f;
        panelBestScore.interactable = true;
        panelBestScore.blocksRaycasts = true;

        panelRestart.alpha = 0f;
        panelRestart.interactable = false;
        panelRestart.blocksRaycasts = false;

        buttonNext.onClick.AddListener(OnNextClicked);
        buttonRestart.onClick.AddListener(OnRestartClicked);
    }

    public void OnNextClicked()
    {
        // If phone already entered → skip popup
        if (SaveSystem.IsPhoneRegistered())
        {
            PanelFader.Instance.FadePanels(panelBestScore, panelRestart);
            return;
        }

        // Show popup and wait for close/submit
        phonePopup.OnComplete = () =>
        {
            PanelFader.Instance.FadePanels(panelBestScore, panelRestart);
        };

        phonePopup.Show();
    }

    public void OnRestartClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Sandbox");
    }
}
