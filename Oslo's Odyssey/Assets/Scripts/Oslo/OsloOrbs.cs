using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsloOrbs : MonoBehaviour
{
    [SerializeField] private OsloData osloData;
    [SerializeField] private Transform orbPos;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private Transform abilityBarPos;
    public GameObject airOrb;
    public GameObject earthOrb;
    public GameObject fireOrb;
    public GameObject waterOrb;
    [SerializeField] private GameObject fireball;
    private Dictionary<string, GameObject> orbDict;
    public List<GameObject> availableOrbs;
    public GameObject equippedOrb;
    public string equippedOrbType;
    private int equippedOrbIndex;
    private LevitationAbility levitationAbility; // Reference to the LevitationAbility script
    [SerializeField] private GameObject abilityBar;
    // private bool isAbilityActive = false;

    private void Awake()
    {
        // Debug.Log("osloOrbs Awake");
        availableOrbs = osloData.availableOrbs;
        equippedOrb = osloData.equippedOrb;
        equippedOrbType = osloData.equippedOrbType;
        equippedOrbIndex = osloData.equippedOrbIndex;
        // Debug.Log("osloData.equippedOrb:" + osloData.equippedOrb + osloData.equippedOrbType);

        // Debug.Log("osloOrbs obtained orb data from osloData"); 
        // Debug.Log("Awake: " + availableOrbs.Count + " " + equippedOrbType); 
        // Debug.Log("Awake: orb equipped? :" + (equippedOrb != null));
    }

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
        if (levitationAbility != null)
        {
            Debug.Log("levitation not null");
        }
        if (!NoOrbEquipped()) // if an orb was equipped previously, spawn it
        {
            SpawnExistingOrb(equippedOrbType);
        }
        abilityBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        osloData.availableOrbs = availableOrbs;
        osloData.equippedOrb = equippedOrb;
        osloData.equippedOrbType = equippedOrbType;
        osloData.equippedOrbIndex = equippedOrbIndex;

        if (Input.GetButtonDown("Ability")) //spacebar
        {
             ActivateAbility();   
        }
        if (Input.GetButtonDown("Switch")) //e key
        {
             SwitchOrb();   
        }
        if (equippedOrbType == "Air Orb")
        {
            abilityBar.SetActive(true);
        }
        else
        {
            abilityBar.SetActive(false);
        }
    }

    public bool NoOrbEquipped()
    {
        return equippedOrbType == null;
    }

    public void SpawnNewOrb(string orbName)
    {
        GameObject incomingOrb = orbDict[orbName];
        Debug.Log("incoming orb: " + orbName);

        if (NoOrbEquipped())
        {
            SpawnOrb(orbName, incomingOrb);
            Debug.Log("equipped: " + equippedOrbType);
        }
        // does not contain incoming orb
        if (!availableOrbs.Contains(incomingOrb))
        {
            availableOrbs.Add(incomingOrb);
        }
        
        Debug.Log(orbName + " added to avail orbs list");
    }

    public void SpawnExistingOrb(string orbName)
    {
        GameObject spawnedOrb = orbDict[orbName];
        Debug.Log("spawning orb: " + spawnedOrb.ToString());
        SpawnOrb(orbName, spawnedOrb);
        Debug.Log("spawned: " + equippedOrbType);
    }

    private void SpawnOrb(string orbName, GameObject orbToSpawn)
    {
        equippedOrb = Instantiate(orbToSpawn, orbPos.position, Quaternion.identity);
        equippedOrb.GetComponent<BoxCollider2D>().enabled = false;
        equippedOrb.gameObject.transform.SetParent(transform);
        equippedOrbType = orbName;
    }

    private void ActivateAbility()
    {
        if (equippedOrbType == "Fire Orb")
        {
            Instantiate(fireball, shotPoint.position, Quaternion.identity);
            // equippedOrbType = null;
            DestroyEquippedOrb();
        }
        else if (equippedOrbType == "Water Orb")
        {
            Debug.Log("Nothing should happen, water ability is passive");
        }
        else if (equippedOrbType == "Earth Orb")
        {
            Debug.Log("Nothing should happen, earth orb not implemented yet");
        }
        else if (equippedOrbType == "Air Orb")
        { 
            if (WaterTile.inWater)
            {
                Debug.Log("levitation cannot be used underwater");
            }
            else
            {
                levitationAbility.ToggleLevitation();
                Debug.Log("levitaton activated");
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
