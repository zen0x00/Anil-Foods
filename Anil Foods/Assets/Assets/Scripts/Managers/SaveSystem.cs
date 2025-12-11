using UnityEngine;

public static class SaveSystem
{
    public static void SaveBestScore(string phoneNumber, int score)
    {
        string key = "BestScore_" + phoneNumber;

        int previousBest = PlayerPrefs.GetInt(key, 0);

        if (score > previousBest)
        {
            PlayerPrefs.SetInt(key, score);
            PlayerPrefs.Save();
        }
    }

    public static int LoadBestScore(string phoneNumber)
    {
        string key = "BestScore_" + phoneNumber;
        return PlayerPrefs.GetInt(key, 0);
    }

    public static void SavePhoneNumber(string phoneNumber)
    {
        PlayerPrefs.SetString("LastPhoneNumber", phoneNumber);
        PlayerPrefs.SetInt("PhoneRegistered", 1); // Mark registered
        PlayerPrefs.Save();
    }

    public static string LoadPhoneNumber()
    {
        return PlayerPrefs.GetString("LastPhoneNumber", "");
    }

    public static void MarkPhoneRegistered()
    {
        PlayerPrefs.SetInt("PhoneRegistered", 1);
        PlayerPrefs.Save();
    }

    public static bool IsPhoneRegistered()
    {
        return PlayerPrefs.GetInt("PhoneRegistered", 0) == 1;
    }
}
