using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class TwoImageCutsceneController : MonoBehaviour
{
    public Sprite[] images; // Array to store the images you want to display in the cutscene
    public List<string> textToDisplay; // List to store the text to display in the cutscene
    public float imageDuration = 3f; // How long each image should be displayed

    public List<Text> textElements; // List to store references to the UI Text elements

    private Image imageDisplay;
    private int currentIndex = 0;
    private float timer = 0f;

    void Start()
    {
        imageDisplay = GetComponent<Image>();
        ShowImageAndText(currentIndex);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= imageDuration)
        {
            timer = 0f;
            NextImage();
        }
    }

    void NextImage()
    {
        currentIndex++;
        if (currentIndex >= images.Length)
        {
            // The cutscene is finished. Load the next scene.
            LoadNextScene();
            return;
        }

        ShowImageAndText(currentIndex);
    }

    void ShowImageAndText(int index)
    {
        if (index >= 0 && index < images.Length)
        {
            imageDisplay.sprite = images[index];

            if (index < textToDisplay.Count)
            {
                // Disable all text elements
                foreach (var textElement in textElements)
                {
                    textElement.gameObject.SetActive(false);
                }

                if (index < textElements.Count)
                {
                    // Enable the corresponding text element and set its text
                    textElements[index].text = textToDisplay[index];
                    textElements[index].gameObject.SetActive(true);
                }
            }
        }
    }

    void LoadNextScene()
    {
        // Load the next scene after the cutscene is finished
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // No more scenes in the build settings. You can add your custom logic here.
            Debug.Log("No more scenes to load!");
        }
    }
}
