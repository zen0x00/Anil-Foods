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

    private Tween idleTween;

    void Awake()
    {
        button = GetComponent<Button>();
        rect = GetComponent<RectTransform>();

        button.onClick.AddListener(OnClickEffect);
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
    }
}
