using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsloOrbs : MonoBehaviour
{
    [SerializeField] private Transform orbPos;
    [SerializeField] private Transform shotPoint;
    public GameObject airOrb;
    public GameObject earthOrb;
    public GameObject fireOrb;
    public GameObject waterOrb;

    [SerializeField] private GameObject fireball;
    private GameObject equippedOrb;
    private string equippedOrbType;

    private LevitationAbility levitationAbility; // Reference to the LevitationAbility script

    private void Start()
    {
        levitationAbility = GetComponent<LevitationAbility>(); // Get the LevitationAbility component from the same GameObject
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (equippedOrbType == "Air")
            {
                ToggleLevitation(); // Toggle the levitation ability when the Fire1 button is pressed with the Air Orb equipped
            }
            else
            {
                Shoot();
            }
        }
    }

    public void Spawn(string name)
    {
        if (equippedOrb == null)
        {
            if (name == "Air Orb")
            {
                equippedOrb = Instantiate(airOrb, orbPos.position, Quaternion.identity);
                equippedOrbType = "Air";
            }
            else if (name == "Earth Orb")
            {
                equippedOrb = Instantiate(earthOrb, orbPos.position, Quaternion.identity);
                equippedOrbType = "Earth";
            }
            else if (name == "Fire Orb")
            {
                equippedOrb = Instantiate(fireOrb, orbPos.position, Quaternion.identity);
                equippedOrbType = "Fire";
            }
            else if (name == "Water Orb")
            {
                equippedOrb = Instantiate(waterOrb, orbPos.position, Quaternion.identity);
                equippedOrbType = "Water";
            }

            equippedOrb.gameObject.transform.SetParent(transform);
        }
    }

    public bool NoOrbEquipped()
    {
        return equippedOrb == null;
    }

    private void ToggleLevitation()
    {
        if (levitationAbility != null)
        {
            if (levitationAbility.isLevitating)
            {
                levitationAbility.StopLevitation(); // Stop levitation when the ability is already active
            }
            else
            {
                levitationAbility.StartLevitation(); // Start levitation when the ability is not active
            }
        }
    }

    private void Shoot()
    {
        if (equippedOrbType == "Fire")
        {
            Instantiate(fireball, shotPoint.position, Quaternion.identity);
            equippedOrbType = null;
            DestroyOrb();
        }
        else if (equippedOrbType == "Water")
        {
            Instantiate(waterOrb, shotPoint.position, Quaternion.identity);
            equippedOrbType = null;
            DestroyOrb();
        }
        else if (equippedOrbType == "Earth")
        {
            Instantiate(earthOrb, shotPoint.position, Quaternion.identity);
            equippedOrbType = null;
            DestroyOrb();
        }
        else if (equippedOrbType == "Air")
        {
            Instantiate(airOrb, shotPoint.position, Quaternion.identity);
        }
    }

    public void DestroyOrb()
    {
        Destroy(equippedOrb);
    }
}
