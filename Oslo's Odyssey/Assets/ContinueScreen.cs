using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContinueScreen : MonoBehaviour
{   
    [SerializeField] private OsloData osloData;
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Continue()
    {
        // SceneManager.LoadScene(osloData.savedSceneIndex);
        
    }
}
