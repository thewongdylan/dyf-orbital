using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    [SerializeField] private TextMeshProUGUI cherriesCounter;
    [SerializeField] private Orb orb;

    [SerializeField] private PlayerLife playerLife;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject); // we know it's a Cherry since we have checked the tag of the gameObject
            cherries++;
            cherriesCounter.text = "Cherries: " + cherries;
        }

        // if (collision.gameObject.CompareTag("Heart"))
        // {
        //     Destroy(collision.gameObject);
        //     playerLife.GainHealth();
        // }

        if (collision.gameObject.CompareTag("Orb"))
        {
            Destroy(collision.gameObject);
            orb.Spawn();
        }
    }
}
