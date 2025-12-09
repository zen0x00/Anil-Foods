using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score;
    public float timer;   // Countdown from 60 seconds

    [Header("UI References")]
    public TMP_Text scoreText;
    public TMP_Text timerText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("LastScore", 0);  // Hard reset
        PlayerPrefs.Save();
        scoreText.text = "Score: 0";
        timerText.text = "Time: 60";
    }

    void Update()
    {
        // Countdown timer
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 0;

            // Load phone number
            string phone = SaveSystem.LoadPhoneNumber();

            // 1. Save best score (per phone)
            SaveSystem.SaveBestScore(phone, score);

            // 2. Save current run score
            PlayerPrefs.SetInt("LastScore", score);
            PlayerPrefs.Save();

            // 3. Load GameOver
            SceneManager.LoadScene("GameOver");
        }


        timerText.text = "Time: " + timer.ToString("F1");
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }
}
