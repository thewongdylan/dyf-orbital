using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Orb"))
        {
            Destroy(collision.gameObject);
            transform.GetComponent<OsloOrbs>().SpawnNewOrb(collision.gameObject.name);
        }

        if (collision.gameObject.CompareTag("Heart"))
        {
            Destroy(collision.gameObject);
            transform.GetComponent<OsloLife>().AddHealth(4);
        }
    }


}
