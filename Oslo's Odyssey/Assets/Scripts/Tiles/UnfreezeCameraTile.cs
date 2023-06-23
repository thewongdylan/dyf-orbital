using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnfreezeCameraTile : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float unfreezeAfter = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.GetComponent<OsloCamera>().UpdateFollowOslo(false);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Unfreeze", unfreezeAfter);
        }
    }

    private void Unfreeze()
    {
        mainCamera.GetComponent<OsloCamera>().UpdateFollowOslo(true);
        Debug.Log("Unfreeze!");
    }
}
