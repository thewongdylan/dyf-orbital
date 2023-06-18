using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeCamera : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            mainCamera.GetComponent<OsloCamera>().UpdateFollowOslo(false);
            Debug.Log("Freeze!");
        }
    }
}
