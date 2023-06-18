using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerTile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) //&& levelCompleted == false)
        {
            Invoke("CompleteLevel", 1f);
        }
    }

    public void LoadTutorial() // Public to allow Button to access the method
    {
        SceneManager.LoadScene("Tutorial"); 
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit() // Public to allow Button to access the method
    {
        Application.Quit();
    }
}
