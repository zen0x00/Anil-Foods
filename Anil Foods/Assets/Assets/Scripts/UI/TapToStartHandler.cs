using UnityEngine;

public class TapToStartHandler : MonoBehaviour
{
    public CanvasGroup tapPanel;
    public CanvasGroup phonePanel;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PanelFader.Instance.FadePanels(tapPanel, phonePanel);
            enabled = false;
        }
    }
}
