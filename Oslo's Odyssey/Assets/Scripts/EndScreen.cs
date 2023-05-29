using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public void Quit() // Public to allow Button to access the method
    {
        Application.Quit();
    }
}
