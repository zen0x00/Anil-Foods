using UnityEngine;
using DG.Tweening;

public class PanelFader : MonoBehaviour
{
    public static PanelFader Instance;
    public float fadeDuration = 0.5f;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void FadePanels(CanvasGroup from, CanvasGroup to)
    {
        if (from == null || to == null) return; // safety check

        // Stop any previous fades
        from.DOKill();
        to.DOKill();

        // Fade OUT old panel
        from.DOFade(0f, fadeDuration).OnComplete(() =>
        {
            if (from != null)
            {
                from.interactable = false;
                from.blocksRaycasts = false;
            }
        });

        // Prep new panel
        to.alpha = 0f;
        to.interactable = false;
        to.blocksRaycasts = false;

        // Fade IN new panel
        to.DOFade(1f, fadeDuration).OnComplete(() =>
        {
            if (to != null)
            {
                to.interactable = true;
                to.blocksRaycasts = true;
            }
        });
    }
}
