using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Orb"))
        {
            Debug.Log("collided with: " + collision.gameObject.name);
            Destroy(collision.gameObject);
            transform.GetComponent<OsloOrbs>().Spawn(collision.gameObject.name);
        }
    }


}
