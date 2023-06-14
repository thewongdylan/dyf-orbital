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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Spawn(string name)
    {
        // if (equippedOrb == null) {
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
            else if (name ==  "Water Orb")
            {
                equippedOrb = Instantiate(waterOrb, orbPos.position, Quaternion.identity); 
                equippedOrbType = "Water";
            }

            equippedOrb.gameObject.transform.SetParent(transform); 
        // }
    }

    public bool NoOrbEquipped()
    {
        return equippedOrb == null;
    }

    private void Shoot()
    {
        if (equippedOrbType == "Fire")
        {
            Instantiate(fireball, shotPoint.position, Quaternion.identity);
        }
        equippedOrbType = null;
        DestroyOrb();
    }

    public void DestroyOrb()
    {
        Destroy(equippedOrb);
    }
}
