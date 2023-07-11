using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private OsloData osloData;
    public void Quit() // Public to allow Button to access the method
    {
        Application.Quit();
    }

    public void Continue()
    {
        SceneManager.LoadScene(osloData.lastSceneIndex);
        osloData.currentHealth = osloData.startingHealth;
    }

    public void MainMenu()
    {
        Debug.Log("nothing should happen, menu not implemented yet");
    }
}
