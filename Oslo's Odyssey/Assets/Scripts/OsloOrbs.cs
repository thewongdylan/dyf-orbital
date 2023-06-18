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
    private Dictionary<string, GameObject> orbDict;
    public List<GameObject> availableOrbs;
    public GameObject equippedOrb = null;
    public string equippedOrbType = null;
    private int equippedOrbIndex = 0;
    private LevitationAbility levitationAbility; // Reference to the LevitationAbility script
    // private bool isAbilityActive = false;

    // Start is called before the first frame update
    void Start()
    {
        levitationAbility = GetComponent<LevitationAbility>();
        orbDict = new Dictionary<string, GameObject>(){
            {"Air Orb", airOrb},
            {"Earth Orb", earthOrb},
            {"Fire Orb", fireOrb},
            {"Water Orb", waterOrb}
        };
        availableOrbs = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Ability")) //spacebar
        {
             ActivateAbility();   
        }
        if (Input.GetButtonDown("Switch")) //e key
        {
             SwitchOrb();   
        }
    }

    public bool NoOrbEquipped()
    {
        return equippedOrb == null;
    }

    public void SpawnNewOrb(string orbName)
    {
        GameObject incomingOrb = orbDict[orbName];
        Debug.Log("incoming orb: " + orbName);

        if (NoOrbEquipped())
        {
            equippedOrb = Instantiate(incomingOrb, orbPos.position, Quaternion.identity);
            equippedOrb.GetComponent<BoxCollider2D>().enabled = false;
            equippedOrb.gameObject.transform.SetParent(transform);
            equippedOrbType = orbName;
            Debug.Log("equipped up: " + equippedOrbType);
        }
        availableOrbs.Add(incomingOrb);
        Debug.Log(orbName + " added to avail orbs list");
    }

    public void SpawnExistingOrb(string orbName)
    {
        GameObject spawnedOrb = orbDict[orbName];
        Debug.Log("spawning orb: " + spawnedOrb.ToString());
        equippedOrb = Instantiate(spawnedOrb, orbPos.position, Quaternion.identity);
        equippedOrb.GetComponent<BoxCollider2D>().enabled = false;
        equippedOrb.gameObject.transform.SetParent(transform);
        equippedOrbType = orbName;
        Debug.Log("spawned: " + equippedOrbType);
    }

    private void ActivateAbility()
    {
        if (equippedOrbType == "Fire Orb")
        {
            Instantiate(fireball, shotPoint.position, Quaternion.identity);
            equippedOrbType = null;
            DestroyEquippedOrb();
        }
        else if (equippedOrbType == "Water Orb")
        {
            // Instantiate(waterOrb, shotPoint.position, Quaternion.identity);
            // equippedOrbType = null;
            // DestroyEquippedOrb();
        }
        else if (equippedOrbType == "Earth Orb")
        {
            // Instantiate(earthOrb, shotPoint.position, Quaternion.identity);
            // equippedOrbType = null;
            // DestroyEquippedOrb();
        }
        else if (equippedOrbType == "Air Orb" && equippedOrb != null)
        {
            if (levitationAbility != null)
            {
                levitationAbility.ToggleLevitation();
                Debug.Log("triggered inside airorb condition");
            }
        }
    }

    private void SwitchOrb()
    {
        DestroyEquippedOrb();
        if (equippedOrbIndex < (availableOrbs.Count - 1))
        {
            equippedOrbIndex++;
        }
        else
        {
            equippedOrbIndex = 0;
        }
        equippedOrb = availableOrbs[equippedOrbIndex];
        equippedOrbType = equippedOrb.name;
        SpawnExistingOrb(equippedOrbType);
        Debug.Log("switched to: " + equippedOrb);
    }

    public void DestroyEquippedOrb()
    {
        Destroy(equippedOrb);
    }
}
