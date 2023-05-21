using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    // Trigger used to differentiate between the 2 BoxColliders on the MovingPlatform
    // Trigger BoxCollider for top (jumpableGround), non-trigger BoxCollider for bottom
    {
        if (collision.gameObject.name == "Player")
        {
            // Set Player as a child of transform (MovingPlatform) upon collision so Player moves with MovingPlatform
            collision.gameObject.transform.SetParent(transform); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Remove Player from MovingPlatform heirachy so they detach
            collision.gameObject.transform.SetParent(null); 
        }
    }
}
