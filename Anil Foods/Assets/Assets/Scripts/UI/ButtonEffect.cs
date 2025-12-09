using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonEffect : MonoBehaviour
{
    private Button button;
    private RectTransform rect;

    [Header("Click Animation")]
    public float punchScale = 0.2f;
    public float punchDuration = 0.25f;

    [Header("Idle Breathing Animation")]
    public float idleScaleAmount = 0.05f;
    public float idleDuration = 1.2f;

    private Tween idleTween;

    void Awake()
    {
        button = GetComponent<Button>();
        rect = GetComponent<RectTransform>();

        button.onClick.AddListener(OnClickEffect);
    }

    void Start()
    {
        PlayIdleBreathing();
    }

    void PlayIdleBreathing()
    {
        // Idle breathing loop
        idleTween = rect.DOScale(1f + idleScaleAmount, idleDuration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }

    void OnClickEffect()
    {
        // Stop idle animation when clicked
        idleTween.Kill();

        // Reset scale before punch
        rect.localScale = Vector3.one;

        // Play punch animation
        rect.DOPunchScale(
            Vector3.one * punchScale,
            punchDuration,
            10,
            1
        ).SetEase(Ease.OutCubic);

        // Restart breathing after click animation ends
        Invoke(nameof(PlayIdleBreathing), punchDuration);

        // Load game after punch finishes
        Invoke(nameof(ReloadScene), punchDuration);
    }

    void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Sandbox");
    }
}
