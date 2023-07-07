using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTile : MonoBehaviour
{
    // private bool levelCompleted = false;
    [SerializeField] private float loadDelay = 0f;


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) //&& levelCompleted == false)
        {
            // levelCompleted = true; // Needed when playing sound effects for level complete etc
            Invoke("LoadNextScene", loadDelay);
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
