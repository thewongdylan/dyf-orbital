using UnityEngine;
using Unisave.Utils;

public static class PlayerToken
{
    private const string TokenKey = "auth.playerToken";

    public static bool HasEmail()
    {
        return PlayerPrefs.HasKey(TokenKey);
    }

    public static string Get()
    {
        if (!PlayerPrefs.HasKey(TokenKey))
        {
            Debug.Log("PlayerToken not set");
        }

        return PlayerPrefs.GetString(TokenKey);
    }

    public static void Set(string email)
    {
        if (!PlayerPrefs.HasKey(TokenKey))
        {
            PlayerPrefs.SetString(TokenKey, email);
            PlayerPrefs.Save();
            Debug.Log("Saved new email: " + email);
        }
        else
        {
            Debug.Log("PlayerToken email has already been set: " + PlayerPrefs.GetString(TokenKey));
            PlayerPrefs.SetString(TokenKey, email);
            PlayerPrefs.Save();
            Debug.Log("overwritten exisiting email");
        }
    }
}