using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame() // Public to allow Button to access the method
    {
        SceneManager.LoadScene(1); // Hardcoded to buildIndex == 1 (Level 1)
    }
}
