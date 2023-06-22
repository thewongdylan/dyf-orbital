using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTile : MonoBehaviour
{
    // private bool levelCompleted = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) //&& levelCompleted == false)
        {
            // levelCompleted = true; // Needed when playing sound effects for level complete etc
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
