using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
// using UnityEngine.Networking; // Uncomment later for backend calls

public class SubmitPhone : MonoBehaviour
{
    public TMP_InputField phoneInput;

    public void OnNextClicked()
    {
        string phone = phoneInput.text.Trim();

        // --- SAVE LOCALLY FOR NOW ---
        SaveSystem.SavePhoneNumber(phone);
        // Continue to game
        SceneManager.LoadScene("Sandbox");
        /*
        // --- BACKEND CALL (COMMENTED UNTIL IMPLEMENTATION) ---
        StartCoroutine(SendPhoneToServer(phone));
        */
    }

    /*
    // ------------------------------------------------------------
    // BACKEND IMPLEMENTATION (DISABLED UNTIL API IS READY)
    // ------------------------------------------------------------
    IEnumerator SendPhoneToServer(string phone)
    {
        string json = "{\"phone\":\"" + phone + "\"}";

        UnityWebRequest req = new UnityWebRequest("https://yourbackend.com/api/saveNumber", "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);

        req.uploadHandler = new UploadHandlerRaw(bodyRaw);
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        yield return req.SendWebRequest();

        if (req.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Phone sent to server.");

            PlayerPrefs.SetString("PhoneNumber", phone);
            PlayerPrefs.Save();

            SceneManager.LoadScene("GameScene");
        }
        else
        {
            Debug.LogError("Backend error: " + req.error);
        }
    }
    */
}
