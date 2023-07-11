using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] private GameObject pauseUI;
    private Canvas pauseCanvas;

    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas = GetComponent<Canvas>();
        pauseCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!isPaused)
            {
                Pause();
            }
            else 
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseCanvas.enabled = true;
        isPaused = true;
        Debug.Log("Game paused");
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseCanvas.enabled = false;
        isPaused = false;
        Debug.Log("Game resumed");
    }

    public void Quit()
    {
        isPaused = false;
        Application.Quit();
        Debug.Log("Game quit");
    }
}
