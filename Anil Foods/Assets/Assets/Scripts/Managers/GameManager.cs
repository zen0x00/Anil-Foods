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
        timer = 60f;
        scoreText.text = "Score: 0";
        timerText.text = "Time: 60";
    }

    void Update()
    {
        // Countdown timer
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = 0;
            timerText.text = "Time: 0";

            // Load GameOver scene
            SceneManager.LoadScene("GameOver");
            return;
        }

        timerText.text = "Time: " + timer.ToString("F1");
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }
}
