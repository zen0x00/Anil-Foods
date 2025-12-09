using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PhoneNumberUI : MonoBehaviour
{
    public TMP_InputField phoneInput;
    public Button nextButton;
    public TMP_Text errorText;

    void Start()
    {
        nextButton.interactable = false;
        errorText.text = "";
        phoneInput.onValueChanged.AddListener(ValidatePhone);
    }

    void ValidatePhone(string value)
    {
        // Remove spaces
        value = value.Trim();

        // Check numeric
        if (!long.TryParse(value, out _))
        {
            nextButton.interactable = false;
            errorText.text = "Please enter numbers only.";
            return;
        }

        // Check length: 10 digits
        if (value.Length != 10)
        {
            nextButton.interactable = false;
            errorText.text = "Enter a valid 10-digit number.";
            return;
        }

        // Valid
        errorText.text = "";
        nextButton.interactable = true;
    }
}
