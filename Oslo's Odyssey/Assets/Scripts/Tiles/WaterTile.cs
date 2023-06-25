using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTile : MonoBehaviour
{
    [SerializeField] private float drag = 10f;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("water drag enabled");
            collision.gameObject.GetComponent<Rigidbody2D>().drag = drag;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("water drag disabled");
            collision.gameObject.GetComponent<Rigidbody2D>().drag = drag;
        }
    }
}
