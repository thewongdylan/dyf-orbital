using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivingAbility : MonoBehaviour
{
    [SerializeField] private OsloData osloData;
    private GameObject equipppedOrb;
    private string equippedOrbType;
    public bool isDiving = false;
    private Rigidbody2D rb;
    private Vector2 movementInput;
    public float divingForce = 5f; // Force applied to the character when diving


    // Start is called before the first frame update
    void Start()
    {
        equipppedOrb = osloData.equippedOrb;
        equippedOrbType = osloData.equippedOrbType;  
        rb = GetComponent<Rigidbody2D>();     
    }

    // Update is called once per frame
    void Update()
    {
        equippedOrbType = osloData.equippedOrbType;  
        if (equippedOrbType == "Water Orb")
        {
            if (WaterTile.inWater)
            {
                // float moveHorizontal = Input.GetAxis("Horizontal");
                // float moveVertical = Input.GetAxis("Vertical");
                // movementInput = new Vector2(moveHorizontal, moveVertical);
                // movementInput.Normalize();
                // rb.gravityScale = 0f;
                // rb.velocity = movementInput * divingForce;  
                isDiving = true;
            }
            else
            {
                isDiving = false;
            }   
        }
    }
}
