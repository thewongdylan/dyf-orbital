using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTile : MonoBehaviour
{
    public static bool inWater = false;
    [SerializeField] private float drag = 6f;
    private float originalDrag;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("OsloHead"))
        {
            originalDrag = collision.gameObject.GetComponentInParent<Rigidbody2D>().drag;
            Debug.Log("water drag enabled");
            collision.gameObject.GetComponentInParent<Rigidbody2D>().drag = drag;
            inWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("OsloHead"))
        {
            Debug.Log("water drag disabled");
            collision.gameObject.GetComponentInParent<Rigidbody2D>().drag = originalDrag;
            inWater = false;
        }
    }
}
