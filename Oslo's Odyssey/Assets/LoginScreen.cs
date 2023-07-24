using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginScreen : MonoBehaviour
{
    [SerializeField] private TMP_InputField emailInput;
    private string playerEmail;
    [SerializeField] private OsloData osloData;
    [SerializeField] private int cutsceneIndex;
    void Start ()
    {
        emailInput.onEndEdit.AddListener(GetEmail);
    }

    public void GetEmail(string playerInput)
    {
        playerEmail = playerInput;
        if (PlayerToken.HasEmail())
        {
            LoadNextScene(); // Continue
        }
        else
        {
            // Cutscene
            PlayerToken.Set(playerEmail);
            Debug.Log("set email: " + playerEmail);
            LoadCutscene(cutsceneIndex);
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadCutscene(int cutsceneIndex)
    {
        SceneManager.LoadScene(cutsceneIndex);
    }    
}
