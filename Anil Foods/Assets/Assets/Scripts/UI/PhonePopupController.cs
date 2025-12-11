using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class PhonePopupController : MonoBehaviour
{
    public CanvasGroup popupGroup;
    public RectTransform popupWindow;

    public TMP_InputField phoneInput;
    public TMP_Text errorText;
    public Button buttonContinue;
    public Button buttonClose;

    public System.Action OnComplete; // callback to GameOver

    [Header("Animation")]
    public float fadeDuration = 0.35f;
    public float scalePop = 1.1f;
    public float scaleDuration = 0.25f;

    void Start()
    {
        popupGroup.alpha = 0;
        popupGroup.interactable = false;
        popupGroup.blocksRaycasts = false;

        errorText.text = "";
        buttonContinue.interactable = false;

        phoneInput.onValueChanged.AddListener(ValidatePhone);
        buttonContinue.onClick.AddListener(SubmitNumber);
        buttonClose.onClick.AddListener(CloseWithoutSaving);
    }

    public void Show()
    {
        popupGroup.gameObject.SetActive(true);

        popupGroup.DOFade(1, fadeDuration)
                  .OnComplete(() =>
                  {
                      popupGroup.interactable = true;
                      popupGroup.blocksRaycasts = true;
                  });

        popupWindow.localScale = Vector3.zero;
        popupWindow.DOScale(scalePop, scaleDuration).SetEase(Ease.OutBack);
        popupWindow.DOScale(1f, 0.2f).SetDelay(scaleDuration);
    }

    void ValidatePhone(string value)
    {
        value = value.Trim();

        if (!long.TryParse(value, out _))
        {
            errorText.text = "Only numbers allowed";
            buttonContinue.interactable = false;
            return;
        }

        if (value.Length != 10)
        {
            errorText.text = "Enter 10-digit number";
            buttonContinue.interactable = false;
            return;
        }

        errorText.text = "";
        buttonContinue.interactable = true;
    }

    void SubmitNumber()
    {
        string number = phoneInput.text.Trim();

        SaveSystem.SavePhoneNumber(number); // saves + marks registered

        Hide();


        OnComplete?.Invoke(); // notify GameOver to proceed
    }

    void CloseWithoutSaving()
    {
        Hide();
        OnComplete?.Invoke();
    }

    void Hide()
    {
        popupGroup.interactable = false;
        popupGroup.blocksRaycasts = false;

        popupGroup.DOFade(0, fadeDuration)
                  .OnComplete(() =>
                  {
                      popupGroup.gameObject.SetActive(false);
                  });
    }
}
