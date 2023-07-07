using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpSceneTile : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    [SerializeField] private float loadDelay = 0f;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("JumpToScene", loadDelay);
        }
    }

    public void JumpToScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
