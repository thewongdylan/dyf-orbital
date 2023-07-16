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
        if ((WaterTile.inWater) && (equippedOrbType == "Water Orb"))
        {
            rb.gravityScale = 2f;
            isDiving = true;
        }
        else
        {
            rb.gravityScale = 5f;
            isDiving = false;
        } 
    }
}
