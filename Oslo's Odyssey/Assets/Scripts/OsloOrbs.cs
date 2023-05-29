using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsloOrbs : MonoBehaviour
{
    [SerializeField] private Transform orbPos;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private GameObject fireOrb;
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
        if (name == "Fire Orb")
        {
            equippedOrb = Instantiate(fireOrb, orbPos.position, Quaternion.identity);
            equippedOrbType = "Fire";
        }
        else 
        {
            equippedOrb = Instantiate(fireOrb, orbPos.position, Quaternion.identity); //placeholder for now
        }

        equippedOrb.gameObject.transform.SetParent(transform); 
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
