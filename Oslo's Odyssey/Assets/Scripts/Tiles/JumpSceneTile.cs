using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpSceneTile : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            JumpToScene();
        }
    }

    private void JumpToScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
