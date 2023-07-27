using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    private static BackgroundMusicController instance;

    private void Awake()
    {
        // Check if an instance of the script already exists.
        // If it does, destroy this instance to ensure we have only one BackgroundMusicController.
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // If this is the first instance, assign it to the static variable.
        instance = this;

        // Make sure the GameObject is not destroyed when loading new scenes.
        DontDestroyOnLoad(gameObject);
    }
}
