using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class TapToStartUI : MonoBehaviour
{
    public TMP_Text tapText;
    public Button startBtn;

    void Start()
    {
        startBtn.onClick.AddListener(OnStartButtonClicked);

        // Blink animation using DOTween (fade in/out forever)
        tapText.DOFade(0.2f, 0.8f)
               .SetLoops(-1, LoopType.Yoyo)
               .SetEase(Ease.InOutSine);
    }

    void OnStartButtonClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Sandbox");
    }
}
